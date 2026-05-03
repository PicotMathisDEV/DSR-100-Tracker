# Dark Souls Remastered 100% Tracker

Tracker made to keep track of all the objectives in a Dark Souls Remastered 100% speedrun. UI has been designed so that it's easy to display the tracker on stream via a color key.

Complete ruleset for 100%: https://wiki.speedsouls.com/darksouls:100%25

---

## Based on Kahmul's PTDE tracker

This tool is almost entirely based on [Kahmul's Dark Souls 100% Tracker](https://github.com/Kahmul/Dark-Souls-100-Percent-Tracker) for Dark Souls: Prepare to Die Edition. Credit goes to Kahmul and the original contributors (B3LYP, HotPocketRemix, Meowmaritus, Wulf2k) for the original work.

---

## What was changed for DSR

Dark Souls Remastered is a 64-bit game whereas PTDE was 32-bit. This required several architectural changes:

### Memory reading
- **PTDE** used hardcoded static addresses (e.g. `0x137E204`) because the game always loads at the same location in memory.
- **DSR** uses **AOB scanning** (Array of Bytes scanning) — the tracker searches for unique sequences of bytes in the game's code to dynamically find the right addresses at each launch, because DSR uses ASLR (addresses change every time).

### Pointer sizes
- All pointer reads were updated from 32-bit (`RInt32`) to 64-bit (`RInt64`) to match DSR's 64-bit architecture.

### Updated offsets
- Starting class offset: `0xC6` → `0xCE`
- Bonfire manager: completely replaced the PTDE linked list path (`WorldChrMan + 0xB48`) with the correct DSR path via `FrpgNetManImp` (AOB: `48 83 3D ? ? ? ? 00 48 8B F1`, offset `0xB68`), sourced from [SoulSplitter by FrankvdStam](https://github.com/FrankvdStam/SoulSplitter).

### Event flag IDs
The event flag IDs for all tracked objectives (bosses, items, enemies, NPCs, shortcuts, illusory walls, foggates, bonfires) are **identical** between PTDE and DSR since it is the same game.

---

## What is tracked

| Category | Weight |
|---|---|
| Treasure Locations | 20% |
| Bosses | 25% |
| Non-respawning Enemies | 15% |
| NPC Questlines | 20% |
| Shortcuts / Locked Doors | 10% |
| Illusory Walls | 2.5% |
| Foggates | 2.5% |
| Kindled Bonfires | 5% |

---

## Requirements

- Dark Souls Remastered (any version, Steam)
- Windows 64-bit
- Run as Administrator
