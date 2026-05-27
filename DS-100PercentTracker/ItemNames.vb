Public Class ItemNames

    Public Shared Names As Dictionary(Of Integer, String)

    Shared Sub New()
        Names = New Dictionary(Of Integer, String)()
        ' ============================================================
        ' === Undead Asylum (18_1)
        ' ============================================================
        ' --- Treasure ---
        Names.Add(51810000, "Dungeon Cell Key")
        Names.Add(51810060, "Rusted Iron Ring")
        Names.Add(51810070, "Soul of a lost Undead")
        Names.Add(51810080, "Peculiar Doll")
        Names.Add(50007020, "Crest Shield (drop from Oscar)")
        Names.Add(51810110, "1st starting class item as warrior")
        Names.Add(51810100, "2nd starting class item as warrior")
        Names.Add(51810130, "1st starting class item as knight")
        Names.Add(51810120, "2nd starting class item as knight")
        Names.Add(51810150, "1st starting class item as Wanderer")
        Names.Add(51810140, "2nd starting class item as Wanderer")
        Names.Add(51810170, "1st starting class item as thief")
        Names.Add(51810160, "2nd starting class item as thief")
        Names.Add(51810190, "1st starting class item as Bandit")
        Names.Add(51810180, "2nd starting class item as Bandit")
        Names.Add(51810210, "1st starting class item as Hunter")
        Names.Add(51810200, "2nd starting class item as Hunter")
        Names.Add(51810220, "3rd starting class item as Hunter")
        Names.Add(18101240, "1st starting class item as Sorcerer")
        Names.Add(51810230, "2nd starting class item as Sorcerer")
        Names.Add(51810250, "3rd starting class item as Sorcerer")
        Names.Add(51810270, "1st starting class item as Pyromancer")
        Names.Add(51810260, "2nd starting class item as Pyromancer")
        Names.Add(51810280, "3rd starting class item as Pyromancer")
        Names.Add(51810300, "1st starting class item as Cleric")
        Names.Add(51810290, "2nd starting class item as Cleric")
        Names.Add(51810310, "3rd starting class item as Cleric")
        Names.Add(51810330, "1st starting class item as Deprived")
        Names.Add(51810320, "2nd starting class item as Deprived")
        ' --- Bosses ---
        Names.Add(16, "Asylum Demon")
        Names.Add(11810900, "Stray Demon")
        ' --- Non-Respawning Enemies ---
        Names.Add(11810850, "Black Knight just before Peculiar Doll")
        Names.Add(11810851, "Black Knight just after starting Class items")
        Names.Add(11810532, "Oscar")
        ' --- Shortcuts / Locked Doors ---
        Names.Add(11810103, "Cell Door")
        Names.Add(11810104, "F2 West Door")
        Names.Add(11810105, "Shortcut Door leading to 1st bonfire")
        Names.Add(11810106, "F2 East Door")
        Names.Add(11810110, "Big Pilgrim Door")
        ' --- Foggates ---
        Names.Add(11810090, "Just before Oscar")
        ' --- Kindled Bonfires ---
        Names.Add(1811960, "Bonfire in courtyard")
        Names.Add(1811961, "Second Bonfire")
        ' ============================================================
        ' === Firelink Shrine (10_2)
        ' ============================================================
        ' --- Treasure ---
        Names.Add(51020000, "Humanity (on the well)")
        Names.Add(51020010, "Large Soul of a lost Undead (Graveyard)")
        Names.Add(51020020, "Caduceus Round Shield (Graveyard)")
        Names.Add(51020030, "Large Soul of a lost Undead (Graveyard)")
        Names.Add(51020050, "Soul of a lost undead (on the F2 above basin)")
        Names.Add(51020060, "Soul of a lost undead (next to the elevator leading to Parish)")
        Names.Add(51020070, "Chest containing 4 Lloyd's Talismans")
        Names.Add(51020090, "Soul of a lost undead (Hidded in a corner next to the basin)")
        Names.Add(51020110, "6 Firebombs")
        Names.Add(51020150, "Zweihander (Graveyard)")
        Names.Add(51020160, "Winged Spear (Graveyard)")
        Names.Add(51020170, "Binoculars (Graveyard)")
        Names.Add(51020180, "Chest containing Morning Star & Talisman")
        Names.Add(51020190, "Chest containing 6 Homeward Bones")
        Names.Add(51020200, "Chest containing Cracked Red Eye Orb")
        Names.Add(51020210, "Undead Asylum F2 West Key")
        Names.Add(51020120, "Soul of a lost Undead (next to the bridge with Ring of Sacrifice)")
        Names.Add(51020130, "Ring of Sacrifice")
        Names.Add(51020040, "Soul of a lost Undead (Above the bridge with Ring of Sacrifice)")
        Names.Add(50001031, "Firekeeper Set & Black Eye Orb")
        ' --- Kindled Bonfires ---
        Names.Add(1021960, "Firelink Bonfire")

        ' --- Shortcut --- '
        Names.Add(11020300, "Elevator Leading to Parish")
        ' ============================================================
        ' === Undead Burg (10_1)
        ' ============================================================
        ' --- Treasure ---
        '---Undead Burg---'
        Names.Add(51010070, "Large Soul of a lost Undead, After you break the barrels before the foggate")
        Names.Add(51010440, "Soul of a lost Undead, right after the foggate")
        Names.Add(51010080, "Rubbish")
        Names.Add(51010090, "Light Crossbow")
        Names.Add(51010100, "Humanity (on the bridge before the foggate)")
        Names.Add(51010120, "10 Throwing Knifes")
        Names.Add(51020140, "Soul of a lost Undead (behind the rat on the tunnel leading to female undead merchant)")
        Names.Add(51010400, "Soul of a lost Undead (on a small room leading to rubbish)")
        Names.Add(51010130, "Wooden Shield")
        Names.Add(51010160, "Blue Tearstone Ring")
        Names.Add(51010470, "Soul of a lost undead (on top of the room with the chest containing 5 black firebombs)")
        Names.Add(51010450, "Chest containing 5 Black Firebombs")
        Names.Add(51010460, "Chest containing 3 gold pine resins")
        Names.Add(51010480, "Large soul of a lost undead (right after taurus demon , hidded in a box)")
        Names.Add(51010210, "Claymore")
        Names.Add(51010220, "Soul of a nameless soldier (hellkite bridge)")
        '---Lower Burg---'
        Names.Add(51010490, "Twin Humanity")
        Names.Add(51010511, "Sorcerer set & Catalyst (Griggs Room)")
        Names.Add(51010020, "Mail Breaker")
        Names.Add(51010381, "Thief set & Target Shield")
        Names.Add(51010370, "Large soul of a lost undead (corpse in a barrel, lower burg)")
        Names.Add(51010430, "Large soul of a lost undead (right before depths door)")
        '---Undead Parish---'
        Names.Add(51010140, "Basement Key")
        Names.Add(51010520, "Halberd")
        Names.Add(51010300, "Knight Shield")
        Names.Add(51010260, "4 alluring skulls")
        Names.Add(51010000, "Mistery Key")
        Names.Add(51010280, "Large soul of a lost undead (on a beam, above mistery key)")
        Names.Add(51010050, "Fire keeper soul")
        Names.Add(51010500, "Large Soul of a nameless soldier (Parish Church next to the channelers)")
        Names.Add(51010040, "Humanity (Corpse in a barrel, Parish Church)")
        ' --- Bosses ---
        '---Undead Burg---'
        Names.Add(11010901, "Taurus Demon")
        '---Lower Burg---'

        Names.Add(11010902, "Capra Demon")
        '---Undead Parish---'
        Names.Add(3, "Gargoyles Dead")
        ' --- Non-Respawning Enemies ---
        '---Undead Burg---'
        Names.Add(11010861, "Black Knight Sword Guy (Undead Burg)")
        Names.Add(11010710, "Titanite (hidded on a barrel right before Taurus Demon)")
        Names.Add(11010900, "Hellkite Drake")
        Names.Add(11010860, "Havel")
        '---Undead Parish---'
        Names.Add(11010862, "Black Knight Greatsword guy (Undead Burg)")
        Names.Add(11010863, "Berenice Knight (Parish Church)")
        Names.Add(11010865, "Channeler (Parish Church)")
        Names.Add(11010864, "Titanite Demon (Next to Andre)")
        Names.Add(11010903, "Boar")
        Names.Add(11010866, "Hollow that pull lever next to the boar")
        ' --- Shortcuts / Locked Doors ---
        '---Undead Burg---'
        Names.Add(11010101, "Shortcut leading to Female Undead merchant")
        Names.Add(11010160, "Shortcut linking Lower undead Burg to undead burg")
        Names.Add(11010140, "Shortcut leading to Chest containing 3 gold pine resins")
        Names.Add(11010191, "Havel's tower (upper door)")
        Names.Add(11010192, "Havel's tower (lower door)")
        Names.Add(11010172, "Locked door linking Hellkite bridge to lower undead burg")
        Names.Add(11010100, "Ladder Kick linking hellkite bridge to undead burg bonfire")
        '---Lower Burg---'
        Names.Add(11010181, "Griggs Room")
        Names.Add(11010171, "depths door")
        Names.Add(11010621, "Gate right after sunlight altar bonfire")
        '---Undead Parish---'
        Names.Add(11010300, "elevator linkink parish to Firelink")
        ' --- Foggates ---
        '---Undead Burg---'
        Names.Add(11010090, "First foggate of the area")
        '---Undead Parish---'
        Names.Add(11010091, "Fog on top of room guarding mistery key")
        ' --- Kindled Bonfires ---
        '---Undead Burg---'
        Names.Add(1011962, "Undead Burg")
        '---Undead Parish---'
        Names.Add(1011961, "Sunlight Altar")
        Names.Add(1011964, "Undead Parish")
        ' ============================================================
        ' === Darkroot (12_0)
        ' ============================================================
        ' --- Treasure ---
        '---Basin---'
        Names.Add(51200040, "Large soul of a nameless solider (next to blue golems)")
        Names.Add(51200210, "Knight set (next to hydra)")
        Names.Add(51200200, "Grass Crest Shield")
        Names.Add(51200021, "Leather set + Longbow")
        '---Garden---'
        Names.Add(51200180, "Soul of a Proud Knight (next to a group with 4 frogs)")
        Names.Add(51200060, "Wolf Ring")
        Names.Add(51200030, "Large soul of a nameless solider (right before Darkroot garden bonfire)")
        Names.Add(51200080, "Eastern set")
        Names.Add(51200510, "Chest containing stone armor")
        Names.Add(51200500, "Chest containing enchanted ember")
        Names.Add(51200120, "Large soul of a brave warrior (right before the giant cats)")
        Names.Add(51200190, "Soul of a brave warrior (right before ladder leading to hydra)")
        Names.Add(51200170, "Large soul of a nameless soldier (between 3 tree guys)")
        Names.Add(51200010, "Partizan")
        Names.Add(51200070, "Elite Knight set")
        Names.Add(51200142, "Andre right after Butterlfy")
        Names.Add(51200160, "Hornet Ring")
        Names.Add(51200150, "Dusk set")
        ' --- Bosses ---
        '---Garden---'
        Names.Add(11200900, "Buttefly")
        Names.Add(5, "Sif")
        ' --- Non-Respawning Enemies ---
        '---Basin---'
        Names.Add(11200801, "Darkroot Hydra")
        Names.Add(11200816, "BKH Guy")
        Names.Add(11200812, "Titanite after GCC (before Darkroot garden)")
        '---Garden---'
        Names.Add(11200811, "Possessed Tree (right before a group with 4 frogs)")
        Names.Add(11200810, "Possessed Tree (directly on the right when you enter butterfly area)")
        Names.Add(11200813, "Giant cat")
        Names.Add(11200814, "Giant cat")
        Names.Add(11200815, "Giant cat")
        Names.Add(11200817, "Consistent Knight")
        Names.Add(11200819, "Consistent Knight")
        Names.Add(11200818, "Pharis")
        ' --- Shortcuts / Locked Doors ---
        '---Garden---'
        Names.Add(11200110, "Crest of artorias door")
        Names.Add(11200111, "Sif door")
        ' --- Illusory Walls ---
        '---Garden---'
        Names.Add(11200120, "Hiding Darkroot garden bonfire")
        ' --- Foggates ---
        '---Garden---'
        Names.Add(11200090, "Opening Butterfly area")
        ' --- Kindled Bonfires ---
        '---Basin---'
        Names.Add(1601961, "Darkroot basin")
        '---Garden---'
        Names.Add(1201961, "Darkroot garden")
        ' ============================================================
        ' === Depths (10_0)
        ' ============================================================
        ' --- Treasure ---
        Names.Add(51000040, "Soul of a nameless soldier (right after the entrance)")
        Names.Add(51000500, "Chest containing large ember")
        Names.Add(51000090, "Spider shield (on the ledge after butcher)")
        Names.Add(51000140, "Soul of a nameless soldier (in Giant Rat room)")
        Names.Add(51000240, "Sewer Chamber Key")
        Names.Add(51000120, "Soul of a nameless soldier (on the corridor, leaving giant rat room)")
        Names.Add(51000050, "Large Soul of a nameless soldier (next to 3 basilisks)")
        Names.Add(51000170, "Ring of evil eye")
        Names.Add(51000180, "Soul of a nameless soldier (on the corridor next to 2 basilisks)")
        Names.Add(51000010, "Soul of a nameless soldier (right before the fog leading to the channeler)")
        Names.Add(51000100, "Large Titanite shard (right affter channeler)")
        Names.Add(51000000, "Humanity (at the end of a corridor, dead end)")
        Names.Add(51000020, "Greataxe")
        Names.Add(51000190, "Heavy Crossbow")
        Names.Add(51000210, "Hard Leather set (gaping dragon arena)")
        Names.Add(51000030, "Soul of a nameless soldier (trapped by a mob that fall on you)")
        ' --- Bosses ---
        Names.Add(2, "Gaping Dragon")
        ' --- Non-Respawning Enemies ---
        Names.Add(11000850, "Dog next to large ember chest")
        Names.Add(11000851, "Butcher next to large ember chest")
        Names.Add(11000852, "Butcher right before Laurentius room")
        Names.Add(11000800, "Giant Rat")
        ' --- Shortcuts / Locked Doors ---
        Names.Add(11000120, "Locked door leading to the bonfire")
        Names.Add(11000100, "Locked door at the end of a corridor (leading to a ladder that lead to the bonfire)")
        Names.Add(11000111, "Locked door leading to Blighttown")
        ' --- Foggates ---
        Names.Add(11000090, "Fog leading to channeler")
        ' --- Kindled Bonfires ---
        Names.Add(1001960, "Depths Bonfire")
        ' ============================================================
        ' === Painted World (11_0)
        ' ============================================================
        ' --- Treasure ---
        Names.Add(51100240, "Humanity droped by a corpse hanging by a rope")
        Names.Add(51100260, "Soul of a proud knight (on top of a tower next to the entrance)")
        Names.Add(51100050, "Twin Humanity")
        Names.Add(51100030, "Soul of a brave warrior (at the bottom of the tower next to the entrance)")
        Names.Add(51100010, "Soul of a proud knight (right after a group of 4 hollows)")
        Names.Add(51100320, "Velka's Rapier")
        Names.Add(51100100, "Gold coin")
        Names.Add(51100040, "Large Soul of a proud knight (right before the giant tower)")
        Names.Add(51100070, "Soul of a brave warrior (next to 2 fire hollows & a ladder)")
        Names.Add(51100250, "Egg vermifuge")
        Names.Add(51100330, "Red Sign Soapstone")
        Names.Add(51100350, "Soul of a brave warrior (on the giant tower)")
        Names.Add(51100140, "Annex Key")
        Names.Add(51100130, "Soul of a brave warrior (next to the lever that unlock acces to pricilla)")
        Names.Add(51100120, "Soul of a proud knight (next to the lever that unlock acces to pricilla)")
        Names.Add(51100290, "Soul of a proud knight (next to the 1st body hanging by a rope)")
        Names.Add(51100190, "Acid Surge")
        Names.Add(51100280, "Soul of a proud knight (right before acid surge)")
        Names.Add(51100310, "Soul of a proud knight (right before acid surge)")
        Names.Add(51100300, "Large Soul of a proud knight (right before acid surge)")
        Names.Add(51100370, "Dark Ember")
        Names.Add(51100090, "Vow of silence")
        Names.Add(51100060, "Velka's set")
        Names.Add(51100340, "Soul of a brave warrior (Next to velka's set)")
        Names.Add(51100500, "Chest containing Painting Guardian set")
        Names.Add(51100170, "Soul of a brave warrior (hidded in a corner next to the fog)")
        Names.Add(51100230, "Humanity (dropped by the second body hanging by a rope)")
        Names.Add(51100160, "Ring of Sacrifice")
        Names.Add(51100210, "Large soul of a proud knight (on the bridge with undead dragon)")
        Names.Add(51100200, "Bloodshield")
        Names.Add(51100150, "Xanthous set")
        ' --- Bosses ---
        Names.Add(4, "pricilla")
        ' --- Non-Respawning Enemies ---
        Names.Add(11100400, "Undead Dragon")
        ' --- Shortcuts / Locked Doors ---
        Names.Add(11100135, "Lever that unlock acces to pricilla")
        Names.Add(11100030, "Main Door of the Area")
        Names.Add(11100120, "Annex key door")
        ' --- Foggates ---
        Names.Add(11100091, "Fog of the giant tower")
        ' --- Kindled Bonfires ---
        Names.Add(1101960, "Painted World Bonfire")
        ' ============================================================
        ' === Duke's Archives & Crystal Cave & Prison (17_0)
        ' ============================================================
        ' --- Treasure ---
        'Duke's Archives' 
        Names.Add(51700000, "Soul of a brave warrior (bellow the 1st stairs)")
        Names.Add(51700510, "Chest containing Twinkling Titanite (F1)")
        Names.Add(51700010, "Twinkling Titanite (on a Balcony (F1))")
        Names.Add(51700020, "Chest containing Avelyn")
        Names.Add(51700520, "Chest containing Twinkling Titanite (F2)")
        Names.Add(51700560, "Chest containing Blue Titanite chunk")
        Names.Add(51700580, "Chest containing Channelers set")
        Names.Add(51700540, "Chest containing Strong Magic Shield")
        Names.Add(51700590, "Chest containing Archive tower giant cell key")
        Names.Add(51700600, "Chest containing Crystal Ember")
        Names.Add(51700050, "Chest containing 20 Prism stones")
        Names.Add(51700040, "Soul of a Great Hero (Seath room)")
        Names.Add(50007030, "Logan Drop in Seath room")
        Names.Add(51700641, "Logan Chest with his set and catalyst")
        'Crystal Cave'
        Names.Add(51700120, "Blue Titanite chunk (garden before crystal cave)")
        Names.Add(51700650, "Crystalline set")
        Names.Add(51700150, "Humanity")
        Names.Add(51700160, "Blue Titanite Slab")
        Names.Add(51700170, "Blue Titanite chunk (next to a gold golem)")
        Names.Add(51700180, "Soul of a hero")
        Names.Add(51700530, "Large Magic Ember")
        'Duke's Prison'
        Names.Add(51700990, "Archive tower cell key")
        Names.Add(51700071, "White Seance ring + Maiden set")
        Names.Add(51700630, "Chest containing Archive Towr giant door key")
        Names.Add(51700210, "Archive prison extra key")
        Names.Add(51700080, "Large soul of a brave warrior (next to rhea)")
        Names.Add(51700060, "Large soul of a brave warrior (bellow the second door in the cell)")
        Names.Add(50006070, "Drop from Rhea")
        Names.Add(51700200, "Fire Keeper Soul")
        ' --- Bosses ---
        'Duke's Archives'
        Names.Add(14, "Seath")
        ' --- Non-Respawning Enemies ---
        'Duke's Archives'
        Names.Add(11700815, "Boar")
        Names.Add(11700816, "Boar")
        Names.Add(11700901, "Mimic on 1st room (F1)")
        Names.Add(11700900, "Mimic right before crystal cave")
        Names.Add(11700810, "NPC before Seath room")
        Names.Add(11700811, "Titanite before seath room")
        'Crystal Cave'
        Names.Add(11700821, "1st gold golem of the cave")
        Names.Add(11700820, "2nd gold golem of the cave")
        Names.Add(11700812, "Titanite from the group of 3 Titanite")
        Names.Add(11700813, "Titanite from the group of 3 Titanite")
        Names.Add(11700814, "Titanite from the group of 3 Titanite")
        'Duke's Prison'
        Names.Add(11700822, "Crying Pisaka")
        Names.Add(11700823, "Crying Pisaka")
        Names.Add(11700523, "Rhea Dead")
        ' --- Shortcuts / Locked Doors ---
        'Duke's Archives'
        Names.Add(11700120, "Moving Librairy")
        Names.Add(11700110, "Lever Unlocking the path to crystal cave")
        Names.Add(11700300, "Cell Door")
        Names.Add(11700306, "Locked door leading to Fire keeper soul")
        Names.Add(11700305, "Door in the prison that lead to Archive prison extra key")
        Names.Add(11700304, "Useless door in prison")
        Names.Add(11700303, "Door to rhea")
        Names.Add(11700302, "Useless door in prison")
        Names.Add(11700301, "Second Door in the cell")
        ' --- Foggates --- '
        Names.Add(11700083, "Lead to Crystal Cave")
        ' --- Kindled Bonfires ---
        'Duke's Archives'
        Names.Add(1701960, "Duke's Archives Balcony")
        Names.Add(1701962, "Duke's Archives Entrance")
        'Crystal Cave'
        Names.Add(1701950, "Seath")
        'Duke's Prison'
        Names.Add(1701961, "Duke's Archives Cell")
        ' ============================================================
        ' === Catacombs (13_0)
        ' ============================================================
        ' --- Treasure ---
        Names.Add(51300030, "3 eye of Death, Behing Titanite Demon")
        Names.Add(51300070, "Lucerne")
        Names.Add(51300000, "Large soul of a nameless soldier (not far from lucerne)")
        Names.Add(51300020, "Darkmoon Seance Ring")
        Names.Add(51300230, "Tranquil Walk of Peace")
        Names.Add(51300240, "Soul of a proud knight (next to a lever and Patches)")
        Names.Add(51300110, "Great Scythe")
        Names.Add(51300100, "Green Titanite Shard (in the pit leading to vamos)")
        Names.Add(51300010, "Soul of a proud knight (after the stairs on pit leading to vamos, small room)")
        Names.Add(51300250, "Soul of a proud knight (after the stairs on pit leading to vamos, small room)")
        Names.Add(51300220, "Large soul of a nameless soldier, on a ledge next to the corridor that leads to pinwheel")
        Names.Add(51300140, "Large soul of a nameless soldier, on the room leading to BK, next to the ladder")
        Names.Add(51300150, "Soul of a proud knight (next to the Black Knight)")
        Names.Add(51300191, "Priest's set & Mace")
        Names.Add(51300210, "Soul of a pround knight (after pinwheel fight, go back in a small tunnel)")
        ' --- Bosses ---
        Names.Add(6, "Pinwheel")
        ' --- Non-Respawning Enemies ---
        Names.Add(11300854, "Necromancer (next to the 1st lever)")
        Names.Add(11300850, "Necromancer (he shots you when you enter the main area)")
        Names.Add(11300852, "Necromancer (next to a ladder with a developper message)")
        Names.Add(11300851, "Necromancer (next the the pit that leads to Vamos)")
        Names.Add(11300853, "Necromancer (at the end of a moving ground with pikes, next to 2 skelets)")
        Names.Add(11300856, "Titanite (in a corridor guarded by a lot of statues)")
        Names.Add(11300857, "Titanite (in a corridor guarded by a lot of statues)")
        Names.Add(11300858, "Titanite demon guarding 3 eye of Death")
        Names.Add(11300859, "Black Knight Axe Guy")
        Names.Add(11300855, "Necromancer (next to 2 skelets, at the end of the lower part where bonehweels are)")
        ' --- Shortcuts / Locked Doors ---
        Names.Add(11300900, "First Lever")
        Names.Add(11300901, "Lever next to the pit leading to vamos")
        Names.Add(11300210, "Vamos Cutscene")
        ' --- Illusory Walls ---
        Names.Add(11300160, "Hidding second bonfire of the Area")
        ' --- Foggates ---
        Names.Add(11300090, "Fog leading to a mobile ground with pikes")
        ' --- Kindled Bonfires ---
        Names.Add(1301960, "Entrance Bonfire")
        Names.Add(1301961, "Hidden Bonfire")
        Names.Add(1301962, "Vamos Bonfire")
        ' ============================================================
        ' === DLC (12_1)
        ' ============================================================
        ' --- Treasure ---
        'Oolacile Sanctuary '
        Names.Add(51210010, "Humanity (next to the Sanctuary bonfire)")
        'Royal wood'
        Names.Add(51210500, "Chest containing Blue Titanite slab")
        Names.Add(51210040, "Guardian Leggings")
        Names.Add(51210350, "Guardian Gauntlets")
        Names.Add(51210470, "Large Soul of a brave warrior (guarded by 3 dogs in Kalameet path)")
        Names.Add(51210390, "Soul of a brave warrior (between Artorias & Kalameet, next to elevator shortcut)")
        Names.Add(51210020, "Soul of a Proud Knight (hidded behind the elevator that link royals wood to Artorias)")
        Names.Add(51210030, "Gold Coin")
        Names.Add(51210400, "Soul of a brave warrior")
        Names.Add(51210060, "Elizabeth's Mushroom")
        Names.Add(51210070, "Guardian Helm")
        Names.Add(51210080, "Gough's Great Arrow")
        Names.Add(51210050, "Guardian Armor")
        Names.Add(51210090, "Large Soul of a Proud Knight")
        Names.Add(51210550, "Chest containing Titanite Slab (Kalameet Arena)")
        Names.Add(51210230, "Soul of a Brave Warrior (Kalameet Arena)")
        Names.Add(51210220, "Soul of a Hero (Kalameet Arena)")
        Names.Add(51210240, "Soul of a Brave Warrior (Kalameet Arena)")
        Names.Add(51210250, "Gough's Great Arrow (Kalameet Arena)")
        'Oolacile Township'
        Names.Add(51210450, "Soul of a Hero (on top of Artorias Arena, next to Gough Door)")
        Names.Add(51210110, "Large soul of a proud knight (firt item you see in the township)")
        Names.Add(51210260, "Soul of a Brave Warrior (next to multiples mob)")
        Names.Add(51210160, "Soul of a Brave Warrior (on a beam)")
        Names.Add(51210540, "Chest containing Dark Orb")
        Names.Add(51210520, "Silver Pendant")
        Names.Add(51210921, "Very Good! Carving (dropped by a mimic)")
        Names.Add(51210210, "Rubbish")
        Names.Add(51211000, "Dark Fog (Guarded by a corpe hanging with a rope)")
        Names.Add(51210510, "Chest containing Red Titanite chunk")
        Names.Add(51210981, "Crest Key (Dropped by a mimic)")
        Names.Add(51210460, "On the roof of the House guarding crest key (dark fog)")
        Names.Add(51210190, "Soul of a Hero (on stairs leading to void, mcrest key House)")
        Names.Add(51210430, "Soul of a Brave Warrior (hidded on a corner that lead to chain prisoner)")
        'Chasm of the abyss'
        Names.Add(51210270, "Dark Bead")
        Names.Add(51210340, "Help me! Carving")
        Names.Add(51210280, "Black Flame")
        Names.Add(51210330, "Humanity (next to a sorcerer)")
        Names.Add(51210910, "Shield Droped By sif after you free him")
        Names.Add(51210440, "Twin Humanity (bellow the path that leads to Manus)")
        Names.Add(51210290, "White Titanite Slab (right before manus)")
        Names.Add(51210300, "Soul of a Hero (right before Manus)")
        ' --- Bosses ---
        'Sanctuary Garden'
        Names.Add(11210000, "Sanctuary Guardian")
        'Oolacile Township'
        Names.Add(11210001, "Artorias")
        'Chasm of the Abyss'
        Names.Add(11210002, "Manus")
        'Royal Wood'
        Names.Add(11210004, "Kalameet")
        ' --- Non-Respawning Enemies ---
        'Royal Wood'
        Names.Add(11210351, "Titanite (Next to a big pit)")
        Names.Add(11210354, "Titanite (Not far from the elevator that link royals wood to Artorias)")
        Names.Add(11210350, "Titanite (Kalameet Arena)")
        'Oolacile Township'
        Names.Add(11210355, "Sorcerer guarding ""I'm sorry Carving""")
        Names.Add(11210352, "Titanite on top of a roof (not for from silver pendant)")
        Names.Add(11210681, "Mimic that guard ""Very Good! Carving""")
        Names.Add(11210680, "Mimic That drops Crest Key")
        'Chasm of the Abyss'
        Names.Add(11210353, "Titanite (at the start of Chasm)")
        Names.Add(11210310, "Humanity In Sif Room")
        Names.Add(11210311, "Humanity In Sif Room")
        Names.Add(11210312, "Humanity In Sif Room")
        Names.Add(11210313, "Humanity In Sif Room")
        Names.Add(11210314, "Humanity In Sif Room")
        Names.Add(11210315, "Humanity In Sif Room")
        ' --- Shortcuts / Locked Doors ---
        'Oolacile Township'
        Names.Add(11210650, "Gough Door")
        Names.Add(11210102, "Shortcut Elevator that link township to before Chasm")
        'Royal Wood'
        Names.Add(11210122, "Shortcut Elevator to Artorias")
        Names.Add(11210132, "Shortcut Elevator linking Chasm to Artorias")
        ' --- Illusory Walls ---
        'Oolacile Township'
        Names.Add(11210200, "Only reveal with light (hide silver pendant)")
        Names.Add(11210201, "Only reveal with light (hide Chest containing Red Titanite chunk)")
        'Chasm of the Abyss'
        Names.Add(11210025, "Leading to Sif")
        ' --- Foggates ---
        'Oolacile Township'
        Names.Add(11219114, "Purple Coward's Crystal")
        ' --- Kindled Bonfires ---
        Names.Add(1211950, "Chasm of the Abyss (Manus)")
        Names.Add(1211961, "Oolacile Sanctuary")
        Names.Add(1211962, "Oolacile Township")
        Names.Add(1211963, "Sanctuary Garden")
        Names.Add(1211964, "Oolacile Township Dungeon")
        ' ============================================================
        ' === Sen's (15_0)
        ' ============================================================
        ' --- Treasure ---
        Names.Add(51500010, "Soul of a Brave Warrior (on the entrance room)")
        Names.Add(51500330, "Large Soul of a Proud Knight (in front of Illusory wall you can only break with attacks)")
        Names.Add(51500020, "Chest containing 2 Large Titanite Shard")
        Names.Add(51500420, "Soul of a Hero (in a cage, Logan room)")
        Names.Add(51500300, "Shotel")
        Names.Add(51500000, "Chest containing Ring of Steel Protection")
        Names.Add(51500310, "Large Soul of a Proud Knight (guarded by a lightning serpent on a wood platform)")
        Names.Add(51500061, "Hush & Black Sorcerer set")
        Names.Add(51500070, "Covetous Gold Serpent Ring")
        Names.Add(51500080, "2 Large Titanite Shard (behind a serpent)")
        Names.Add(51500320, "Slumbering Dragoncrest Ring")
        Names.Add(51500360, "Scythe")
        Names.Add(51500350, "Soul of a Brave Warrior (on the swamp next to Scythe)")
        Names.Add(51500440, "Sniper Crossbow")
        Names.Add(51500090, "Flame Stoneplate Ring")
        Names.Add(51500400, "Large soul of a brave warrior (right before the bonfire)")
        Names.Add(51500410, "2 Large Titanite Shard (right after a Large soul of a brave warrior)")
        Names.Add(51500150, "Cage Key")
        Names.Add(51500100, "Chest containing Rare Ring of Sacrifice")
        Names.Add(51500040, "Chest containing Divine Blessing")
        Names.Add(50006040, "Griggs Drop")
        ' --- Bosses ---
        Names.Add(11, "Iron Golem")
        ' --- Non-Respawning Enemies ---
        Names.Add(11500867, "Boulder Giant (After ladders behind an Illusory wall you can only break with attacks)")
        Names.Add(11500861, "Titanite Demon (in the swamp)")
        Names.Add(11500862, "Titanite Demon (in the swamp)")
        Names.Add(11500863, "Titanite Demon (in the swamp)")
        Names.Add(11500864, "Titanite Demon (in the swamp)")
        Names.Add(11500900, "Mimic that drops Lightning Spear")
        Names.Add(11500860, "NPC that drops ricard's Rapier")
        Names.Add(11500865, "Boulder Giant That Throw Bombs in Iron Golem Arena")
        ' --- Shortcuts / Locked Doors ---
        Names.Add(11500200, "Sen's Gate")
        Names.Add(11500112, "Logan cage")
        Names.Add(11500110, "Cage in Logan Room")
        Names.Add(11500111, "Cage in Logan Room")
        Names.Add(11500113, "Cage in Logan Room")
        Names.Add(11500115, "Cage in Logan Room")
        Names.Add(11500116, "Cage in Logan Room")
        Names.Add(11500105, "Right After Griggs")
        Names.Add(11500100, "Cage shortcut sent down")
        ' --- Foggates ---
        Names.Add(11500090, "F1 Sens Fog")
        Names.Add(11500091, "F3 Sens Fog")
        ' --- Kindled Bonfires ---
        Names.Add(1501961, "Sen's Fortress Bonfire")
        ' ============================================================
        ' === Anor Londo (15_1)
        ' ============================================================
        ' --- Treasure ---
        Names.Add(51510680, "Chest containing Demon Titanite (1st chest of the area)")
        Names.Add(51510670, "Chest containing Twinkling Titanite")
        Names.Add(51510510, "Chest containing Demon Titanite")
        Names.Add(51510520, "Chest containing Devine Blessing (Rafters)")
        Names.Add(51510000, "Great Magic Weapon (drops with the chandelier on rafters)")
        Names.Add(51510071, "Black Iron Set")
        Names.Add(51510050, "Soul of a Hero (guarded by silver knight archers)")
        Names.Add(51510690, "Chest containing 3 Sunlight Medals")
        Names.Add(51510570, "Chest containing Havel's Greatshield")
        Names.Add(51510560, "Chest containing Dragon Tooth")
        Names.Add(51510540, "Chest containing Havel's Gauntlets & Leggings")
        Names.Add(51510530, "Chest containing Havel's Helm & Armor")
        Names.Add(51510700, "Soul of a Hero (guarded by a Silver Knight with spears, behind a door)")
        Names.Add(51510590, "Chest containing Silver Knight Gauntlets & Leggings")
        Names.Add(51510580, "Chest containing Silver Knight Helm & Armor")
        Names.Add(51510600, "Chest containing 2 Demon Titanite (Siegmeyer Room)")
        Names.Add(51510060, "DragonSlayer GreatBow")
        Names.Add(51510610, "Chest containing Hawk Ring")
        Names.Add(51510040, "Titanite Chunk (close to Giant Blackmith)")
        Names.Add(51510080, "Lautrec Set")
        Names.Add(50006010, "Fire keeper soul")
        Names.Add(51510030, "Ring of the Sun's Firstborn")
        Names.Add(51510620, "Chest containing Sunlight Blade")
        Names.Add(51510660, "Chest containing Brass set")
        Names.Add(11510615, "Empty Chest")
        ' --- Bosses ---
        Names.Add(12, "O&S")
        Names.Add(11510900, "Gwyndolin")
        ' --- Non-Respawning Enemies ---
        Names.Add(11510851, "Mimic that drops Crystal Halberd")
        Names.Add(11510850, "Mimic that drops occult club")
        Names.Add(11510853, "Mimic that drops Gold coin")
        Names.Add(11510852, "Mimic that drops Silver coin")
        Names.Add(11510860, "Demon Titanite (Cathedral in a small room)")
        Names.Add(11515080, "Gargoyle")
        Names.Add(11515081, "Gargoyle")
        Names.Add(11510863, "NPC in Cathedral, when Gwynewere is Dead")
        Names.Add(11510864, "NPC in Cathedral, when Gwynewere is Dead")
        ' --- Shortcuts / Locked Doors ---
        Names.Add(11510220, "Main Anor Londo Elevator")
        Names.Add(11510251, "Door in the Cathedral (in the room where Silver Knight set is)")
        Names.Add(11510257, "Siegmeyer room door")
        Names.Add(11510210, "Shortcut Door next to Giant Blackmith")
        Names.Add(11510200, "Giant Doot Opening the Cathedral")
        Names.Add(11510110, "Gwynevere Door")
        ' --- Illusory Walls ---
        Names.Add(11510401, "Gwyndolin (Gwyn Statue)")
        Names.Add(11510215, "In the Cathedral, Hide 4 Chests and a Mimic")
        ' --- Foggates ---
        Names.Add(11510090, "Fog Right After the rafters")
        Names.Add(11510091, "Fog right After the Silver Knights archers")
        ' --- Kindled Bonfires ---
        Names.Add(1511950, "Chamber of the Princess")
        Names.Add(1511960, "Anor Londo Bonfire")
        Names.Add(1511961, "Interior")
        Names.Add(1511962, "Darkmoon Tomb")
        ' ============================================================
        ' === Demon Ruins And Izalith (14_1)
        ' ============================================================
        ' --- Treasure ---
        'Demon Ruins'
        Names.Add(51410180, "Ceaseless Discharge Arena Loot")
        Names.Add(51410060, "Large soul of a proud knight (Next to the group of taurus demons)")
        Names.Add(51410530, "Chaos Ember")
        Names.Add(51410050, "Soul of a proud Knight (guarded by a Capra Demon)")
        Names.Add(51410080, "Soul of a proud Knight (next to Demon Ruins second bonfire)")
        Names.Add(51410090, "2 Green Titanite Shard (hidded behind stairs in demon ruins)")
        Names.Add(51410510, "Soul of a proud Knight (next to Centipede demon statue)")
        Names.Add(51410140, "Soul of a brave warrior (on the right just before golden foggate)")
        Names.Add(51410100, "Chest containing Large Flame Ember")
        Names.Add(51410230, "Soul of a brave warrior (after firesage, guarded by 3 lave guys)")
        Names.Add(51410250, "Soul of a brave warrior (just before Centipede arena, on a ledge)")
        Names.Add(51410270, "2 Green Titanite Shard (Centipede Arena)")
        'Lost Izalith'
        Names.Add(51410310, "Soul of a brave warrior (Dragon butt area)")
        Names.Add(51410320, "Soul of a brave warrior (Dragon butt area)")
        Names.Add(51410330, "Divine Blessing (Dragon butt area)")
        Names.Add(51410340, "Divine Blessing (Dragon butt area)")
        Names.Add(51410360, "Twin Humanities (On top of Bonfire Building, Dragon butt area)")
        Names.Add(51410500, "Chest containing Soul of Great Hero")
        Names.Add(51410390, "Large soul of a brave warrior (hidded next to stairs before BOC)")
        Names.Add(51410520, "Chest containing Chaos Fire Whip")
        Names.Add(51410990, "Sunlight Magot (dropped by the mob)")
        Names.Add(51410160, "Soul of a brave warrior (right before quelaag covenant door, on a ledge)")
        Names.Add(51410000, "Red Titanite Chunk (in the swamp)")
        Names.Add(51410020, "Soul of a brave warrior (in the swamp)")
        Names.Add(51410030, "2 Green Titanite shard (in the swamp)")
        Names.Add(51410410, "Chest containing Red Titanite Slab")
        Names.Add(51410010, "Red Titanite Chunk (after stairs that leave the swamp)")
        Names.Add(51410400, "Soul of a Hero (in the area right before BOC)")
        Names.Add(51410380, "Rare ring of sacrifice (on a tiny branch, in the area right before BOC)")
        ' --- Bosses ---
        'Demon Ruins'
        Names.Add(11410900, "Ceaseless Discharge")
        Names.Add(11410410, "Demon Firesage")
        Names.Add(11410901, "Centipede Demon")
        'Lost Izalith'
        Names.Add(10, "BOC")
        ' --- Non-Respawning Enemies ---
        'Demon Ruins'
        Names.Add(11410138, "Taurus Demon")
        Names.Add(11410139, "Taurus Demon")
        Names.Add(11410140, "Taurus Demon")
        Names.Add(11410141, "Taurus Demon")
        Names.Add(11410142, "Taurus Demon")
        Names.Add(11410143, "Taurus Demon")
        Names.Add(11410144, "Taurus Demon")
        Names.Add(11410104, "RockWorm guarding Demon ruins second bonfire")
        'Lost Izalith'
        Names.Add(11410109, "Dragon Butt")
        Names.Add(11410110, "Dragon Butt")
        Names.Add(11410111, "Dragon Butt")
        Names.Add(11410112, "Dragon Butt")
        Names.Add(11410113, "Dragon Butt")
        Names.Add(11410114, "Dragon Butt")
        Names.Add(11410115, "Dragon Butt")
        Names.Add(11410116, "Dragon Butt")
        Names.Add(11410117, "Dragon Butt")
        Names.Add(11410118, "Dragon Butt")
        Names.Add(11410119, "Dragon Butt")
        Names.Add(11410120, "Dragon Butt")
        Names.Add(11410121, "Dragon Butt")
        Names.Add(11410122, "Dragon Butt")
        Names.Add(11410123, "Dragon Butt")
        Names.Add(11410124, "Dragon Butt")
        Names.Add(11410125, "Dragon Butt")
        Names.Add(11410126, "Dragon Butt")
        Names.Add(11410127, "Dragon Butt")
        Names.Add(11410128, "Dragon Butt")
        Names.Add(11410129, "Dragon Butt")
        Names.Add(11410130, "Dragon Butt")
        Names.Add(11410131, "Dragon Butt")
        Names.Add(11410132, "Dragon Butt")
        Names.Add(11410133, "Dragon Butt")
        Names.Add(11410134, "Dragon Butt")
        Names.Add(11410135, "Dragon Butt")
        Names.Add(11410136, "Dragon Butt")
        Names.Add(11410137, "Dragon Butt")
        Names.Add(11410106, "Quelana")
        Names.Add(11410107, "Titanite (right before Respawning Titanite demon)")
        Names.Add(800, "Sunlight Magot")
        Names.Add(11410100, "Chaos Eater for Siegmeyer Questine")
        Names.Add(11410101, "Chaos Eater for Siegmeyer Questine")
        Names.Add(11410102, "Chaos Eater for Siegmeyer Questine")
        Names.Add(11410103, "Chaos Eater for Siegmeyer Questine")
        ' --- Shortcuts / Locked Doors ---
        'Lost Izalith'
        Names.Add(11410340, "Quelaag covenant Door")
        ' --- Illusory Walls ---
        'Lost Izalith'
        Names.Add(11410360, "Izalith second bonfire")
        ' --- Kindled Bonfires ---
        'Lost Izalith'
        Names.Add(1411950, "Lost Izalith (Bed of Chaos)")
        Names.Add(1411960, "Lost Izalith (Lava)")
        'Demon ruins'
        Names.Add(1411961, "Demon Ruins ")
        Names.Add(1411962, "Demon Ruins Before Demon Firesage")
        Names.Add(1411963, "Demon Ruins Before Centipede Demon")
        Names.Add(1411964, "Lost Izalith Entrance")
        ' ============================================================
        ' === Tomb Of the Giants (13_1)
        ' ============================================================
        ' --- Treasure ---
        Names.Add(51310010, "Large Soul of a proud Knight (right after pinwheel arena ( look up))")
        Names.Add(51310080, "3 eye of Death (in a room with 2 big skelets)")
        Names.Add(51310070, "Large Soul of a proud Knight (in a room with 2 big skelets)")
        Names.Add(51310300, "Large Soul of a proud Knight (on a ledge when you come from a room with 2 big skelets)")
        Names.Add(51310040, "Soul of a Brave Warrior (on a room with 6 big skelets)")
        Names.Add(51310500, "Large divine Ember (on a room with 6 big skelets)")
        Names.Add(51310000, "Large Soul of a proud Knight (Guarded by a big skelet)")
        Names.Add(51310020, "Humanity (next to the silder that lead to the 1st bonfire)")
        Names.Add(51310030, "Large Soul of a proud Knight (In the pit where Patches kick you)")
        Names.Add(51310050, "Large Soul of a proud Knight (In the pit where Patches kick you)")
        Names.Add(51310090, "Skull Lantern (In the pit where Patches kick you)")
        Names.Add(51310100, "White Titanite Chunk (In the pit where Patches kick you)")
        Names.Add(51310120, "Effigy Shield")
        Names.Add(51310110, "Soul of a Brave Warrior (next to a big skelet with arc, TOTG 2)")
        Names.Add(51310140, "Covetous Silver Serpent Ring")
        Names.Add(51310180, "Soul of a Brave Warrior (right before Nito's Domain, next to the ladder)")
        Names.Add(51310200, "Soul of a Hero (Nito's domain)")
        Names.Add(51310230, "Soul of a Hero (Nito's domain right before Nito bossfight)")
        Names.Add(51310220, "White Titanite Slab (Nito's domain)")
        Names.Add(51310290, "White Titanite Chunk (Nito's domain)")
        Names.Add(51310240, "Paladin set (require Leeroy kill)")
        Names.Add(51310160, "White Titanite Chunk (TOTG2, in a corner)")
        ' --- Bosses ---
        Names.Add(7, "Nito")
        ' --- Non-Respawning Enemies ---
        Names.Add(11310820, "BKH guy")
        Names.Add(11310821, "Titanite (Nito's Domain)")
        ' --- Illusory Walls ---
        Names.Add(11310100, "Between a ladder that lead to Rhea & Large Divine ember room")
        ' --- Foggates ---
        Names.Add(11310090, "Lead to second part of TOTG")
        ' --- Kindled Bonfires ---
        Names.Add(1311960, "Second Bonfire")
        Names.Add(1311961, "First Bonfire ( Patches )")
        Names.Add(1311950, "Nito")
        ' ============================================================
        ' === Ash Lake & Great Hollow (13_2)
        ' ============================================================
        ' --- Treasure ---
        Names.Add(51320000, "Plank Shield")
        Names.Add(51320180, "Chest containing Twin Humanities")
        Names.Add(51320090, "Blue Titanite Chunk (on a branch in second part of Great Hollow)")
        Names.Add(51320080, "Red Titanite Chunk (on a branch in 1st part of Great Hollow)")
        Names.Add(51320020, "Cloranthy Ring")
        Names.Add(51320040, "Titanite Chunk (on a branch in 1st part of Great Hollow)")
        Names.Add(51320060, "Blue Titanite Chunk (on a branch in 1st part of Great Hollow)")
        Names.Add(51320050, "Large Soul of a nameless soldier (in a corner next to a group of 3 basiliscs in 1st part of Great Hollow)")
        Names.Add(51320110, "Large Soul of a nameless soldier (on the big platform, middle of Great Hollow)")
        Names.Add(51320070, "White Titanite Chunk (on a branch in 1st part of Great Hollow)")
        Names.Add(51320100, "White Titanite Chunk (on a branch in 2nd part of Great Hollow)")
        Names.Add(51320120, "Titanite Chunk (on a big Mushroom in 2nc part of Great Hollow)")
        Names.Add(51320190, "Red Titanite Chunk (in a small branch in first part of Great Hollow)")
        Names.Add(51320140, "Dragon Scale (in a corner close to the Hydra)")
        Names.Add(51320150, "Dragon Scale (in a tree stump)")
        Names.Add(51320160, "Dragon Scale (in a floating corpse)")
        Names.Add(51320170, "Great Magic Barrier")
        ' --- Non-Respawning Enemies ---
        Names.Add(11320305, "Titanite (alone, at the end of no issue path)")
        Names.Add(11320310, "Titanite (alone, leads to no issue path)")
        Names.Add(11320308, "Titanite (in a group of 2 Titanites in 1st part of Great Hollow)")
        Names.Add(11320307, "Titanite (in a group of 2 Titanites in 1st part of Great Hollow)")
        Names.Add(11320309, "Titanite (alone, leads to 4 Titanites following the path)")
        Names.Add(11320304, "Titanite (alone, leads to 3 Titanites on a ledge following the path)")
        Names.Add(11320303, "Titanite (in a group of 3 Titanites in 1st part of Great Hollow)")
        Names.Add(11320302, "Titanite (in a group of 3 Titanites in 1st part of Great Hollow)")
        Names.Add(11320301, "Titanite (in a group of 3 Titanites in 1st part of Great Hollow)")
        Names.Add(11320306, "Titanite (alone, on a branch in 1st part of Great Hollow)")
        Names.Add(11320100, "Hydra")
        ' --- Illusory Walls ---
        Names.Add(11320200, "First of the area")
        Names.Add(11320201, "Second of the area")
        ' --- Foggates ---
        Names.Add(11320090, "Link ash lake to great hollow")
        ' --- Kindled Bonfires ---
        Names.Add(1321962, "Great Hollow Bonfire")
        Names.Add(1321960, "Main Ash Lake Bonfire")
        Names.Add(1321961, "Stone Dragon Bonfire")
        ' ============================================================
        ' === Blighttown_And_Quelaags_Domain (14_0)
        ' ============================================================
        ' --- Treasure ---
        Names.Add(51400500, "Chest containing Key to New Londo Ruins")
        Names.Add(51400350, "Fire Keeper Soul (in the room with a lot of snipers)")
        Names.Add(51400210, "Soul of a proud knight (in the room with a lot of snipers)")
        Names.Add(51400191, "Crimson set & Tin Banishment Catalyst")
        Names.Add(51400520, "Chest containing Remedy")
        Names.Add(51400250, "Great Club")
        Names.Add(51400230, "2 Large Titanite Shard (next to a pillar, in the swamp)")
        Names.Add(51400260, "Large soul of a proud knight (next to a pillar, in the swamp)")
        Names.Add(51400270, "Laurentius set + Poison mist")
        Names.Add(51400280, "Large soul of a proud knight (next to laurentius, in the swamp)")
        Names.Add(51400300, "1 Large Titanite Shard (in the swamp next to great hollow)")
        Names.Add(51400360, "Server (in the swamp next to great hollow)")
        Names.Add(51400290, "1 Green Titanite Shard (in the swamp next to great hollow)")
        Names.Add(51400510, "Chest containing 1 Dragon Scale")
        Names.Add(51400320, "Large soul of a proud knight (not far from swamp bonfire, in the swamp)")
        Names.Add(51400311, "Wanderer set & Falchion")
        Names.Add(51400020, "Soul of a proud knight (first item after door linking Depths to Blighttown)")
        Names.Add(51400340, "Laito")
        Names.Add(51400080, "3 Blooming Purple Moss Clump (Upper BT)")
        Names.Add(51400060, "1 Humanity (next to the mooving platform on a beam)")
        Names.Add(51400050, "Large Soul of a nameless solider (in a very small corner, Upper BT)")
        Names.Add(51400090, "Soul of a proud knight (upper BT, next to a ladder, in a sort of closed place)")
        Names.Add(51400040, "Shadow set (upper BT)")
        Names.Add(51400100, "Soul of a proud knight (upper BT, right after a wood barrier)")
        Names.Add(51400160, "Eagle Shield (upper BT)")
        Names.Add(51400150, "Soul of a proud knight (upper BT)")
        Names.Add(51400140, "Soul of a Nameless soldier (next to the Parasitic Wall Hugger)")
        Names.Add(51400130, "Power Within")
        Names.Add(51400180, "Whip (the a well)")
        Names.Add(51400370, "Thorns set (Kirk)")
        ' --- Bosses ---
        Names.Add(9, "Quelaag")
        ' --- Non-Respawning Enemies ---
        Names.Add(11400853, "Blowdart Sniper (next to water wheel)")
        Names.Add(11400855, "Blowdart Sniper (next to water wheel in a big room with Firekeeper Soul)")
        Names.Add(11400856, "Blowdart Sniper (next to water wheel in a big room with Firekeeper Soul)")
        Names.Add(11400857, "Blowdart Sniper (next to water wheel in a big room with Firekeeper Soul)")
        Names.Add(11400858, "Blowdart Sniper (next to water wheel in a big room with Firekeeper Soul)")
        Names.Add(11400854, "Blowdart Sniper (next to Wanderer set & Falchion item)")
        Names.Add(11400850, "Blowdart Sniper (Upper Blighttown, on top of a ladder)")
        Names.Add(11400852, "Blowdart Sniper (next to Eagle Shield)")
        Names.Add(11400851, "Blowdart Sniper (at the end of a ladder, very high location, upper BT)")
        Names.Add(11400902, "Parasitic Wall Hugger")
        ' --- Illusory Walls ---
        Names.Add(11400210, "Hide Firelady")
        ' --- Foggates ---
        Names.Add(11400091, "Lead to a well in BT")
        ' --- Kindled Bonfires ---
        Names.Add(1401960, "Quelaag domain")
        Names.Add(1401961, "Blighttown Swamp")
        Names.Add(1401962, "Blighttown Bridge")
        ' ============================================================
        ' === New Londo & Valey of the Drakes (16_0)
        ' ============================================================
        ' --- Treasure ---
        Names.Add(51600000, "Soul of a nameless soldier (next to the elevator to firelink)")
        Names.Add(51600020, "Estoc")
        Names.Add(51600030, "Fire keeper soul")
        Names.Add(51600040, "2 Transient cursen (in a corpse in a falling pot)")
        Names.Add(51600520, "2 Transient cursen (in a corpse in a falling pot next to crestfallen)")
        Names.Add(51600060, "Parrying dagger")
        Names.Add(51600070, "2 Transient cursen (next to a fog and lightning hollow)")
        Names.Add(51600090, "Large soul of a nameless soldier (next to the shortcut ladder)")
        Names.Add(51600100, "1 Green Titanite Shard (in a room before seal)")
        Names.Add(51600120, "large soul of a nameless soldier (in the way to seal)")
        Names.Add(51600150, "Humanity (on a ledge, highest point of the area)")
        Names.Add(51600130, "Rare ring of sacrifice (on the roof of ghost house)")
        Names.Add(51600140, "Cursebite Ring")
        Names.Add(51600110, "Soul of a proud knight (ghost house)")
        Names.Add(51600160, "Composite Bow")
        Names.Add(51600250, "Large soul of a Proud Knight (lower new londo after a fog)")
        Names.Add(51600270, "Soul of a brave warrior (in a room with very large ember and a Mass of soul)")
        Names.Add(51600500, "Very large ember")
        Names.Add(51600280, "Large soul of a proud knight (next to illusory wall that lead to a chest)")
        Names.Add(51600290, "Chest containing 1 Titanite chunk behind illusory wall")
        Names.Add(51600310, "6 Cracked Red eye orb")
        Names.Add(51600370, "Large soul of a proud knight on stairs that lead to Kings fog (lower new londo)")
        Names.Add(51600330, "Large soul of a proud knight (lower new londo)")
        Names.Add(51600510, "Chest containing Titanite Chunk")
        Names.Add(51600170, "Large soul of a nameless soldier (next to the door that Link new londo to valley)")
        Names.Add(51600361, "Witch set & Beatrice's Catalyst (valley)")
        Names.Add(51600180, "Astora's Straight Sword (next to undead dragon, valley)")
        Names.Add(51600190, "Soul of a Proud Knight (next to undead dragon, valley)")
        Names.Add(51600200, "Dragon Crest shield (next to undead dragon, valley)")
        Names.Add(51600210, "Humanity (behind a drake, valley)")
        Names.Add(51600380, "Red Tearstone Ring")
        Names.Add(51600221, "Brigand set & Spider shield")
        Names.Add(51600260, "Humanity (behind mass of soul enemy)")
        ' --- Bosses ---
        Names.Add(13, "Foor Kings")
        ' --- Non-Respawning Enemies ---
        Names.Add(11600850, "Mass of soul")
        Names.Add(11600851, "Mass of soul that guard a chest")
        Names.Add(11600810, "Undead dragon (valley)")
        ' --- Shortcuts / Locked Doors ---
        Names.Add(11600160, "Shortcut ladder")
        Names.Add(11600110, "Door to the seal")
        Names.Add(11600100, "Door that drain new londo water")
        Names.Add(11600120, "Link new londo to valley")
        ' --- Foggates ---
        Names.Add(11600090, "1st fog of the area that lead to shortcut ladder")
        Names.Add(11600091, "Fog in lower new londo")
        ' --- Bonfires --- '
        Names.Add(1601950, "Abyss Bonfire")
        Names.Add(1602961, "Darkroot Bonfire")

        ' --- Kiln --- '
        ' --- Treasure ---
        Names.Add(51800050, "Black Knight Set")
        ' --- Bosses ---
        Names.Add(15, "Gwyn")
        ' Bonfire
        Names.Add(1801960, "Souls Offered to the Lordvessel")

        ' --- NPC Questlines --- '
        Names.Add(11020101, "Anastacia + Lautrec")
        Names.Add(50000501, "Ciaran")
        Names.Add(1462, "CrestFallen Warrior")
        Names.Add(1431, "Domhnall")
        Names.Add(1115, "Griggs")
        Names.Add(1313, "Ingward")
        Names.Add(1254, "Laurentius")
        Names.Add(1097, "Logan")
        Names.Add(1626, "Patches")
        Names.Add(1177, "Rhea")
        Names.Add(11200535, "Shiva")
        Names.Add(11020606, "Siegmeyer")
        Names.Add(1012, "Solaire")
        Names.Add(1011, "Solaire")
        Names.Add(11210021, "Sif ")
        '  Names.Add(, "Dusk")'
        Names.Add(11010700, "Oswald")
        ' Names.Add(?, "Quelaana")  



    End Sub

End Class
