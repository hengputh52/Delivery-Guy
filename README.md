
# Delivery Guy


## Quick Navigation

- [🎮 Phase 1: How to Play](#phase-1-how-to-play)
- [💻 Phase 2: System Requirements](#phase-2-system-requirements)
- [📖 Phase 3: About the Game](#phase-3-about-the-game)
- [⭐ Phase 4: Unique Features](#phase-4-unique-features)
- [🔧 Phase 5: Technical Report](#phase-5-technical-report)
- [🚀 Resources](#resources)
- [📦 Phase 6: Release Version](#phase-6-release-version)
- [📚 Phase 7: Documentation & Tools](#phase-7-documentation--tools)
- [🤝 Phase 8: Contributing Guide](#phase-8-contributing-guide)
- [👥 Phase 9: Credits](#phase-9-credits)

---


## Project Structure

```
Delivery Guy/
├── Assets/
│   ├── Scenes/           # All Unity scenes (MainMenu, LevelSelection, GameScene_level_1, etc.)
│   ├── Scripts/          # C# scripts for gameplay, AI, UI, and managers
│   ├── Prefabs/          # Prefab GameObjects (vehicles, delivery points, UI panels, etc.)
│   ├── Resources/        # Fonts, icons, and other resources loaded at runtime
│   ├── Textures/         # Textures and materials for 3D models and UI
│   ├── Loading Games/    # 3D models and city assets (e.g., Toon City Pack)
│   ├── Images/           # UI images, icons, and sprites
│   ├── Animation/        # Animation clips and controllers for vehicles and UI
│   ├── Gley/             # (If present) Third-party or asset store plugins
│   ├── Editor/           # Editor scripts and custom inspectors
│   └── ... (other folders as needed)
├── Builds/                # Built game files (.exe, data folder)
├── Docs/                  # Documentation and PDF files
├── ProjectSettings/       # Unity project settings
├── Packages/              # Unity package manager files
├── README.md              # Project overview and instructions
├── LICENSE                # License information
```

### Key Folders and Their Purpose

- **Scenes/**: Contains all Unity scene files. Each scene represents a different part of the game (e.g., MainMenu, LevelSelection, GameScene_level_1, GameOver, etc.).
- **Scripts/**: All C# scripts for the project. Examples:
	- `PlayerCarController.cs`: Handles player vehicle input and movement.
	- `AITruckController.cs`, `AICarController.cs`: Control AI vehicles and traffic.
	- `PoliceFollow.cs`: Police car chase logic.
	- `GameTimer.cs`: Manages the countdown timer and triggers win/lose.
	- `ResultUI.cs`, `PauseManager.cs`: UI logic for results and pausing.
	- `GameManager.cs`, `DeliveryManager.cs`: Game state and delivery logic.
- **Prefabs/**: Reusable GameObjects, such as:
	- Player and AI vehicle prefabs
	- Delivery point prefab
	- UI panels (pause, result, etc.)
- **Resources/**: Fonts, icons, and assets loaded dynamically at runtime.
- **Textures/**: All textures and materials for 3D models and UI elements.
- **Loading Games/**: Contains 3D models, city assets, and environment props (e.g., Toon City Pack models).
- **Images/**: UI icons, button sprites, and other image assets.
- **Animation/**: Animation clips and controllers for vehicles, UI, and effects.
- **Gley/**: (If present) Third-party plugins or asset store tools.
- **Editor/**: Scripts for custom Unity editor tools or inspectors.

### Example Scenes in Scenes/
- `MainMenu.unity`: The main menu scene.
- `LevelSelection.unity`: Level selection screen.
- `GameScene_level_1.unity`, `GameScene_level_2.unity`, ...: Main gameplay scenes for each level.
- `GameOver.unity`: Result screen after win/lose.

### Example Prefabs in Prefabs/
- `PlayerCar.prefab`: The player’s vehicle.
- `AICar.prefab`, `AITruck.prefab`, `PoliceCar.prefab`: AI-controlled vehicles.
- `DeliveryPoint.prefab`: The delivery target.
- `PausePanel.prefab`, `ResultPanel.prefab`: UI panels for pause and results.

### Example Scripts in Scripts/
- `PlayerCarController.cs`: Player driving logic.
- `AITruckController.cs`, `AICarController.cs`: AI vehicle logic.
- `PoliceFollow.cs`: Police chase behavior.
- `GameTimer.cs`: Timer and time-based events.
- `ResultUI.cs`: Displays win/lose results.
- `PauseManager.cs`: Pause and resume logic.
- `GameManager.cs`: Manages overall game state and transitions.
- `DeliveryManager.cs`: Handles delivery objectives and completion.

---

---

---

## 🎮 Phase 1: How to Play

**Controls:**
- WASD / Arrow Keys: Drive
- Space: Brake
- Esc: Pause
- Mouse: UI navigation

**Gameplay Mechanics:**
- Start from the main menu and select a level.
- Drive your delivery vehicle through the city, following the GPS arrow.
- Avoid obstacles, traffic, and police cars.
- Reach the delivery point before time runs out to win.
- If time runs out or you’re caught by police, you lose.

---

## 💻 Phase 2: System Requirements

- **OS:** Windows 10/11 (64-bit)
- **CPU:** Intel i3 or equivalent
- **RAM:** 4 GB minimum
- **GPU:** Integrated or dedicated GPU with DirectX 11 support
- **Disk:** 1 GB free space
- **Unity Version:** 2021.3 LTS or newer

---

## 📖 Phase 3: About the Game

**Story & Setting:**
You are a delivery driver in a vibrant, cartoon-style city. Your mission: deliver packages quickly and safely while navigating traffic, avoiding obstacles, and evading police.

**Gameplay Overview:**
- Multiple city levels with increasing difficulty
- Timer-based delivery challenge
- Police chases and AI traffic
- Result UI for win/lose feedback

---

## ⭐ Phase 4: Unique Features

- AI-driven traffic and police pursuit
- 3D GPS arrow navigation
- Animated UI icons for time warnings
- Modular vehicle and delivery system
- Multiple levels and result screens

---

## 🔧 Phase 5: Technical Report

**Architecture:**
- Modular C# scripts for player, AI, UI, and game management
- Scene-based structure: Main Menu, Level Selection, Game Levels, Result
- Uses Unity’s physics engine for realistic vehicle movement

**Key Code Components:**
- `PlayerCarController`: Handles player input and movement
- `AITruckController` & `AICarController`: AI vehicle logic
- `PoliceFollow`: Police chase behavior
- `GameTimer`: Timer and time-based events
- `ResultUI`: Displays win/lose results
- `PauseManager`: Pause and resume logic

---

## 🚀 Resources

- 3D assets: [Toon City Pack](https://assetstore.unity.com/packages/3d/environments/urban/toon-city-pack-95214)
- Fonts: TextMesh Pro
- Unity Asset Store resources

---


## 📦 Phase 6: Release Version

- **Download the Game:**
	- [Download Delivery Guy (Windows .exe)](https://github.com/hengputh52/Delivery-Guy/releases/download/Delivery_Guy_Game/Deliery.Guy.3d.Game.zip)

- **Build Instructions:**
	- Open the project in Unity.
	- Add all scenes to Build Settings.
	- Build for Windows platform (output in `Builds/` folder).

- **Documentation PDF:**
	- [Read the Game Documentation (PDF)](https://drive.google.com/drive/folders/1muKAmZsYnmQA69Vbp5BrA4iTO76a4gS7?usp=sharing)

---

---

## 📚 Phase 7: Documentation & Tools

- All scripts are documented with comments.
- See `/Assets/Scripts/` for code organization.
- Use Unity Editor for scene and prefab management.
- [Unity Documentation](https://docs.unity3d.com/Manual/index.html)

---

## 🤝 Phase 8: Contributing Guide

1. Fork the repository
2. Create a feature branch
3. Commit your changes with clear messages
4. Submit a pull request
5. Follow Unity C# coding standards

---

## 👥 Phase 9: Credits

- **Development:** Project contributors
- **3D Assets:** Polyart Studio, Unity Asset Store
- **Fonts:** TextMesh Pro
- **Special Thanks:** Unity community and testers

---

## License
This project is for educational and personal use. See LICENSE file for details.

---

## Teamwork
CADT-Gen10-SE-Group2

1. Lon Mengheng
2. Vy Vicheka
3. Sophal Taingchhay
4. Panha Viraktitya
5. May Kunaphivath