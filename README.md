# Delivery Guy

A Unity3D driving and delivery game where you play as a delivery driver navigating a city, avoiding obstacles, and racing against the clock to deliver packages!

## Features
- **Player Car**: Drive and control your delivery vehicle.
- **AI Traffic**: Cars, trucks, and police with AI navigation and pursuit.
- **Police Chase**: Police cars can chase the player if rules are broken.
- **Delivery System**: Reach delivery points to complete objectives.
- **Timer**: Beat the clock to succeed; result UI shows win/lose.
- **Pause & UI**: Pause menu, level selection, and result screens.
- **Multiple Levels**: Select and play different city levels.
- **GPS Arrow**: 3D arrow guides you to your next delivery.

## Project Structure
- `Assets/Scenes/` — Game scenes and levels
- `Assets/Scripts/` — All C# scripts (AI, player, UI, etc.)
- `Assets/Prefabs/` — Prefab vehicles, delivery points, etc.
- `Assets/Resources/` — Fonts, icons, and other resources
- `Assets/Textures/` — Textures and materials
- `Assets/Loading Games/` — 3D models and city assets

## How to Play
1. **Start the Game**: Launch from the main menu.
2. **Select Level**: Choose a level from the Level Selection screen.
3. **Drive**: Use WASD or arrow keys to control your car.
4. **Deliver**: Follow the GPS arrow to the delivery point.
5. **Avoid Police**: Don’t break the rules or police will chase you!
6. **Beat the Timer**: Deliver before time runs out.

## Controls
- **WASD / Arrow Keys**: Drive
- **Space**: Brake
- **Esc**: Pause
- **Mouse**: UI navigation

## Development
- Built with **Unity 2021+**
- C# scripts for all gameplay logic
- Modular AI and player controller scripts
- Uses Unity’s physics and UI systems

## Setup
1. Open the project in Unity.
2. Add all scenes to **File > Build Settings**.
3. Assign references in the Inspector (ResultUI, GameTimer, DeliveryManager, etc.).
4. Play and enjoy!

## Credits
- 3D assets: [Toon City Pack](https://assetstore.unity.com/packages/3d/environments/urban/toon-city-pack-95214)
- Fonts: TextMesh Pro
- Code: Project contributors

## License
This project is for educational and personal use. See LICENSE file for details.
