Imports DS_100PercentTracker.Main


Public Class Game


    Shared totalItemFlags As Array = {51000000, 51000010, 51000020, 51000030, 51000040, 51000050, 51000090, 51000100, 51000120, 51000140,
                                    51000170, 51000180, 51000190, 51000210, 51000240, 51000500, 51010000, 51010020, 51010040, 51010050,
                                    51010070, 51010080, 51010090, 51010100, 51010120, 51010140, 51010160, 51010210, 51010380, 51010400,
                                    51010130, 51010370, 51010430, 51010440, 51010470, 51010480, 51010490, 51010500, 51010510, 51010520,
                                    51010220, 51010260, 51010280, 51010300, 51010450, 51010460, 51020000, 51020010, 51020020, 51020030,
                                    51020040, 51020050, 51020060, 51020150, 51020160, 51020090, 51020170, 51020110, 51020120, 51020130,
                                    51020140, 51020210, 50001030, 51020070, 51020180, 51020190, 51020200, 51100010, 51100030,
                                    51100040, 51100050, 51100060, 51100070, 51100090, 51100100, 51100120, 51100130, 51100140, 51100150, 51100160,
                                    51100170, 51100190, 51100200, 51100210, 51100230, 51100240, 51100250, 51100260, 51100280, 51100290,
                                    51100300, 51100310, 51100320, 51100330, 51100340, 51100350, 51100370, 51100500, 51200030, 51200010,
                                    51200020, 51200040, 51200060, 51200070, 51200080, 51200180, 51200120, 51200150, 51200160, 51200170,
                                    51200190, 51200200, 51200210, 51200140, 51200500, 51200510, 51210010, 51210020, 51210030, 51210040,
                                    51210050, 51210060, 51210070, 51210080, 51210090, 51211000, 51210110, 51210160, 51210190, 51210210,
                                    51210220, 51210230, 51210240, 51210250, 51210260, 51210270, 51210280, 51210290, 51210300, 51210330,
                                    51210340, 51210350, 51210390, 51210400, 51210430, 51210440, 51210450, 51210460, 51210470, 51210500,
                                    51210510, 51210520, 51210540, 51210550, 51300000, 51300010, 51300020, 51300030, 51300070, 51300100,
                                    51300110, 51300140, 51300150, 51300190, 51300210, 51300220, 51300230, 51300240, 51300250, 51310000,
                                    51310010, 51310020, 51310030, 51310040, 51310050, 51310070, 51310080, 51310090, 51310100, 51310110,
                                    51310120, 51310140, 51310160, 51310180, 51310200, 51310220, 51310230, 51310240, 51310290, 51310300,
                                    51310500, 51320000, 51320020, 51320040, 51320050, 51320060, 51320070, 51320080, 51320090, 51320100,
                                    51320110, 51320120, 51320140, 51320150, 51320160, 51320170, 51320190, 51320180, 51400020, 51400040,
                                    51400050, 51400060, 51400080, 51400090, 51400100, 51400130, 51400140, 51400150, 51400160, 51400180,
                                    51400190, 51400210, 51400230, 51400250, 51400260, 51400270, 51400280, 51400290, 51400300, 51400310,
                                    51400320, 51400340, 51400350, 51400360, 51400370, 51400500, 51400510, 51400520, 51410000, 51410010,
                                    51410020, 51410030, 51410050, 51410060, 51410080, 51410090, 51410140, 51410160, 51410180, 51410230,
                                    51410250, 51410270, 51410310, 51410320, 51410330, 51410340, 51410360, 51410380, 51410390, 51410400,
                                    51410510, 51410530, 51410500, 51410100, 51410410, 51410520, 51500300, 51500310, 51500320, 51500330,
                                    51500350, 51500360, 51500400, 51500420, 51500070, 51500060, 51500010, 51500080, 51500150, 51500410,
                                    51500440, 51500000, 51500020, 51500040, 51500090, 51500100, 51510000, 51510030, 51510040, 51510050,
                                    51510060, 51510070, 51510080, 51510700, 51510510, 51510520, 51510530, 51510540, 51510570, 51510560,
                                    51510580, 51510590, 51510600, 51510610, 51510620, 51510660, 51510670, 51510680, 51510690, 51600000,
                                    51600020, 51600030, 51600040, 51600060, 51600070, 51600090, 51600100, 51600110, 51600120, 51600130,
                                    51600140, 51600150, 51600160, 51600170, 51600180, 51600190, 51600200, 51600210, 51600220, 51600250,
                                    51600260, 51600270, 51600280, 51600310, 51600330, 51600360, 51600370, 51600380, 51600520, 51600500,
                                    51600510, 51600290, 51700000, 51700010, 51700040, 51700060, 51700070, 51700080, 51700120, 51700150,
                                    51700160, 51700170, 51700180, 51700200, 51700210, 51700650, 51700510, 51700520, 51700530, 51700540,
                                    51700560, 51700580, 51700590, 51700600, 11510615, 51700630, 51700640, 51700020, 51700050, 51800050, 51810000,
                                    51810060, 51810070, 51810080, 50007020, 51700990 'Duke's Archives Tower Cell Key Serpent item flag
                                    }
    '51100980, 'Firesurge hollow item flag
    '51320990  'Stone Dragon Tail


    Shared totalBossFlags As Array = {2, 3, 4, 5, 6, 7, 9, 10, 11, 12, 13, 14,
                                    15, 16, 11210000, 11210001, 11210002, 11210004, 11410410,
                                    11410900, 11410901, 11510900, 11010901, 11010902, 11200900, 11810900}

    Shared totalNonRespawningEnemiesFlags As Array = {11010903, 11700815, 11700816, 11010861, 11300859, 11310820, 11810850, 11810851, 11200816, 11010862,
                                                    11000851, 11000852, 11700820, 11700821, 11000800, 11010860, 1062, 1034, 11410106, 11700810, 11010865,
                                                    11010863, 11200813, 11200814, 11200815, 11010900, 11200801, 11320100, 11400902, 11600850, 11600851,
                                                    11300858, 11500861, 11500862, 11500863, 11500864, 11510860, 11010864, 11100400, 11600810, 11500865,
                                                    11500867, 11515080, 11515081, 11410138, 11410139, 11410140, 11410141, 11410142, 11410143, 11410144,
                                                    11410109, 11410110, 11410111, 11410112, 11410113, 11410114, 11410115, 11410116, 11410117, 11410118,
                                                    11410119, 11410120, 11410121, 11410122, 11410123, 11410124, 11410125, 11410126, 11410127, 11410128,
                                                    11410129, 11410130, 11410131, 11410132, 11410133, 11410134, 11410135, 11410136, 11410137, 11510863, 11510864, 11500860, 11700822, 11700823, 800, 11000850, 11010866,
                                                    11210680, 11210681, 11500900, 11510850, 11510851, 11510852, 11510853, 11700900, 11700901, 11300850,
                                                    11300851, 11300852, 11300853, 11300854, 11300855, 11400850, 11400851, 11400852, 11400853, 11400854, 11400855,
                                                    11400856, 11400857, 11400858, 11200811, 11200810, 11010710, 11200812, 11210350, 11210351, 11210352,
                                                    11210353, 11210354, 11300856, 11300857, 11310821, 11410107, 11700811, 11700812, 11700813, 11700814,
                                                    11320301, 11320302, 11320303, 11320304, 11320305, 11320306, 11320307, 11320308, 11320309, 11320310,
                                                    11210310, 11210311, 11210312, 11210313, 11210314, 11210315, 11210355, 11410100, 11410101, 11410102,
                                                    11410103, 11410104}

    Shared totalNPCQuestlineFlags As Array = {11020101, 50000501, 1462, 1431, 1115, 1313, 1254, 1097, 1626,
                                            1177, 11200535, 11020606, 1012, 11210021, 11010700}
    'Logan Dead = 1097
    'Griggs Dead= 1115
    'Firekeeper Back to firelink = 11020101


    Shared totalShortcutsLockedDoorsFlags As Array = {11810105, 11600100, 11410340, 11210102, 11210122, 11210132, 11510251, 11510257, 11510220, 11510200,
                                                    11510210, 11020300, 11500100, 11500105, 11010101, 11010160, 11200110, 11600160, 11010100, 11700120,
                                                    11700110, 11300900, 11300901, 11300210, 11100135, 11100030, 11000100, 11010621, 'Shortcuts end here
                                                    11810103, 11810104, 11810106, 11810110, 11600120, 11700300, 11700301, 11700302, 11700303, 11700304,
                                                    11700305, 11700306, 11700140, 11000111, 11500110, 11500111, 11500112, 11500113, 11500115, 11500116, 11010171, 11600110, 11010140, 11010181,
                                                    11000120, 11010191, 11010192, 11010172, 11100120, 11210650, 11200111, 11500200 'Locked doors end here
                                                    }

    Shared totalIllusoryWallsFlags As Array = {11200120, 11300160, 11320200, 11320201, 11400210, 11510215, 11510401, 11410360, 11310100, 11210200,
                                            11210201, 11210025}

    Shared totalFoggatesFlags As Array = {11510090, 11510091, 11810090, 11010090, 11300090, 11310090, 11400091, 11500090, 11500091, 11010091,
                                        11320090, 11000090, 11200090, 11700083, 11100091, 11600090, 11600091, 11219114}

    Shared totalBonfireFlags As Array = {1801960, 1601961, 1601950, 1021960, 1301961, 1301960, 1011964, 1011962, 1011961, 1811961,
                                        1811960, 1201961, 1211964, 1211962, 1211961, 1211963, 1211950, 1411964, 1411963, 1411962,
                                        1411961, 1411960, 1411950, 1401962, 1401961, 1401960, 1321962, 1321961, 1321960, 1101960,
                                        1511950, 1511960, 1511961, 1511962, 1701950, 1701960, 1701961, 1701962, 1001960, 1501961,
                                        1311950, 1302962, 1311960, 1311961}




    Shared bossesKilled As Integer
    Shared nonRespawningEnemiesKilled As Integer
    Shared npcQuestlinesCompleted As Integer
    Shared itemsPickedUp As Integer
    Shared shortcutsLockedDoorsUnlocked As Integer
    Shared illusoryWallsRevealed As Integer
    Shared foggatesDissolved As Integer

    Shared kindledBonfires As Integer

    Shared npcDropsCollected As Integer
    Shared npcDropsTotal As Integer

    Shared totalTreasureLocationsCount As Integer
    Shared totalNonRespawningEnemiesCount As Integer

    Shared totalCompletionPercentage As Double

    ' Never change while process runs
    Private Shared _eventFlagPtrAddr As IntPtr = IntPtr.Zero
    Private Shared _charData2PtrAddr As IntPtr = IntPtr.Zero
    Private Shared _worldChrManPtrAddr As IntPtr = IntPtr.Zero
    Private Shared _netBonfireDbPtrAddr As IntPtr = IntPtr.Zero

    Public Shared Sub ResetCachedPointers()
        _eventFlagPtrAddr = IntPtr.Zero
        _charData2PtrAddr = IntPtr.Zero
        _worldChrManPtrAddr = IntPtr.Zero
        _netBonfireDbPtrAddr = IntPtr.Zero
    End Sub

    ' Bonfire stuff
    Private Shared Function GetNetBonfireDbPtr() As IntPtr
        If _netBonfireDbPtrAddr = IntPtr.Zero Then
            Dim instrAddr = ScanAOB("48 83 3D ? ? ? ? 00 48 8B F1")
            If instrAddr = IntPtr.Zero Then Return IntPtr.Zero
            Dim relOffset = RInt32(New IntPtr(instrAddr.ToInt64() + 3))
            _netBonfireDbPtrAddr = New IntPtr(instrAddr.ToInt64() + 8 + relOffset)
        End If
        Dim ptr1 = New IntPtr(RInt64(_netBonfireDbPtrAddr))
        If ptr1 = IntPtr.Zero Then Return IntPtr.Zero
        Return New IntPtr(RInt64(ptr1 + &HB68))
    End Function

    Public Shared Sub updateAllEventFlags()
        updateTreasureLocationsCount()
        updateDissolvedFoggatesCount()
        updateDefeatedBossesCount()
        updateRevealedIllusoryWallsCount()
        updateUnlockedShortcutsAndLockedDoorsCount()
        updateCompletedQuestlinesCount()
        updateKilledNonRespawningEnemiesCount()
        updateFullyKindledBonfires()
        updateBonfireKindleStateCache()

        updateCompletionPercentage()
    End Sub

    Public Shared bonfireKindleStateById As New Dictionary(Of Integer, Integer)

    Private Shared Sub updateBonfireKindleStateCache()
        bonfireKindleStateById.Clear()
        Dim netBonfireDb = GetNetBonfireDbPtr()
        If netBonfireDb = IntPtr.Zero Then Return

        Dim element = New IntPtr(RInt64(netBonfireDb + &H28))
        If element = IntPtr.Zero Then Return
        element = New IntPtr(RInt64(element))
        If element = IntPtr.Zero Then Return
        Dim bonfireItem = New IntPtr(RInt64(element + &H10))

        For i As Integer = 0 To 99
            If bonfireItem = IntPtr.Zero Then Exit For
            Dim bonfireID = RInt32(bonfireItem + &H8)
            If bonfireID = 0 Then Exit For
            Dim kindleState = RInt32(bonfireItem + &HC)
            bonfireKindleStateById(bonfireID) = kindleState
            element = New IntPtr(RInt64(element))
            If element = IntPtr.Zero Then Exit For
            bonfireItem = New IntPtr(RInt64(element + &H10))
        Next
    End Sub

    Public Shared Function GetMapIdFromFlag(flagId As Integer) As String
        Dim overrideMap As String = Nothing
        If Dictionaries.flagToMapOverride.TryGetValue(flagId, overrideMap) Then
            Return overrideMap
        End If

        Dim idString = flagId.ToString("D8")
        Dim area = idString.Substring(1, 3)
        If area = "000" Then Return ""
        Dim a1 = area.Substring(0, 2)
        Dim a2 = area.Substring(2, 1)
        Dim x As Integer
        If Not Integer.TryParse(a1, x) OrElse Not Integer.TryParse(a2, x) Then Return ""
        Return a1 & "_" & a2
    End Function

    ' Special Loot
    Public Shared Function IsTreasureCollected(flagId As Integer) As Boolean
        Dim checkFlag = flagId
        If Dictionaries.sharedTreasureLocationItems.ContainsKey(flagId) Then
            Dim values = Dictionaries.sharedTreasureLocationItems.Item(flagId)
            checkFlag = values(values.Length - 1)
        End If
        Return GetEventFlagState(checkFlag)
    End Function

    Public Shared Function IsNonRespawningEnemyDead(flagId As Integer) As Boolean
        If flagId = 11515080 Or flagId = 11515081 Then
            Return GetEventFlagState(11510400)
        End If
        Return GetEventFlagState(flagId)
    End Function

    Public Shared Function IsBonfireKindled(bonfireId As Integer) As Boolean
        Dim state As Integer = -1
        bonfireKindleStateById.TryGetValue(bonfireId, state)
        Return state = 40
    End Function

    Public Shared Function IsItemAvailable(flagId As Integer) As Boolean
        Dim required As Integer = 0
        If Dictionaries.itemSpawnPreconditions.TryGetValue(flagId, required) Then
            Return GetEventFlagState(required)
        End If
        Return True
    End Function

    ' Return Total for a Map XX_X
    Public Shared Function GetMapCompletion(mapId As String) As (Done As Integer, Total As Integer)
        Dim done As Integer = 0
        Dim total As Integer = 0

        ' Treasure
        For Each item In totalItemFlags
            If GetMapIdFromFlag(CInt(item)) <> mapId Then Continue For
            If Not IsItemAvailable(CInt(item)) Then Continue For
            total += 1
            If IsTreasureCollected(CInt(item)) Then done += 1
        Next

        ' Starting class items
        Dim startingClass = GetPlayerStartingClass()
        If startingClass <> PlayerStartingClass.None AndAlso Dictionaries.startingClassItems.ContainsKey(startingClass) Then
            For Each item In Dictionaries.startingClassItems.Item(startingClass)
                If GetMapIdFromFlag(CInt(item)) <> mapId Then Continue For
                total += 1
                If GetEventFlagState(CInt(item)) Then done += 1
            Next
        End If

        ' Bosses
        For Each item In totalBossFlags
            If GetMapIdFromFlag(CInt(item)) <> mapId Then Continue For
            total += 1
            If GetEventFlagState(CInt(item)) Then done += 1
        Next

        ' Non-respawning enemies
        For Each item In totalNonRespawningEnemiesFlags
            If GetMapIdFromFlag(CInt(item)) <> mapId Then Continue For
            total += 1
            If IsNonRespawningEnemyDead(CInt(item)) Then done += 1
        Next

        ' Hostile NPCs 
        For Each npc In Dictionaries.npcHostileDeadFlags
            Dim deadFlag = CInt(npc.GetValue(1))
            If GetMapIdFromFlag(deadFlag) <> mapId Then Continue For
            If GetEventFlagState(CInt(npc.GetValue(0))) Then
                total += 1
                If GetEventFlagState(deadFlag) Then done += 1
            ElseIf GetEventFlagState(deadFlag) Then
                total += 1
                done += 1
            End If
        Next

        ' Forest hunters if not in cov
        If GetEventFlagState(857) = False Then
            For Each hunterDead In Dictionaries.npcForestHunterFlags
                If GetMapIdFromFlag(hunterDead) <> mapId Then Continue For
                total += 1
                If GetEventFlagState(hunterDead) Then done += 1
            Next
        End If

        ' NPC zone drops (fixed location, active only)
        For Each pair As KeyValuePair(Of Integer, Array) In Dictionaries.npcZoneDroppedItems
            If GetEventFlagState(pair.Key) = False Then Continue For
            Dim drop = CInt(pair.Value(pair.Value.Length - 1))
            If GetMapIdFromFlag(drop) <> mapId Then Continue For
            total += 1
            If GetEventFlagState(drop) Then done += 1
        Next

        ' Shortcuts / Locked Doors
        For Each item In totalShortcutsLockedDoorsFlags
            If GetMapIdFromFlag(CInt(item)) <> mapId Then Continue For
            total += 1
            If GetEventFlagState(CInt(item)) Then done += 1
        Next

        ' Illusory Walls
        For Each item In totalIllusoryWallsFlags
            If GetMapIdFromFlag(CInt(item)) <> mapId Then Continue For
            total += 1
            If GetEventFlagState(CInt(item)) Then done += 1
        Next

        ' Foggates
        For Each item In totalFoggatesFlags
            If GetMapIdFromFlag(CInt(item)) <> mapId Then Continue For
            total += 1
            If GetEventFlagState(CInt(item)) Then done += 1
        Next

        ' Bonfires (kindled = state 40)
        For Each bID In totalBonfireFlags
            If GetMapIdFromFlag(CInt(bID)) <> mapId Then Continue For
            total += 1
            If IsBonfireKindled(CInt(bID)) Then done += 1
        Next

        Return (done, total)
    End Function


    Public Shared Function GetMapCategoryEntries(mapId As String, category As String) As List(Of (FlagId As Integer, Collected As Boolean))
        Dim result As New List(Of (FlagId As Integer, Collected As Boolean))

        Select Case category
            Case "Treasure"
                For Each item In totalItemFlags
                    If GetMapIdFromFlag(CInt(item)) <> mapId Then Continue For
                    If Not IsItemAvailable(CInt(item)) Then Continue For
                    result.Add((CInt(item), IsTreasureCollected(CInt(item))))
                Next
                ' Starting class items
                Dim startingClass = GetPlayerStartingClass()
                If startingClass <> PlayerStartingClass.None AndAlso Dictionaries.startingClassItems.ContainsKey(startingClass) Then
                    For Each item In Dictionaries.startingClassItems.Item(startingClass)
                        If GetMapIdFromFlag(CInt(item)) <> mapId Then Continue For
                        result.Add((CInt(item), GetEventFlagState(CInt(item))))
                    Next
                End If
                ' NPC zone drops (prob NU )
                For Each pair As KeyValuePair(Of Integer, Array) In Dictionaries.npcZoneDroppedItems
                    If GetEventFlagState(pair.Key) = False Then Continue For
                    Dim drop = CInt(pair.Value(pair.Value.Length - 1))
                    If GetMapIdFromFlag(drop) <> mapId Then Continue For
                    result.Add((drop, GetEventFlagState(drop)))
                Next
            Case "Bosses"
                For Each item In totalBossFlags
                    If GetMapIdFromFlag(CInt(item)) <> mapId Then Continue For
                    result.Add((CInt(item), GetEventFlagState(CInt(item))))
                Next

            Case "Non-Respawning Enemies"
                For Each item In totalNonRespawningEnemiesFlags
                    If GetMapIdFromFlag(CInt(item)) <> mapId Then Continue For
                    result.Add((CInt(item), IsNonRespawningEnemyDead(CInt(item))))
                Next
                For Each npc In Dictionaries.npcHostileDeadFlags
                    Dim deadFlag = CInt(npc.GetValue(1))
                    If GetMapIdFromFlag(deadFlag) <> mapId Then Continue For
                    If GetEventFlagState(CInt(npc.GetValue(0))) OrElse GetEventFlagState(deadFlag) Then
                        result.Add((deadFlag, GetEventFlagState(deadFlag)))
                    End If
                Next
                If GetEventFlagState(857) = False Then
                    For Each hunterDead In Dictionaries.npcForestHunterFlags
                        If GetMapIdFromFlag(hunterDead) <> mapId Then Continue For
                        result.Add((hunterDead, GetEventFlagState(hunterDead)))
                    Next
                End If

            Case "NPC Questlines"


            Case "Shortcuts / Locked Doors"
                For Each item In totalShortcutsLockedDoorsFlags
                    If GetMapIdFromFlag(CInt(item)) <> mapId Then Continue For
                    result.Add((CInt(item), GetEventFlagState(CInt(item))))
                Next

            Case "Illusory Walls"
                For Each item In totalIllusoryWallsFlags
                    If GetMapIdFromFlag(CInt(item)) <> mapId Then Continue For
                    result.Add((CInt(item), GetEventFlagState(CInt(item))))
                Next

            Case "Foggates"
                For Each item In totalFoggatesFlags
                    If GetMapIdFromFlag(CInt(item)) <> mapId Then Continue For
                    result.Add((CInt(item), GetEventFlagState(CInt(item))))
                Next

            Case "Kindled Bonfires"
                For Each bID In totalBonfireFlags
                    If GetMapIdFromFlag(CInt(bID)) <> mapId Then Continue For
                    result.Add((CInt(bID), IsBonfireKindled(CInt(bID))))
                Next
        End Select

        Return result
    End Function


    Public Shared Function GetAllQuestlineEntries() As List(Of (FlagId As Integer, Collected As Boolean))
        Dim result As New List(Of (FlagId As Integer, Collected As Boolean))
        For Each item In totalNPCQuestlineFlags
            Dim flag = CInt(item)
            Dim collected As Boolean
            If flag = 1012 Then
                collected = GetEventFlagState(1011) OrElse GetEventFlagState(1012)
            ElseIf flag = 11200535 Then
                collected = GetEventFlagState(1604) OrElse GetEventFlagState(11200535)
            Else
                collected = GetEventFlagState(flag)
            End If
            result.Add((flag, collected))
        Next
        Return result
    End Function

    Public Shared Function GetAllNpcDropEntries() As List(Of (FlagId As Integer, Collected As Boolean))
        Dim result As New List(Of (FlagId As Integer, Collected As Boolean))
        For Each pair As KeyValuePair(Of Integer, Array) In Dictionaries.npcDroppedItems
            If GetEventFlagState(pair.Key) = False Then Continue For
            Dim drop = CInt(pair.Value(pair.Value.Length - 1))
            result.Add((drop, GetEventFlagState(drop)))
        Next
        Return result
    End Function

    Public Shared ReadOnly Property GetNpcDropsCollected() As Integer
        Get
            Return npcDropsCollected
        End Get
    End Property

    Public Shared ReadOnly Property GetTotalNpcDropsCount() As Integer
        Get
            Return npcDropsTotal
        End Get
    End Property

    Private Shared Sub updateFullyKindledBonfires()
        Dim netBonfireDb = GetNetBonfireDbPtr()
        If netBonfireDb = IntPtr.Zero Then Return

        Dim element = New IntPtr(RInt64(netBonfireDb + &H28))
        If element = IntPtr.Zero Then Return
        element = New IntPtr(RInt64(element))
        If element = IntPtr.Zero Then Return
        Dim bonfireItem = New IntPtr(RInt64(element + &H10))

        kindledBonfires = 0
        For i As Integer = 0 To 99
            If bonfireItem = IntPtr.Zero Then Exit For

            Dim bonfireID = RInt32(bonfireItem + &H8)
            If bonfireID = 0 Then Exit For

            Dim kindleState = RInt32(bonfireItem + &HC)
            If kindleState = 40 Then kindledBonfires += 1

            element = New IntPtr(RInt64(element))
            If element = IntPtr.Zero Then Exit For
            bonfireItem = New IntPtr(RInt64(element + &H10))
        Next
    End Sub


    Private Shared Sub updateTreasureLocationsCount()
        Dim value As Boolean
        totalTreasureLocationsCount = totalItemFlags.Length
        itemsPickedUp = 0
        npcDropsTotal = 0
        npcDropsCollected = 0

        For Each item In totalItemFlags
            Dim originalItem = item
            If Dictionaries.sharedTreasureLocationItems.ContainsKey(item) Then
                Dim values = Dictionaries.sharedTreasureLocationItems.Item(item)
                item = values(values.Length - 1)
            End If
            value = GetEventFlagState(item)
            If value = True Then
                itemsPickedUp += 1
            End If
        Next

        Dim startingClass = GetPlayerStartingClass()
        If startingClass <> PlayerStartingClass.None AndAlso Dictionaries.startingClassItems.ContainsKey(startingClass) Then
            Dim startingItemFlags = Dictionaries.startingClassItems.Item(startingClass)
            For Each item In startingItemFlags
                value = GetEventFlagState(item)
                If value = True Then
                    itemsPickedUp += 1
                End If
            Next
            totalTreasureLocationsCount += startingItemFlags.Length
        End If

        For Each pair As KeyValuePair(Of Integer, Array) In Dictionaries.npcDroppedItems
            value = GetEventFlagState(pair.Key)
            If value = True Then
                totalTreasureLocationsCount += 1
                npcDropsTotal += 1
                Dim item = pair.Value(pair.Value.Length - 1)
                value = GetEventFlagState(item)
                If value = True Then
                    itemsPickedUp += 1
                    npcDropsCollected += 1
                End If
            End If
        Next

        For Each pair As KeyValuePair(Of Integer, Array) In Dictionaries.npcZoneDroppedItems
            value = GetEventFlagState(pair.Key)
            If value = True Then
                totalTreasureLocationsCount += 1
                Dim item = pair.Value(pair.Value.Length - 1)
                value = GetEventFlagState(item)
                If value = True Then
                    itemsPickedUp += 1
                End If
            End If
        Next
    End Sub


    Private Shared Sub updateDissolvedFoggatesCount()
        Dim value As Boolean
        foggatesDissolved = 0
        For Each item In totalFoggatesFlags
            value = GetEventFlagState(item)
            If value = True Then foggatesDissolved += 1
        Next
    End Sub

    Private Shared Sub updateDefeatedBossesCount()
        Dim value As Boolean
        bossesKilled = 0
        For Each item In totalBossFlags
            value = GetEventFlagState(item)
            If value = True Then bossesKilled += 1
        Next
    End Sub

    Private Shared Sub updateRevealedIllusoryWallsCount()
        Dim value As Boolean
        illusoryWallsRevealed = 0
        For Each item In totalIllusoryWallsFlags
            value = GetEventFlagState(item)
            If value = True Then illusoryWallsRevealed += 1
        Next
    End Sub

    Private Shared Sub updateUnlockedShortcutsAndLockedDoorsCount()
        Dim value As Boolean
        shortcutsLockedDoorsUnlocked = 0
        For Each item In totalShortcutsLockedDoorsFlags
            value = GetEventFlagState(item)
            If value = True Then shortcutsLockedDoorsUnlocked += 1
        Next
    End Sub

    Private Shared Sub updateCompletedQuestlinesCount()
        Dim value As Boolean
        npcQuestlinesCompleted = 0
        For Each item In totalNPCQuestlineFlags
            value = GetEventFlagState(item)
            If value = True Then
                npcQuestlinesCompleted += 1
            ElseIf item = 1012 Then
                value = GetEventFlagState(1011)
                If value = True Then npcQuestlinesCompleted += 1
            ElseIf item = 11200535 Then
                value = GetEventFlagState(1604)
                If value = True Then npcQuestlinesCompleted += 1
            End If
        Next
    End Sub

    Private Shared Sub updateKilledNonRespawningEnemiesCount()
        Dim value As Boolean
        totalNonRespawningEnemiesCount = totalNonRespawningEnemiesFlags.Length
        nonRespawningEnemiesKilled = 0

        For Each item In totalNonRespawningEnemiesFlags
            If item = 11515080 Or item = 11515081 Then
                value = GetEventFlagState(11510400)
                If value = True Then
                    nonRespawningEnemiesKilled += 1
                    Continue For
                End If
            End If
            value = GetEventFlagState(item)
            If value = True Then nonRespawningEnemiesKilled += 1
        Next

        For Each npc In Dictionaries.npcHostileDeadFlags
            If GetEventFlagState(npc.GetValue(0)) = True Then
                totalNonRespawningEnemiesCount += 1
            ElseIf GetEventFlagState(npc.GetValue(1)) = True Then
                totalNonRespawningEnemiesCount += 1
                nonRespawningEnemiesKilled += 1
            End If
        Next

        If GetEventFlagState(857) = False Then
            For Each hunterDead In Dictionaries.npcForestHunterFlags
                If GetEventFlagState(hunterDead) = False Then
                    totalNonRespawningEnemiesCount += 1
                Else
                    totalNonRespawningEnemiesCount += 1
                    nonRespawningEnemiesKilled += 1
                End If
            Next
        End If
    End Sub

    Private Shared Sub updateCompletionPercentage()
        Dim itemPercentage As Double = itemsPickedUp * (0.2 / totalTreasureLocationsCount)
        Dim bossPercentage As Double = bossesKilled * (0.25 / totalBossFlags.Length)
        Dim nonrespawningPercentage As Double = nonRespawningEnemiesKilled * (0.15 / totalNonRespawningEnemiesCount)
        Dim questlinesPercentage As Double = npcQuestlinesCompleted * (0.2 / totalNPCQuestlineFlags.Length)
        Dim shortcutsLockedDoorsPercentage As Double = shortcutsLockedDoorsUnlocked * (0.1 / totalShortcutsLockedDoorsFlags.Length)
        Dim illusoryWallsPercentage As Double = illusoryWallsRevealed * (0.025 / totalIllusoryWallsFlags.Length)
        Dim foggatesPercentage As Double = foggatesDissolved * (0.025 / totalFoggatesFlags.Length)
        Dim bonfiresPercentage As Double = kindledBonfires * (0.05 / totalBonfireFlags.Length)

        totalCompletionPercentage = itemPercentage + bossPercentage + nonrespawningPercentage + questlinesPercentage + shortcutsLockedDoorsPercentage + illusoryWallsPercentage + foggatesPercentage + bonfiresPercentage
        totalCompletionPercentage = Math.Floor(totalCompletionPercentage * 1000)
        totalCompletionPercentage /= 10
    End Sub

    Public Shared Function GetEventFlagAddress(eventID As Integer, ByRef mask As UInteger) As Long
        Dim idString As String = eventID.ToString("D8")
        If idString.Length = 8 Then
            Dim group = idString.Substring(0, 1)
            Dim area = idString.Substring(1, 3)
            Dim section = Int32.Parse(idString.Substring(4, 1))
            Dim number = Int32.Parse(idString.Substring(5, 3))

            If Dictionaries.eventFlagGroups.Keys.Contains(group) And Dictionaries.eventFlagAreas.Keys.Contains(area) Then
                Dim offset = Dictionaries.eventFlagGroups.Item(group)
                offset += Dictionaries.eventFlagAreas.Item(area) * &H500
                offset += section * 128
                offset += (number - (number Mod 32)) / 8

                mask = &H80000000UI >> (number Mod 32)
                Return eventFlagPtr + offset
            End If
        End If

        Throw New Exception()
    End Function

    Public Shared Function GetEventFlagState(eventID As Integer) As Boolean
        Dim mask As UInteger
        Dim address As Long = GetEventFlagAddress(eventID, mask)
        Return ReadFlag32(address, mask)
    End Function

    Public Shared Function IsPlayerLoaded() As Boolean
        Dim worldChrMan = GetOnlineInfoPtr()
        If worldChrMan = IntPtr.Zero Then Return True
        Return RInt64(worldChrMan + &H68) <> 0
    End Function

    Public Shared Function isPlayerInOwnWorld() As Boolean
        Return eventFlagPtr <> 0
    End Function

    Public Shared Function GetPlayerStartingClass() As PlayerStartingClass
        Dim ptr = GetCharData2Ptr()
        If ptr = IntPtr.Zero Then Return PlayerStartingClass.None
        Dim subPtr = New IntPtr(RInt64(ptr + &H10))
        If subPtr = IntPtr.Zero Then Return PlayerStartingClass.None
        Return CType(RBytes(subPtr + &HCE, 1)(0), PlayerStartingClass)
    End Function

    Private Shared Function GetPlayerCharacterType() As PlayerCharacterType
        If IsPlayerLoaded() Then Return PlayerCharacterType.Human
        Return PlayerCharacterType.Hollow
    End Function

    Private Shared Function GetOnlineInfoPtr() As IntPtr
        If _worldChrManPtrAddr = IntPtr.Zero Then
            _worldChrManPtrAddr = ResolveRelativeAOB("48 8B 05 ? ? ? ? 48 8B 48 68 48 85 C9 0F 84 ? ? ? ? 48 39 5E 10 0F 84 ? ? ? ? 48")
        End If
        If _worldChrManPtrAddr = IntPtr.Zero Then Return IntPtr.Zero
        Return New IntPtr(RInt64(_worldChrManPtrAddr))
    End Function

    Private Shared Function GetPlayerStructPtr() As IntPtr
        Dim worldChrMan = GetOnlineInfoPtr()
        If worldChrMan = IntPtr.Zero Then Return IntPtr.Zero
        Return New IntPtr(RInt64(worldChrMan + &H68))
    End Function

    Public Shared Function GetClearCount() As Integer
        Dim ptr = GetCharData2Ptr()
        If ptr = IntPtr.Zero Then Return 0
        Return RInt32(ptr + &H3C)
    End Function

    Public Shared Function GetIngameTimeInMilliseconds() As Integer
        Dim ptr = GetCharData2Ptr()
        If ptr = IntPtr.Zero Then Return 0
        Return RInt32(ptr + &H68)
    End Function

    Public Shared Function GetCharData2Ptr() As IntPtr
        If _charData2PtrAddr = IntPtr.Zero Then
            _charData2PtrAddr = ResolveRelativeAOB("48 8B 05 ? ? ? ? 48 85 C0 ? ? F3 0F 58 80 AC 00 00 00")
        End If
        If _charData2PtrAddr = IntPtr.Zero Then Return IntPtr.Zero
        Return New IntPtr(RInt64(_charData2PtrAddr))
    End Function


    Public Shared Function GetEventFlagPtr() As Long
        If _eventFlagPtrAddr = IntPtr.Zero Then
            _eventFlagPtrAddr = ResolveRelativeAOB("48 8B 0D ? ? ? ? 99 33 C2 45 33 C0 2B C2 8D 50 F6")
        End If
        If _eventFlagPtrAddr = IntPtr.Zero Then Return 0
        Dim firstPtr = RInt64(_eventFlagPtrAddr)
        If firstPtr = 0 Then Return 0
        Return RInt64(New IntPtr(firstPtr))
    End Function

    Public Shared ReadOnly Property GetBossesKilled() As Integer
        Get
            Return bossesKilled
        End Get
    End Property

    Public Shared ReadOnly Property GetNonRespawningEnemiesKilled() As Integer
        Get
            Return nonRespawningEnemiesKilled
        End Get
    End Property

    Public Shared ReadOnly Property GetNPCQuestlinesCompleted() As Integer
        Get
            Return npcQuestlinesCompleted
        End Get
    End Property
    Public Shared ReadOnly Property GetTreasureLocationsCleared As Integer
        Get
            Return itemsPickedUp
        End Get
    End Property
    Public Shared ReadOnly Property GetShortcutsAndLockedDoorsUnlocked() As Integer
        Get
            Return shortcutsLockedDoorsUnlocked
        End Get
    End Property
    Public Shared ReadOnly Property GetIllusoryWallsRevealed() As Integer
        Get
            Return illusoryWallsRevealed
        End Get
    End Property

    Public Shared ReadOnly Property GetFoggatesDissolved() As Integer
        Get
            Return foggatesDissolved
        End Get
    End Property

    Public Shared ReadOnly Property GetBonfiresFullyKindled() As Integer
        Get
            Return kindledBonfires
        End Get
    End Property
    Public Shared ReadOnly Property GetTotalBossCount() As Integer
        Get
            Return totalBossFlags.Length
        End Get
    End Property

    Public Shared ReadOnly Property GetTotalNonRespawningEnemiesCount() As Integer
        Get
            Return totalNonRespawningEnemiesCount
        End Get
    End Property

    Public Shared ReadOnly Property GetTotalNPCQuestlinesCount() As Integer
        Get
            Return totalNPCQuestlineFlags.Length
        End Get
    End Property
    Public Shared ReadOnly Property GetTotalTreasureLocationsCount As Integer
        Get
            Return totalTreasureLocationsCount
        End Get
    End Property
    Public Shared ReadOnly Property GetTotalShortcutsAndLockedDoorsCount() As Integer
        Get
            Return totalShortcutsLockedDoorsFlags.Length
        End Get
    End Property
    Public Shared ReadOnly Property GetTotalIllusoryWallsCount() As Integer
        Get
            Return totalIllusoryWallsFlags.Length
        End Get
    End Property

    Public Shared ReadOnly Property GetTotalFoggatesCount() As Integer
        Get
            Return totalFoggatesFlags.Length
        End Get
    End Property

    Public Shared ReadOnly Property GetTotalBonfiresCount() As Integer
        Get
            Return totalBonfireFlags.Length
        End Get
    End Property

    Public Shared ReadOnly Property GetTotalCompletionPercentage() As Double
        Get
            Return totalCompletionPercentage
        End Get
    End Property
End Class
