# Jungle Defense 2023

A 2D tower defense game built with Unity for mobile platforms. Defend your castle from waves of enemies using strategic shooting and powerful abilities.

## 🎮 Game Overview

Jungle Defense is a mobile-optimized tower defense game where players must protect their castle from incoming waves of enemies. The game features multiple levels with increasing difficulty, various enemy types, and special power-ups to help in the defense.

### Key Features

- **5 Challenging Levels**: Each level introduces new enemy combinations and increased difficulty
- **Multiple Enemy Types**: 5 different enemy types with unique characteristics:
  - 🍄 Mushroom (100 HP, Speed: 0.25f)
  - 🌿 Bush (150 HP, Speed: 0.2f)
  - 🗑️ Trash Can (250 HP, Speed: 0.1f)
  - 🌲 Pine Cord (350 HP, Speed: 0.1f)
  - 🐱 Cat (200 HP, Speed: 0.3f)
- **Power-ups System**:
  - ⚡ Lightning Strike: Area damage to all enemies (5s cooldown)
  - 🔥 Fireball: Powerful projectile that destroys enemies instantly (7s cooldown)
- **Mobile-Optimized Controls**: Touch-based aiming and shooting
- **Star Rating System**: Earn up to 3 stars per level based on performance
- **Health System**: Both castle and enemies have health bars
- **Dynamic Enemy Spawning**: Enemies spawn from elliptical patterns around the castle

## 🎯 How to Play

1. **Aim**: Touch and drag to aim your shooter at incoming enemies
2. **Shoot**: Tap to fire bullets at enemies
3. **Use Power-ups**: 
   - Tap the lightning button for area damage
   - Tap the fireball button for a powerful shot
4. **Defend**: Prevent enemies from reaching and destroying your castle
5. **Win**: Eliminate all enemies in the wave to complete the level

## 🛠️ Technical Details

### Built With
- **Unity 2022.3.x**: Game engine
- **C#**: Programming language
- **Unity 2D**: For mobile-optimized 2D gameplay
- **TextMeshPro**: For UI text rendering

### Project Structure

```
Assets/
├── Scenes/              # Game scenes (Home, Levels 1-5, Level Select)
├── Scripts/             # C# game logic scripts
├── Sprites/             # 2D artwork and textures
├── Prefabs/             # Reusable game objects
├── Animations/          # Animation files
├── Sound Effects/       # Audio files
├── UI/                  # User interface elements
└── Game Assets/         # Additional game resources
```

### Key Scripts

- **`Controller.cs`**: Main game controller handling UI, scoring, and game states
- **`EnemyMechanics.cs`**: Enemy behavior, movement, and combat logic
- **`EnemySpawner.cs`**: Manages enemy wave spawning patterns
- **`Bullet_Mechanics.cs`**: Projectile physics and collision detection
- **`Shoot.cs`**: Player shooting mechanics and input handling
- **`Powerups.cs`**: Lightning and fireball ability systems
- **`HealthBar.cs`**: Health management for castle and enemies
- **`Shooter.cs`**: Aiming and rotation mechanics for PC and mobile

## 🎮 Controls

### Mobile (Primary)
- **Aim**: Touch and drag to rotate the shooter
- **Shoot**: Single tap to fire
- **Power-ups**: Tap the respective power-up buttons

### PC (Development/Testing)
- **Aim**: Mouse movement
- **Shoot**: Left mouse click
- **Power-ups**: Click the power-up buttons

## 🎨 Game Features

### Enemy Spawning System
- Enemies spawn in elliptical patterns around the castle
- Different enemy combinations per level
- Progressive difficulty scaling
- Spawn rates: Level 1 (30 enemies) → Level 5 (70 enemies)

### Combat System
- Bullet rotation and physics
- Recoil system when enemies are hit
- Different damage values for bullets vs fireballs
- Area-of-effect lightning damage

### UI/UX Features
- Pause functionality
- Game over and victory screens
- Score tracking
- Star rating system
- Tutorial elements for first-time players
- Mobile-optimized interface

## 🚀 Getting Started

### Prerequisites
- Unity 2022.3.x or later
- Android SDK (for Android builds)
- Xcode (for iOS builds)

### Installation
1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/JungleDefense2023.git
   ```
2. Open the project in Unity Hub
3. Open the `Home Screen` scene to start
4. Press Play to test in the editor

### Building for Mobile
1. Go to `File > Build Settings`
2. Select your target platform (Android/iOS)
3. Configure player settings in `Edit > Project Settings > Player`
4. Build and deploy to your device

## 📱 Platform Support

- **Primary**: Android (API Level 19+)
- **Secondary**: iOS (iOS 12.0+)
- **Development**: Windows/Mac/Linux (Unity Editor)

## 🏗️ Development Team

**Place Holders** - Game Development Studio

## 📄 Version History

- **v1.0.2**: Current version with mobile optimizations
- **v1.0.0**: Initial release

## 🎵 Audio

The game features:
- Background music for different scenes
- Sound effects for shooting, explosions, and UI interactions
- Enemy movement and damage audio
- Power-up activation sounds

## 🤝 Contributing

This appears to be a student/educational project. If you'd like to contribute or suggest improvements:

1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Submit a pull request

## 📜 License

Please check with the development team regarding licensing terms.

## 🐛 Known Issues

- Check the Unity console for any compilation errors
- Ensure all asset references are properly linked
- Mobile touch input may need calibration on different devices

## 📞 Support

For technical issues or questions about the game, please contact the development team or create an issue in the repository.

---

*Built with ❤️ using Unity 2022.3*
