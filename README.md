
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

- **Download:** [Coming Soon]
- **Build:** Open in Unity, add all scenes to Build Settings, and build for Windows.

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
