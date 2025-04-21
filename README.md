# 2D Unity Game Project

This is a 2D game developed in Unity by me as part of a high school graduation thesis. The game features 5 playable levels with various interactive elements, characters, and a complete user interface.

![Bez názvu](https://github.com/user-attachments/assets/7bc08ed2-4c24-4081-9862-7afd1908abfc)

## Features
| Category        | Details                                                                 |
|-----------------|-------------------------------------------------------------------------|
| 🎚️ **Levels**   | 5 fully playable levels with increasing difficulty                      |
| 🧩 **Objects**  | Chest, Trap, Cart, Barrel, Gem, Coin                                   |
| 🧙 **Characters** | Wizard, Bandit, Huntress, Player                                       |
| 🎛️ **UI**       | Health bar, Coin counter, Level evaluation                             |
| 🎵 **Audio**    | Background music & sound effects                                       |
| ⚙️ **Menu**     | Autosave, Volume controls, Controls display, Quit button               |

## Gameplay Video
[▶️ Watch Gameplay on YouTube](https://youtu.be/68mCHKE7U-k)

# Characters & Interactive Objects

## Playable Characters

| Character | Preview | Description |
|-----------|---------|-------------|
| **Player** | <img src="https://github.com/user-attachments/assets/0d2a6e87-18df-4120-a043-0b6b4b73a2bc" width="110" style="border-radius: 8px;"> | Main protagonist with combat abilities |
| **Bandit** | <img src="https://github.com/user-attachments/assets/7f9f1243-787c-4d8c-9bc5-0e6ab2840f22" width="100" style="border-radius: 8px;"> | Melee enemy |
| **Wizard** | <img src="https://github.com/user-attachments/assets/4efc626e-77b1-4b84-8093-4a7fc7318be4" width="100" style="border-radius: 8px;"> | Magic-wielding enemy |
| **Huntress** | <img src="https://github.com/user-attachments/assets/fc3e0bb7-0eaf-4a2a-a830-f16df80bec14" width="90" style="border-radius: 8px;"> | Ranged combat enemy |

## Enemy Entities
| Entity | Preview | Behavior |
|--------|---------|----------|
| **Trap** | <img src="https://github.com/user-attachments/assets/6cc7d037-8da2-47a4-b568-8c945062c845" width="100" style="border-radius: 8px;"> | Environmental hazard with activation trigger |
| **Tree**) | <img src="https://github.com/user-attachments/assets/d39fc29e-8ede-45ef-82f9-fd08df1157c9" width="100" style="border-radius: 8px;"> | Destructible environment element |

## Interactive Objects
| Object | Preview | Functionality |
|--------|---------|--------------|
| **Chest** |  <img src="https://github.com/user-attachments/assets/c6f6f5a2-0eb7-458b-859c-f636dc605567" width="100" style="border-radius: 8px;"> | Contains coins |
| **Coin** | <div style="display: flex; align-items: center; padding-left: 60px;"><img src="https://github.com/user-attachments/assets/7d621cce-66f5-4339-ae04-2bb938da125c" width="100" style="border-radius: 8px;"></div> | Standard currency (+10 points) |
| **Cart** |  <img src="https://github.com/user-attachments/assets/1479fd5a-b8ae-4212-8251-83aebf72baae" width="70" style="border-radius: 8px; align-items: center;"> | Moveable platform/puzzle element |
| **Barrel** |  <img src="https://github.com/user-attachments/assets/9fe34a7d-e6ab-4e5c-a746-3386c32fb8fa" width="100" style="border-radius: 8px;"> | Explosive/destructible object |
| **Health Gem** |  <img src="https://github.com/user-attachments/assets/2c9d2dbf-ba57-489c-8736-c5b60a2816af" width="80" style="border-radius: 8px;"> | High-value collectible (+50 points) |
| **Magic Gem** | <img src="https://github.com/user-attachments/assets/6db7336d-9f77-481e-847f-f7d714ebe1e6" width="80" style="border-radius: 8px;"> | Quest item with special properties |

---

### Implementation Notes:
- All characters use Unity's 2D Animation system
- Interactive objects implement `IInteractable` interface
- Inventory items inherit from base `Collectible` class
- Preview images should be replaced with actual sprite captures

## How to run
- Simply download this directory with .exe file [🎮 Game](https://drive.google.com/drive/folders/1eBmfYWrt_OwAMpSA0Dbdui4QLICe5o8U?usp=drive_link)


## Controls
| Action          | Key           |
|-----------------|---------------|
| Left Move       | A/Left Arrow  |
| Right Move      | D/Right Arrow |
| Jump            | Space         |
| Attack          | E             |
| Interact        | F             |
| Fire Shuriken   | Q             |
| Pause           | Esc           |

## Development
### Built With
- Unity 2021.3.15f1
- Visual Studio (C#)
---

**Enjoy the game!** If you find any bugs, please open an issue.
