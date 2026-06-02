Imports System.IO
Imports System.Reflection
Imports System.Runtime.InteropServices
Imports System.Threading

Public Class Main

    Shared Version As String

    Private WithEvents updateTimer As New System.Windows.Forms.Timer()
    Const updateTimer_Interval = 33

    Private WithEvents hookTimer As New System.Windows.Forms.Timer()
    Const hookTimer_Interval = 1000

    Private Declare Function OpenProcess Lib "kernel32.dll" (ByVal dwDesiredAcess As UInt32, ByVal bInheritHandle As Boolean, ByVal dwProcessId As Int32) As IntPtr
    Private Declare Function ReadProcessMemory Lib "kernel32" (ByVal hProcess As IntPtr, ByVal lpBaseAddress As IntPtr, ByVal lpBuffer() As Byte, ByVal iSize As Integer, ByRef lpNumberOfBytesRead As Integer) As Boolean
    Private Declare Function WriteProcessMemory Lib "kernel32" (ByVal hProcess As IntPtr, ByVal lpBaseAddress As IntPtr, ByVal lpBuffer() As Byte, ByVal iSize As Integer, ByVal lpNumberOfBytesWritten As Integer) As Boolean
    Public Declare Function CloseHandle Lib "kernel32.dll" (ByVal hObject As IntPtr) As Boolean
    Private Declare Function VirtualAllocEx Lib "kernel32.dll" (ByVal hProcess As IntPtr, ByVal lpAddress As IntPtr, ByVal dwSize As IntPtr, ByVal flAllocationType As Integer, ByVal flProtect As Integer) As IntPtr
    Private Declare Function VirtualProtectEx Lib "kernel32.dll" (hProcess As IntPtr, lpAddress As IntPtr, ByVal lpSize As IntPtr, ByVal dwNewProtect As UInt32, ByRef dwOldProtect As UInt32) As Boolean
    Private Declare Function VirtualFreeEx Lib "kernel32.dll" (hProcess As IntPtr, lpAddress As IntPtr, ByVal dwSize As Integer, ByVal dwFreeType As Integer) As Boolean
    Public Declare Function CreateRemoteThread Lib "kernel32" (ByVal hProcess As Integer, ByVal lpThreadAttributes As Integer, ByVal dwStackSize As Integer, ByVal lpStartAddress As Integer, ByVal lpParameter As Integer, ByVal dwCreationFlags As Integer, ByRef lpThreadId As Integer) As Integer

    <DllImport("kernel32", SetLastError:=True)>
    Shared Function WaitForSingleObject(
        ByVal handle As IntPtr,
        ByVal milliseconds As UInt32) As UInt32
    End Function

    <DllImport("kernel32")>
    Shared Function OpenThread(
        ByVal dwDesiredAccess As Integer,
        ByVal bInheritHandle As Boolean,
        ByVal dwThreadId As UInt32) As IntPtr
    End Function

    <DllImport("kernel32")>
    Shared Function SuspendThread(
        ByVal hThread As IntPtr) As UInt32
    End Function

    <DllImport("kernel32")>
    Shared Function ResumeThread(
        ByVal hThread As IntPtr) As Int32
    End Function

    <DllImport("kernel32.dll")>
    Shared Function FlushInstructionCache(
        ByVal hProcess As IntPtr,
        ByVal lpBaseAddress As IntPtr,
        ByVal dwSize As UIntPtr) As Boolean
    End Function

    ' Required to enumerate memory regions for AOB scan
    <DllImport("kernel32.dll", SetLastError:=True)>
    Private Shared Function VirtualQueryEx(
        ByVal hProcess As IntPtr,
        ByVal lpAddress As IntPtr,
        <Out> ByRef lpBuffer As MEMORY_BASIC_INFORMATION,
        ByVal dwLength As UInteger) As UInteger
    End Function

    <StructLayout(LayoutKind.Explicit, Size:=48)>
    Private Structure MEMORY_BASIC_INFORMATION
        <FieldOffset(0)> Public BaseAddress As IntPtr
        <FieldOffset(8)> Public AllocationBase As IntPtr
        <FieldOffset(16)> Public AllocationProtect As UInt32
        <FieldOffset(24)> Public RegionSize As IntPtr
        <FieldOffset(32)> Public State As UInt32
        <FieldOffset(36)> Public Protect As UInt32
        <FieldOffset(40)> Public Type As UInt32
    End Structure

    Public Const PROCESS_VM_READ = &H10
    Public Const TH32CS_SNAPPROCESS = &H2
    Public Const MEM_COMMIT = 4096
    Public Const MEM_RELEASE = &H8000
    Public Const PAGE_READWRITE = 4
    Public Const PAGE_EXECUTE_READWRITE = &H40
    Public Const PROCESS_CREATE_THREAD = (&H2)
    Public Const PROCESS_VM_OPERATION = (&H8)
    Public Const PROCESS_VM_WRITE = (&H20)
    Public Const PROCESS_ALL_ACCESS = &H1F0FFF

    Private WithEvents expandCheckbox As CheckBox
    Private expandedPanel As Panel
    Private AlwaysOnTopCheckbox As CheckBox
    Private WithEvents runModeCheckbox As CheckBox
    Private sideBarTreasureValueLabel As Label
    Private sideBarBossesValueLabel As Label
    Private sideBarEnemiesValueLabel As Label
    Private sideBarQuestlinesValueLabel As Label
    Private sideBarLockedDoorsValueLabel As Label
    Private sideBarIllusoryWallsValueLabel As Label
    Private sideBarFoggatesValueLabel As Label
    Private sideBarKindledBonfiresValueLabel As Label
    Private sideBarTotalValueLabel As Label
    Private WithEvents mapsListView As ListView
    Private WithEvents questlinesLabel As Label
    Private WithEvents questlinesValueLabel As Label
    Private detailHeaderLabel As Label
    Private detailTree As TreeView
    Private nodesByFlagId As New Dictionary(Of Integer, TreeNode)
    Private currentMapId As String = ""


    Private Shared ReadOnly DetailCategories As String() = {
        "Treasure", "Bosses", "Non-Respawning Enemies",
        "Shortcuts / Locked Doors", "Illusory Walls", "Foggates", "Kindled Bonfires"
    }


    Private Const QUESTLINES_MAPID As String = "__questlines__"


    Dim isHooked As Boolean = False
    Public Shared exeVER As String = ""

    Private Shared _targetProcess As Process = Nothing
    Public Shared _targetProcessHandle As IntPtr = IntPtr.Zero

    Public Function ScanForProcess(ByVal windowCaption As String, Optional automatic As Boolean = False) As Boolean
        Dim _allProcesses() As Process = Process.GetProcesses
        Dim selectedProcess As Process = Nothing
        For Each pp As Process In _allProcesses
            If pp.MainWindowTitle.ToLower.Equals(windowCaption.ToLower) Then
                selectedProcess = pp
            Else
                pp.Dispose()
            End If
        Next
        If selectedProcess IsNot Nothing Then
            Return TryAttachToProcess(selectedProcess, automatic)
        End If
        Return False
    End Function

    Public Function TryAttachToProcess(ByVal proc As Process, Optional automatic As Boolean = False) As Boolean
        DetachFromProcess()

        _targetProcess = proc
        _targetProcessHandle = OpenProcess(PROCESS_ALL_ACCESS, False, _targetProcess.Id)
        If _targetProcessHandle = 0 Then
            If Not automatic Then
                MessageBox.Show("Failed to attach to process. Please rerun the application with administrative privileges.")
            End If
            Return False
        Else
            Return True
        End If
    End Function

    Public Sub DetachFromProcess()
        If _targetProcessHandle <> IntPtr.Zero Then
            _targetProcess.Dispose()
            _targetProcess = Nothing
            Try
                CloseHandle(_targetProcessHandle)
                _targetProcessHandle = IntPtr.Zero
            Catch ex As Exception
                MessageBox.Show("Warning: MemoryManager::DetachFromProcess::CloseHandle error " & Environment.NewLine & ex.Message)
            End Try
        End If
    End Sub

    ' Scans the game's main module for a byte pattern.
    ' Use "?" as a single-byte wildcard. Returns IntPtr.Zero if not found.
    Public Shared Function ScanAOB(pattern As String) As IntPtr
        Dim parts = pattern.Split(" "c)
        Dim patLen = parts.Length
        Dim patBytes(patLen - 1) As Byte
        Dim wildcards(patLen - 1) As Boolean
        For i = 0 To patLen - 1
            If parts(i) = "?" Then
                wildcards(i) = True
            Else
                patBytes(i) = Convert.ToByte(parts(i), 16)
            End If
        Next

        If _targetProcess Is Nothing OrElse _targetProcess.HasExited Then Return IntPtr.Zero

        Try
            Dim baseAddr = _targetProcess.MainModule.BaseAddress.ToInt64()
            Dim moduleSize = _targetProcess.MainModule.ModuleMemorySize
            Const CHUNK = 4 * 1024 * 1024
            Dim offset As Long = 0

            Do While offset < moduleSize
                Dim chunkSize = CInt(Math.Min(CHUNK, moduleSize - offset))
                Dim buf(chunkSize - 1) As Byte
                Dim bytesRead As Integer
                If ReadProcessMemory(_targetProcessHandle, New IntPtr(baseAddr + offset), buf, chunkSize, bytesRead) AndAlso bytesRead >= patLen Then
                    Dim limit = bytesRead - patLen
                    For i As Integer = 0 To limit
                        Dim match = True
                        For j = 0 To patLen - 1
                            If Not wildcards(j) AndAlso buf(i + j) <> patBytes(j) Then
                                match = False
                                Exit For
                            End If
                        Next
                        If match Then Return New IntPtr(baseAddr + offset + i)
                    Next
                End If
                offset += chunkSize
            Loop
        Catch ex As Exception
        End Try

        Return IntPtr.Zero
    End Function

    Public Shared Function ResolveRelativeAOB(pattern As String) As IntPtr
        Dim instrAddr = ScanAOB(pattern)
        If instrAddr = IntPtr.Zero Then Return IntPtr.Zero
        Dim relOffset = RInt32(New IntPtr(instrAddr.ToInt64() + 3))
        Return New IntPtr(instrAddr.ToInt64() + 7 + relOffset)
    End Function

    Public Shared Function RInt8(ByVal addr As IntPtr) As SByte
        Dim _rtnBytes(0) As Byte
        ReadProcessMemory(_targetProcessHandle, addr, _rtnBytes, 1, vbNull)
        Return _rtnBytes(0)
    End Function
    Public Shared Function RInt16(ByVal addr As IntPtr) As Int16
        Dim _rtnBytes(1) As Byte
        ReadProcessMemory(_targetProcessHandle, addr, _rtnBytes, 2, vbNull)
        Return BitConverter.ToInt16(_rtnBytes, 0)
    End Function
    Public Shared Function RInt32(ByVal addr As IntPtr) As Int32
        Dim _rtnBytes(3) As Byte
        ReadProcessMemory(_targetProcessHandle, addr, _rtnBytes, 4, vbNull)
        Return BitConverter.ToInt32(_rtnBytes, 0)
    End Function
    Public Shared Function RInt64(ByVal addr As IntPtr) As Int64
        Dim _rtnBytes(7) As Byte
        ReadProcessMemory(_targetProcessHandle, addr, _rtnBytes, 8, vbNull)
        Return BitConverter.ToInt64(_rtnBytes, 0)
    End Function
    Public Shared Function RUInt16(ByVal addr As IntPtr) As UInt16
        Dim _rtnBytes(1) As Byte
        ReadProcessMemory(_targetProcessHandle, addr, _rtnBytes, 2, vbNull)
        Return BitConverter.ToUInt16(_rtnBytes, 0)
    End Function
    Public Shared Function RUInt32(ByVal addr As IntPtr) As UInt32
        Dim _rtnBytes(3) As Byte
        ReadProcessMemory(_targetProcessHandle, addr, _rtnBytes, 4, vbNull)
        Return BitConverter.ToUInt32(_rtnBytes, 0)
    End Function
    Public Shared Function RUInt64(ByVal addr As IntPtr) As UInt64
        Dim _rtnBytes(7) As Byte
        ReadProcessMemory(_targetProcessHandle, addr, _rtnBytes, 8, vbNull)
        Return BitConverter.ToUInt64(_rtnBytes, 0)
    End Function
    Public Shared Function RSingle(ByVal addr As IntPtr) As Single
        Dim _rtnBytes(3) As Byte
        ReadProcessMemory(_targetProcessHandle, addr, _rtnBytes, 4, vbNull)
        Return BitConverter.ToSingle(_rtnBytes, 0)
    End Function
    Public Shared Function RDouble(ByVal addr As IntPtr) As Double
        Dim _rtnBytes(7) As Byte
        ReadProcessMemory(_targetProcessHandle, addr, _rtnBytes, 8, vbNull)
        Return BitConverter.ToDouble(_rtnBytes, 0)
    End Function
    Public Shared Function RIntPtr(ByVal addr As IntPtr) As IntPtr
        Dim _rtnBytes(IntPtr.Size - 1) As Byte
        ReadProcessMemory(_targetProcessHandle, addr, _rtnBytes, IntPtr.Size, Nothing)
        If IntPtr.Size = 4 Then
            Return New IntPtr(BitConverter.ToInt32(_rtnBytes, 0))
        Else
            Return New IntPtr(BitConverter.ToInt64(_rtnBytes, 0))
        End If
    End Function
    Public Shared Function RBytes(ByVal addr As IntPtr, ByVal size As Int32) As Byte()
        Dim _rtnBytes(size - 1) As Byte
        ReadProcessMemory(_targetProcessHandle, addr, _rtnBytes, size, vbNull)
        Return _rtnBytes
    End Function

    Public Shared Sub WInt32(ByVal addr As IntPtr, val As Int32)
        WriteProcessMemory(_targetProcessHandle, addr, BitConverter.GetBytes(val), 4, Nothing)
    End Sub
    Public Shared Sub WUInt32(ByVal addr As IntPtr, val As UInt32)
        WriteProcessMemory(_targetProcessHandle, addr, BitConverter.GetBytes(val), 4, Nothing)
    End Sub
    Public Shared Sub WSingle(ByVal addr As IntPtr, val As Single)
        WriteProcessMemory(_targetProcessHandle, addr, BitConverter.GetBytes(val), 4, Nothing)
    End Sub
    Public Shared Sub WBytes(ByVal addr As IntPtr, val As Byte())
        WriteProcessMemory(_targetProcessHandle, addr, val, val.Length, Nothing)
    End Sub

    Public Shared Function ReadFlag32(address As Long, mask As UInteger) As Boolean
        Dim _rtnBytes(3) As Byte
        ReadProcessMemory(_targetProcessHandle, New IntPtr(address), _rtnBytes, 4, vbNull)
        Dim flags = BitConverter.ToUInt32(_rtnBytes, 0)
        Return (flags And mask) <> 0
    End Function

    Private Sub SetDarkSoulsThreadSuspend(suspend As Boolean)
        If _targetProcess Is Nothing Then Return
        For Each pthread As ProcessThread In _targetProcess.Threads
            Dim pOpenThread = OpenThread(&H2, False, pthread.Id)
            If pOpenThread = 0 Then Continue For
            If suspend Then
                SuspendThread(pOpenThread)
            Else
                Dim suspendCount = 0
                Do
                    suspendCount = ResumeThread(pOpenThread)
                Loop While suspendCount > 0
            End If
            CloseHandle(pOpenThread)
        Next
    End Sub

    Private Sub SetHookButtonsEnabled(hookEnabled As Boolean, unhookEnabled As Boolean)
        Invoke(
            Sub()
                HookedLabel.Enabled = unhookEnabled
            End Sub)
    End Sub

    Private Sub btnHook_Click(sender As Object, e As EventArgs)
        Dim newThread = New Thread(AddressOf HookInOtherThread) With {.IsBackground = True}
        newThread.Start()
    End Sub

    Public Shared eventFlagPtr As Long

    Private Sub HookInOtherThread()
        SetHookButtonsEnabled(False, False)

        If ScanForProcess("DARK SOULS™: REMASTERED", True) Then
            exeVER = "Remaster"

            eventFlagPtr = Game.GetEventFlagPtr()

            If eventFlagPtr = 0 Then
                SetHookButtonsEnabled(True, False)
                Return
            End If

            Invoke(
                Sub()
                    updateTimer = New System.Windows.Forms.Timer
                    updateTimer.Interval = updateTimer_Interval
                    AddHandler updateTimer.Tick, AddressOf updateTimer_Tick
                    updateTimer.Start()
                End Sub)

            isHooked = True
        Else
            SetHookButtonsEnabled(True, False)
            Return
        End If

        SetHookButtonsEnabled(False, True)
    End Sub

    Private Sub updateTimer_Tick()
        Dim updateThread = New Thread(AddressOf scanEventFlagsAndUpdateUI) With {.IsBackground = True}
        updateThread.Start()
    End Sub

    Dim lastPercentage As Double

    Private Sub scanEventFlagsAndUpdateUI()
        eventFlagPtr = Game.GetEventFlagPtr()

        If Game.isPlayerInOwnWorld() = False Then Return

        Invoke(
            Sub()
                updateTimer.Stop()
            End Sub)

        Game.updateAllEventFlags()

        If Game.IsPlayerLoaded() = False Then
            Invoke(Sub() updateTimer.Start())
            Return
        End If

        If Game.GetClearCount > 0 Then
            If Game.GetTotalCompletionPercentage < lastPercentage Then
                Invoke(
                Sub()
                    updateTimer.Start()
                End Sub)
                Return
            End If
        End If

        Invoke(
            Sub()
                treasureLocationsValueLabel.Text = $"{Game.GetTreasureLocationsCleared} / {Game.GetTotalTreasureLocationsCount}"
                bossesKilledValueLabel.Text = $"{Game.GetBossesKilled} / {Game.GetTotalBossCount}"
                nonRespawningEnemiesValueLabel.Text = $"{Game.GetNonRespawningEnemiesKilled} / {Game.GetTotalNonRespawningEnemiesCount}"
                npcQuestlinesValueLabel.Text = $"{Game.GetNPCQuestlinesCompleted} / {Game.GetTotalNPCQuestlinesCount}"
                shortcutsValueLabel.Text = $"{Game.GetShortcutsAndLockedDoorsUnlocked} / {Game.GetTotalShortcutsAndLockedDoorsCount}"
                illusoryWallsValueLabel.Text = $"{Game.GetIllusoryWallsRevealed} / {Game.GetTotalIllusoryWallsCount}"
                foggatesValueLabel.Text = $"{Game.GetFoggatesDissolved} / {Game.GetTotalFoggatesCount}"
                bonfiresValueLabel.Text = $"{Game.GetBonfiresFullyKindled} / {Game.GetTotalBonfiresCount}"

                sideBarTreasureValueLabel.Text = $"{Game.GetTreasureLocationsCleared} / {Game.GetTotalTreasureLocationsCount}"
                sideBarBossesValueLabel.Text = $"{Game.GetBossesKilled} / {Game.GetTotalBossCount}"
                sideBarEnemiesValueLabel.Text = $"{Game.GetNonRespawningEnemiesKilled} / {Game.GetTotalNonRespawningEnemiesCount}"
                sideBarQuestlinesValueLabel.Text = $"{Game.GetNPCQuestlinesCompleted} / {Game.GetTotalNPCQuestlinesCount}"
                sideBarLockedDoorsValueLabel.Text = $"{Game.GetShortcutsAndLockedDoorsUnlocked} / {Game.GetTotalShortcutsAndLockedDoorsCount}"
                sideBarIllusoryWallsValueLabel.Text = $"{Game.GetIllusoryWallsRevealed} / {Game.GetTotalIllusoryWallsCount}"
                sideBarFoggatesValueLabel.Text = $"{Game.GetFoggatesDissolved} / {Game.GetTotalFoggatesCount}"
                sideBarKindledBonfiresValueLabel.Text = $"{Game.GetBonfiresFullyKindled} / {Game.GetTotalBonfiresCount}"

                Dim totalPercentage = Game.GetTotalCompletionPercentage.ToString("0.0")
                percentageLabel.Text = $"{totalPercentage}%"
                sideBarTotalValueLabel.Text = $"{totalPercentage}%"
                lastPercentage = Game.GetTotalCompletionPercentage

                If expandedPanel IsNot Nothing AndAlso expandedPanel.Visible Then
                    RefreshMapsListView()
                    RefreshDetailLive()
                End If

                updateTimer.Start()
            End Sub)
    End Sub

    Private Sub UI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Invoke(
               Sub()
                   hookTimer = New System.Windows.Forms.Timer
                   hookTimer.Interval = hookTimer_Interval

                   AddHandler hookTimer.Tick, AddressOf hookTimer_Tick
                   hookTimer.Start()
                   expandCheckbox = New CheckBox() With {
                     .Text = "Expand",
                     .Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold),
                     .ForeColor = System.Drawing.Color.White,
                     .Location = New System.Drawing.Point(100, 269),
                     .Size = New System.Drawing.Size(75, 30)}
                   Me.Controls.Add(expandCheckbox)
                   runModeCheckbox = New CheckBox() With {
                   .Text = "Run Mode",
                     .Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold),
                     .ForeColor = System.Drawing.Color.White,
                     .Location = New System.Drawing.Point(180, 269),
                     .Size = New System.Drawing.Size(95, 30)}

                   Me.Controls.Add(runModeCheckbox)
                   AlwaysOnTopCheckbox = New CheckBox() With {
                   .Text = "Always on Top",
                     .Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold),
                     .ForeColor = System.Drawing.Color.White,
                     .Location = New System.Drawing.Point(280, 269),
                     .Size = New System.Drawing.Size(135, 30)}

                   Me.Controls.Add(AlwaysOnTopCheckbox)
                   AddHandler AlwaysOnTopCheckbox.CheckedChanged, AddressOf AlwaysOnTopManagement

                   expandedPanel = New Panel() With {
                 .Location = New System.Drawing.Point(0, 0),
                 .Size = New System.Drawing.Size(950, 650),
                 .BackColor = System.Drawing.SystemColors.ActiveCaptionText,
                 .Visible = False}

                   Me.Controls.Add(expandedPanel)

                   Dim leftBorderLine As New Panel() With {
                       .BackColor = System.Drawing.Color.White,
                       .Size = New System.Drawing.Size(1, 645),
                       .Location = New System.Drawing.Point(0, 0)
                   }
                   expandedPanel.Controls.Add(leftBorderLine)

                   Dim makeTitle = Function(text As String, y As Integer) As Label
                                       Dim lbl As New Label() With {
                                           .Text = text,
                                           .Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold),
                                           .ForeColor = System.Drawing.Color.White,
                                           .Location = New System.Drawing.Point(12, y),
                                           .AutoSize = True
                                       }
                                       expandedPanel.Controls.Add(lbl)
                                       Return lbl
                                   End Function

                   Dim makeValue = Function(y As Integer) As Label
                                       Dim lbl As New Label() With {
                                           .Text = "X / X",
                                           .Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold),
                                           .ForeColor = System.Drawing.Color.White,
                                           .Location = New System.Drawing.Point(180, y),
                                           .Size = New System.Drawing.Size(80, 18),
                                           .TextAlign = System.Drawing.ContentAlignment.MiddleRight,
                                           .AutoSize = False
                                       }
                                       expandedPanel.Controls.Add(lbl)
                                       Return lbl
                                   End Function

                   makeTitle("Treasure", 10)
                   sideBarTreasureValueLabel = makeValue(10)

                   makeTitle("Bosses", 30)
                   sideBarBossesValueLabel = makeValue(30)

                   makeTitle("Non-Respawning Enemies", 50)
                   sideBarEnemiesValueLabel = makeValue(50)

                   makeTitle("NPC Questlines", 70)
                   sideBarQuestlinesValueLabel = makeValue(70)

                   makeTitle("Shortcuts", 90)
                   sideBarLockedDoorsValueLabel = makeValue(90)

                   makeTitle("Illusory Walls", 110)
                   sideBarIllusoryWallsValueLabel = makeValue(110)

                   makeTitle("Foggates", 130)
                   sideBarFoggatesValueLabel = makeValue(130)

                   makeTitle("Kindled Bonfires", 150)
                   sideBarKindledBonfiresValueLabel = makeValue(150)

                   sideBarTotalValueLabel = New Label() With {
                       .Text = "X / X",
                       .Font = New System.Drawing.Font("Arial", 16.0!, System.Drawing.FontStyle.Bold),
                       .ForeColor = System.Drawing.Color.White,
                       .Location = New System.Drawing.Point(12, 178),
                       .Size = New System.Drawing.Size(248, 26),
                       .TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                       .AutoSize = False
                   }
                   expandedPanel.Controls.Add(sideBarTotalValueLabel)

                   Dim sideBarSeparatorLabel As New Label() With {
                   .BorderStyle = BorderStyle.FixedSingle,
                   .AutoSize = False,
                   .Size = New System.Drawing.Size(286, 1),
                   .Location = New System.Drawing.Point(0, 210),
                   .BackColor = System.Drawing.Color.White
                   }
                   expandedPanel.Controls.Add(sideBarSeparatorLabel)

                   ' --- Maps ListView ---
                   mapsListView = New ListView() With {
                   .View = System.Windows.Forms.View.Details,
                   .FullRowSelect = True,
                   .HideSelection = False,
                   .GridLines = False,
                   .MultiSelect = False,
                   .HeaderStyle = ColumnHeaderStyle.None,
                   .BackColor = System.Drawing.SystemColors.ActiveCaptionText,
                   .ForeColor = System.Drawing.Color.White,
                   .Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold),
                   .BorderStyle = BorderStyle.None,
                   .Scrollable = False,
                   .AllowColumnReorder = False,
                   .OwnerDraw = True,
                   .Location = New System.Drawing.Point(10, 220),
                   .Size = New System.Drawing.Size(260, 385)
                   }
                   mapsListView.Columns.Add("Map", 175)
                   Dim progressCol = mapsListView.Columns.Add("Progress", 85)
                   progressCol.TextAlign = HorizontalAlignment.Right

                   AddHandler mapsListView.ColumnWidthChanging,
                       Sub(s As Object, args As ColumnWidthChangingEventArgs)
                           args.Cancel = True
                           args.NewWidth = mapsListView.Columns(args.ColumnIndex).Width
                       End Sub

                   AddHandler mapsListView.DrawColumnHeader,
                       Sub(s As Object, args As DrawListViewColumnHeaderEventArgs)
                           Using bg As New System.Drawing.SolidBrush(System.Drawing.SystemColors.ActiveCaptionText)
                               args.Graphics.FillRectangle(bg, args.Bounds)
                           End Using
                           Using fg As New System.Drawing.SolidBrush(System.Drawing.Color.White)
                               Dim sf As New System.Drawing.StringFormat() With {
                                   .LineAlignment = StringAlignment.Center,
                                   .Alignment = StringAlignment.Near
                               }
                               args.Graphics.DrawString(args.Header.Text, mapsListView.Font, fg, args.Bounds, sf)
                           End Using
                       End Sub

                   AddHandler mapsListView.DrawItem,
                       Sub(s As Object, args As DrawListViewItemEventArgs)
                           args.DrawDefault = True
                       End Sub
                   AddHandler mapsListView.DrawSubItem,
                       Sub(s As Object, args As DrawListViewSubItemEventArgs)
                           args.DrawDefault = True
                       End Sub

                   ' Store the map ID in Tag for later lookup
                   Dim maps = New List(Of (Id As String, Name As String)) From {
                       ("18_1", "Asylum"),
                       ("10_2", "Firelink"),
                       ("10_1", "Undead Burg"),
                       ("12_0", "Darkroot"),
                       ("10_0", "Depths"),
                       ("11_0", "Painted World"),
                       ("13_0", "Catacombs"),
                       ("12_1", "DLC"),
                       ("15_0", "Sen's"),
                       ("15_1", "Anor Londo"),
                       ("13_1", "Tomb of Giants"),
                       ("14_1", "Demon Ruins & Izalith"),
                       ("14_0", "Blighttown"),
                       ("16_0", "New Londo & Valley"),
                       ("17_0", "Duke's Archives"),
                       ("13_2", "Ash Lake & Great Hollow"),
                       ("18_0", "Kiln")
                   }

                   For Each m In maps
                       Dim row = New ListViewItem(m.Name)
                       row.SubItems.Add("0 / 0")
                       row.Tag = m.Id
                       mapsListView.Items.Add(row)
                   Next

                   expandedPanel.Controls.Add(mapsListView)

                   Dim questlinesSeparator As New Panel() With {
                       .BackColor = System.Drawing.Color.White,
                       .Size = New System.Drawing.Size(260, 1),
                       .Location = New System.Drawing.Point(10, 610)
                   }
                   expandedPanel.Controls.Add(questlinesSeparator)

                   questlinesLabel = New Label() With {
                       .Text = "NPC Questlines",
                       .Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold),
                       .ForeColor = System.Drawing.Color.White,
                       .BackColor = System.Drawing.SystemColors.ActiveCaptionText,
                       .Location = New System.Drawing.Point(14, 615),
                       .Size = New System.Drawing.Size(175, 22),
                       .TextAlign = System.Drawing.ContentAlignment.MiddleLeft,
                       .Cursor = Cursors.Hand,
                       .AutoSize = False
                   }
                   expandedPanel.Controls.Add(questlinesLabel)

                   questlinesValueLabel = New Label() With {
                       .Text = "0 / 0",
                       .Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold),
                       .ForeColor = System.Drawing.Color.White,
                       .BackColor = System.Drawing.SystemColors.ActiveCaptionText,
                       .Location = New System.Drawing.Point(185, 615),
                       .Size = New System.Drawing.Size(85, 22),
                       .TextAlign = System.Drawing.ContentAlignment.MiddleRight,
                       .Cursor = Cursors.Hand,
                       .AutoSize = False
                   }
                   expandedPanel.Controls.Add(questlinesValueLabel)

                   Dim midDivider As New Panel() With {
                       .BackColor = System.Drawing.Color.White,
                       .Size = New System.Drawing.Size(1, 645),
                       .Location = New System.Drawing.Point(285, 0)
                   }
                   expandedPanel.Controls.Add(midDivider)

                   detailHeaderLabel = New Label() With {
                       .Text = "Select a map",
                       .Font = New System.Drawing.Font("Arial", 13.0!, System.Drawing.FontStyle.Bold),
                       .ForeColor = System.Drawing.Color.White,
                       .Location = New System.Drawing.Point(300, 12),
                       .Size = New System.Drawing.Size(630, 26),
                       .TextAlign = System.Drawing.ContentAlignment.MiddleLeft,
                       .AutoSize = False
                   }
                   expandedPanel.Controls.Add(detailHeaderLabel)

                   Dim detailSeparator As New Panel() With {
                       .BackColor = System.Drawing.Color.White,
                       .Size = New System.Drawing.Size(665, 1),
                       .Location = New System.Drawing.Point(285, 42)
                   }
                   expandedPanel.Controls.Add(detailSeparator)

                   detailTree = New TreeView() With {
                       .Location = New System.Drawing.Point(300, 50),
                       .Size = New System.Drawing.Size(630, 555),
                       .BackColor = System.Drawing.SystemColors.ActiveCaptionText,
                       .ForeColor = System.Drawing.Color.White,
                       .Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold),
                       .BorderStyle = BorderStyle.None,
                       .ShowLines = False,
                       .ShowRootLines = False,
                       .ShowPlusMinus = False,
                       .HideSelection = True,
                       .FullRowSelect = True,
                       .Indent = 20,
                       .ItemHeight = 22
                   }
                   AddHandler detailTree.BeforeExpand,
                       Sub(s As Object, ev As TreeViewCancelEventArgs)
                           Dim n = ev.Node
                           If n.Text.StartsWith(CategoryCollapsedGlyph) Then
                               n.Text = CategoryExpandedGlyph & n.Text.Substring(CategoryCollapsedGlyph.Length)
                           End If
                       End Sub
                   AddHandler detailTree.BeforeCollapse,
                       Sub(s As Object, ev As TreeViewCancelEventArgs)
                           Dim n = ev.Node
                           If n.Text.StartsWith(CategoryExpandedGlyph) Then
                               n.Text = CategoryCollapsedGlyph & n.Text.Substring(CategoryExpandedGlyph.Length)
                           End If
                       End Sub
                   AddHandler detailTree.NodeMouseClick,
                       Sub(s As Object, ev As TreeNodeMouseClickEventArgs)
                           If ev.Node.Parent Is Nothing Then
                               If ev.Node.IsExpanded Then ev.Node.Collapse() Else ev.Node.Expand()
                           End If
                       End Sub
                   expandedPanel.Controls.Add(detailTree)

               End Sub)
    End Sub

    Private Sub expandCheckbox_Click(sender As Object, e As EventArgs) Handles expandCheckbox.Click
        Me.ClientSize = If(expandCheckbox.Checked, New System.Drawing.Size(950, 650), New System.Drawing.Size(467, 302))

        SetCompactLabelsVisible(Not expandCheckbox.Checked)
        expandedPanel.Visible = expandCheckbox.Checked

        If expandCheckbox.Checked Then
            expandCheckbox.Location = New System.Drawing.Point(700, 615)
            runModeCheckbox.Location = New System.Drawing.Point(770, 615)
            AlwaysOnTopCheckbox.Location = New System.Drawing.Point(550, 615)
            HookedLabel.Location = New System.Drawing.Point(300, 625)
            Label3.Location = New System.Drawing.Point(890, 625)
        Else
            expandCheckbox.Location = New System.Drawing.Point(105, 269)
            runModeCheckbox.Location = New System.Drawing.Point(185, 269)
            AlwaysOnTopCheckbox.Location = New System.Drawing.Point(280, 269)
            HookedLabel.Location = New System.Drawing.Point(12, 276)
            Label3.Location = New System.Drawing.Point(420, 276)
        End If
        expandCheckbox.BringToFront()
        AlwaysOnTopCheckbox.BringToFront()
        runModeCheckbox.BringToFront()
        HookedLabel.BringToFront()
        Label3.BringToFront()

        If (expandCheckbox.Checked) Then
            runModeCheckbox.Checked = False
            runModeCheckbox.ForeColor = System.Drawing.Color.Gray
            runModeCheckbox.Refresh()
            Return
        End If
        If (expandCheckbox.Checked = False) Then
            runModeCheckbox.ForeColor = System.Drawing.Color.White
            runModeCheckbox.Refresh()
        End If
    End Sub




    Private Sub RefreshMapsListView()
        For Each item As ListViewItem In mapsListView.Items
            Dim mapId = TryCast(item.Tag, String)
            If String.IsNullOrEmpty(mapId) Then Continue For
            Dim res = Game.GetMapCompletion(mapId)
            Dim newText = $"{res.Done} / {res.Total}"
            If item.SubItems(1).Text <> newText Then
                item.SubItems(1).Text = newText
            End If
        Next

        If questlinesValueLabel IsNot Nothing Then
            Dim newQuestText = $"{Game.GetNPCQuestlinesCompleted} / {Game.GetTotalNPCQuestlinesCount}"
            If questlinesValueLabel.Text <> newQuestText Then
                questlinesValueLabel.Text = newQuestText
            End If
        End If
    End Sub

    Private Sub RenderQuestlinesDetail()
        detailHeaderLabel.Text = $"NPC Questlines        {Game.GetNPCQuestlinesCompleted} / {Game.GetTotalNPCQuestlinesCount}"

        detailTree.BeginUpdate()
        detailTree.Nodes.Clear()
        nodesByFlagId.Clear()

        Dim entries = Game.GetAllQuestlineEntries()
        Dim done = entries.Where(Function(e) e.Collected).Count()
        Dim catNode = New TreeNode(FormatCategoryText("NPC Questlines", done, entries.Count, True)) With {
            .ForeColor = System.Drawing.Color.White,
            .NodeFont = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold),
            .Tag = "NPC Questlines"
        }
        For Each e In entries
            Dim child = New TreeNode(FormatItemText(e.FlagId, e.Collected)) With {
                .ForeColor = If(e.Collected, CollectedItemColor, System.Drawing.Color.White),
                .NodeFont = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold),
                .Tag = e.FlagId
            }
            catNode.Nodes.Add(child)
            nodesByFlagId(e.FlagId) = child
        Next
        detailTree.Nodes.Add(catNode)
        catNode.Expand()
        detailTree.EndUpdate()
    End Sub

    Private Const ItemCheckedGlyph As String = "■  "
    Private Const ItemUncheckedGlyph As String = "□  "
    Private Const CategoryExpandedGlyph As String = "▼  "
    Private Const CategoryCollapsedGlyph As String = "▶  "

    Private Shared ReadOnly CollectedItemColor As System.Drawing.Color = System.Drawing.Color.FromArgb(150, 220, 150)

    Private Function FormatItemText(flagId As Integer, collected As Boolean) As String
        Dim prefix = If(collected, ItemCheckedGlyph, ItemUncheckedGlyph)
        Dim name As String = flagId.ToString()
        Dim found As String = Nothing
        If ItemNames.Names.TryGetValue(flagId, found) Then
            name = found
        ElseIf Dictionaries.sharedTreasureLocationItems.ContainsKey(flagId) Then
            Dim children = Dictionaries.sharedTreasureLocationItems.Item(flagId)
            For Each child In children
                If ItemNames.Names.TryGetValue(CInt(child), found) Then
                    name = found
                    Exit For
                End If
            Next
        End If
        Return prefix & name
    End Function

    Private Function FormatCategoryText(category As String, done As Integer, total As Integer, expanded As Boolean) As String
        Dim arrow = If(expanded, CategoryExpandedGlyph, CategoryCollapsedGlyph)
        Return arrow & category & "   (" & done & "/" & total & ")"
    End Function

    Private Sub RenderMapDetail(mapId As String)
        currentMapId = mapId
        Dim mapName = ""
        For Each item As ListViewItem In mapsListView.Items
            If TryCast(item.Tag, String) = mapId Then
                mapName = item.Text
                Exit For
            End If
        Next

        If mapId = QUESTLINES_MAPID Then
            RenderQuestlinesDetail()
            Return
        End If

        Dim total = Game.GetMapCompletion(mapId)
        detailHeaderLabel.Text = $"{mapName}  ({mapId})        {total.Done} / {total.Total}"

        detailTree.BeginUpdate()
        detailTree.Nodes.Clear()
        nodesByFlagId.Clear()

        For Each cat In DetailCategories
            Dim entries = Game.GetMapCategoryEntries(mapId, cat)
            If entries.Count = 0 Then Continue For

            Dim done = entries.Where(Function(e) e.Collected).Count()
            Dim isFirst = (detailTree.Nodes.Count = 0)
            Dim catNode = New TreeNode(FormatCategoryText(cat, done, entries.Count, isFirst)) With {
                .ForeColor = System.Drawing.Color.White,
                .NodeFont = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold),
                .Tag = cat
            }

            For Each e In entries
                Dim child = New TreeNode(FormatItemText(e.FlagId, e.Collected)) With {
                    .ForeColor = If(e.Collected, CollectedItemColor, System.Drawing.Color.White),
                    .NodeFont = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold),
                    .Tag = e.FlagId
                }
                catNode.Nodes.Add(child)
                nodesByFlagId(e.FlagId) = child
            Next

            detailTree.Nodes.Add(catNode)
        Next

        If detailTree.Nodes.Count > 0 Then
            detailTree.Nodes(0).Expand()
        End If

        detailTree.EndUpdate()
    End Sub

    Private Sub RefreshDetailLive()
        If String.IsNullOrEmpty(currentMapId) Then Return
        If detailTree.Nodes.Count = 0 Then Return

        For Each kvp In nodesByFlagId
            Dim flagId = kvp.Key
            Dim node = kvp.Value
            Dim collected As Boolean = False
            Dim parentCat = TryCast(node.Parent.Tag, String)
            If parentCat = "Treasure" Then
                collected = Game.IsTreasureCollected(flagId)
            ElseIf parentCat = "Non-Respawning Enemies" Then
                collected = Game.IsNonRespawningEnemyDead(flagId)
            ElseIf parentCat = "Kindled Bonfires" Then
                collected = Game.IsBonfireKindled(flagId)
            Else
                collected = Game.GetEventFlagState(flagId)
            End If

            Dim newText = FormatItemText(flagId, collected)
            If node.Text <> newText Then
                node.Text = newText
                node.ForeColor = If(collected, CollectedItemColor, System.Drawing.Color.White)
            End If
        Next

        For Each catNode As TreeNode In detailTree.Nodes
            Dim catName = TryCast(catNode.Tag, String)
            If catName Is Nothing Then Continue For
            Dim done = 0
            For Each child As TreeNode In catNode.Nodes
                If child.Text.StartsWith(ItemCheckedGlyph) Then done += 1
            Next
            Dim newCatText = FormatCategoryText(catName, done, catNode.Nodes.Count, catNode.IsExpanded)
            If catNode.Text <> newCatText Then catNode.Text = newCatText
        Next

        Dim newHeader As String
        If currentMapId = QUESTLINES_MAPID Then
            newHeader = $"NPC Questlines        {Game.GetNPCQuestlinesCompleted} / {Game.GetTotalNPCQuestlinesCount}"
        Else
            Dim mapName = ""
            For Each item As ListViewItem In mapsListView.Items
                If TryCast(item.Tag, String) = currentMapId Then
                    mapName = item.Text
                    Exit For
                End If
            Next
            Dim total = Game.GetMapCompletion(currentMapId)
            newHeader = $"{mapName}  ({currentMapId})        {total.Done} / {total.Total}"
        End If
        If detailHeaderLabel.Text <> newHeader Then detailHeaderLabel.Text = newHeader
    End Sub

    Private Sub mapsListView_SelectedIndexChanged(sender As Object, e As EventArgs) Handles mapsListView.SelectedIndexChanged
        If mapsListView.SelectedItems.Count = 0 Then Return
        Dim mapId = TryCast(mapsListView.SelectedItems(0).Tag, String)
        If Not String.IsNullOrEmpty(mapId) Then RenderMapDetail(mapId)
    End Sub

    Private Sub questlinesLabel_Click(sender As Object, e As EventArgs) Handles questlinesLabel.Click, questlinesValueLabel.Click
        mapsListView.SelectedItems.Clear()
        RenderMapDetail(QUESTLINES_MAPID)
    End Sub

    Private Sub SetCompactLabelsVisible(visible As Boolean)
        ' Titles (label side)
        treasureLocationsLabel.Visible = visible
        Label1.Visible = visible    ' Bosses
        Label2.Visible = visible    ' Non-respawning Enemies
        Label4.Visible = visible    ' NPC Questlines
        Label5.Visible = visible    ' Shortcuts / Locked Doors
        Label6.Visible = visible    ' Illusory Walls
        Label7.Visible = visible    ' Foggates
        Label8.Visible = visible    ' Kindled Bonfires

        ' Values
        treasureLocationsValueLabel.Visible = visible
        bossesKilledValueLabel.Visible = visible
        nonRespawningEnemiesValueLabel.Visible = visible
        npcQuestlinesValueLabel.Visible = visible
        shortcutsValueLabel.Visible = visible
        illusoryWallsValueLabel.Visible = visible
        foggatesValueLabel.Visible = visible
        bonfiresValueLabel.Visible = visible

        ' Global %
        percentageLabel.Visible = visible
    End Sub
    Private Sub runMode_Click(sender As Object, e As EventArgs) Handles runModeCheckbox.Click
        If (expandCheckbox.Checked) Then
            runModeCheckbox.Checked = False

            Return
        End If

    End Sub

    Private Sub AlwaysOnTopManagement(sender As Object, e As EventArgs)
        Me.TopMost = AlwaysOnTopCheckbox.Checked
    End Sub

    Private Sub hookTimer_Tick()
        If (_targetProcess Is Nothing) OrElse (_targetProcess.HasExited = True) Then
            If (_targetProcess IsNot Nothing) AndAlso (_targetProcess.HasExited = True) Then
                Dim thread = New Thread(AddressOf DoUnhookInOtherThread) With {.IsBackground = True}
                thread.Start()
                Return
            End If
            Dim newThread = New Thread(AddressOf HookInOtherThread) With {.IsBackground = True}
            newThread.Start()
        End If
    End Sub

    Private Sub unhook()
        isHooked = False
        updateTimer.Stop()
        Dim updateTimerTickEventHandler As New EventHandler(AddressOf updateTimer_Tick)
        RemoveHandler updateTimer.Tick, updateTimerTickEventHandler
        DetachFromProcess()
    End Sub

    Private Sub btnUnhook_Click(sender As Object, e As EventArgs)
        Dim newThread = New Thread(AddressOf DoUnhookInOtherThread) With {.IsBackground = True}
        newThread.Start()
    End Sub

    Private Sub DoUnhookInOtherThread()
        SetHookButtonsEnabled(False, False)
        unhook()
        SetHookButtonsEnabled(True, False)
    End Sub

    Private Sub RestartHook()
        DoUnhookInOtherThread()
        Dim newThread = New Thread(AddressOf HookInOtherThread) With {.IsBackground = True}
        newThread.Start()
    End Sub

    Private Sub UI_Exit(sender As Object, e As EventArgs) Handles MyBase.Closing
        hookTimer.Stop()
        Dim hookTimerTickEventHandler As New EventHandler(AddressOf hookTimer_Tick)
        RemoveHandler updateTimer.Tick, hookTimerTickEventHandler
        Dim newThread = New Thread(AddressOf unhook) With {.IsBackground = True}
        newThread.Start()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs)
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles treasureLocationsLabel.Click
    End Sub




    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
    End Sub

    Private Sub Label13_Click(sender As Object, e As EventArgs) Handles treasureLocationsValueLabel.Click
    End Sub

    Private Sub Label1_Click_1(sender As Object, e As EventArgs) Handles Label1.Click
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click
    End Sub

    Private Sub Label3_Click_1(sender As Object, e As EventArgs) Handles bonfiresValueLabel.Click
    End Sub

    Private Sub Label2_Click_1(sender As Object, e As EventArgs) Handles Label2.Click
    End Sub

    Private Sub Label3_Click_2(sender As Object, e As EventArgs) Handles Label3.Click
    End Sub

    Private Sub HookedLabel_Click(sender As Object, e As EventArgs) Handles HookedLabel.Click
    End Sub

End Class
