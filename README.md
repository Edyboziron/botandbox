# Box and Bot

[![Unity](https://img.shields.io/badge/Unity-6000.3.22f1%20(Unity%206)-blue.svg?logo=unity)](https://unity.com/)
[![Render Pipeline](https://img.shields.io/badge/Render%20Pipeline-URP%202D-green.svg)](https://unity.com/srp/Universal-Render-Pipeline)
[![Event](https://img.shields.io/badge/Event-Ma%C4%9Fara%20Jam-orange.svg)](https://magarajam.com/)
[![Theme](https://img.shields.io/badge/Theme-%22Birbirine%20ba%C4%9Fl%C4%B1%22%20(Bound%20Together)-purple.svg)](#theme--concept)

> **"A humanoid arrives at the hospital, and we must transport the essential medicine to where it needs to go inside the body."**

**Box and Bot** is a physics-based 2D puzzle-platformer developed for the **Mağara Jam** game jam, created around the theme **"Birbirine bağlı" (Bound Together / Interconnected)**.

---

## 📖 Story & Concept

A critically ill Humanoid arrives at the emergency medical facility requiring urgent internal intervention. To administer the cure, a high-tech medical robot (**Bot**) and a secure medicine container (**Box**) are dispatched directly into the patient's body.

Tethered together by a physics-driven chain, **Bot** and **Box** must coordinate their movements to navigate treacherous biological corridors, solve mechanical puzzles, defeat hostile pathogens, and deliver the medicine to its final destination.

---

## 🎮 Gameplay & Core Features

### 🔗 Physics-Based Tether Mechanic
- **Verlet-Style Chain Distance Constraint (`ChainDistanceConstraint.cs`)**: The robot and the medicine box are physically coupled via an iterative position-based constraint solver, preventing the chain from overstretching while maintaining realistic tension and swing physics.
- **Rope Limit & Oscillation Damping (`RopeLimit.cs`, `RopeStabilizer.cs`)**: Prevents unnatural clipping and dampens physics oscillations, allowing smooth platforming even with dynamic rigidbodies attached.

### 🏃 Movement & Platforming
- Responsive 2D platformer movement with acceleration and directional flipping.
- **Wall Sliding & Wall Jumps**: Allows Bot to scale vertical walls and bypass hazardous drops.

### 🧩 Puzzles & Interactive Environment
- **Levers & Mechanisms (`LeverController.cs`)**: Levers can be flipped manually by player interaction or remotely by shooting them with projectiles.
- **Elevators & Moving Platforms (`ElevatorController.cs`)**: Smooth vertical lifts to transport Bot and Box across multiple floor levels.
- **Rotating Security Doors (`DoorController.cs`)**: Automated and triggered barrier doors that open upon puzzle completion.

### 💥 Combat & Hazards
- **Shooting Mechanism (`Bullet.cs`)**: Bot fires energy projectiles to eliminate pathogens and activate distant switches.
- **Hostile Pathogens (`Enemy.cs`)**: Biological enemies that detect and pursue the player when within proximity.
- **Environmental Hazards (`SceneResetTrigger.cs`)**: Hazardous acid pools and spike zones that reset the level if either Bot or Box falls into them.

---

## 🕹️ Controls

| Action | Key / Input |
| :--- | :--- |
| **Move Left / Right** | `A` / `D` or `Left Arrow` / `Right Arrow` |
| **Jump / Wall Jump** | `Spacebar` |
| **Shoot Projectile** | `Left Mouse Button` |
| **Interact (Pull Lever)** | `E` *(or shoot the lever)* |
| **Restart Level** | `R` |

---

## 🗺️ Levels & Stages

1. **Main Menu (`MAİNMENU.unity`)**: Audio controls, settings, and level entrance.
2. **Laboratory & Deployment (`GAME.unity`)**: The medical bay where Bot and Box are introduced, tethered together, and sent on their journey.
3. **The Esophagus (`yemek.unity`)**: A vertical descent stage featuring vertical camera tracking (`CameraFollowY.cs`), dodging biological hazards while controlling falling speed.
4. **The Stomach (`mide.unity`)**: A complex puzzle stage with digestive acid pits, elevator systems, door puzzles, and enemy encounters.
5. **Final Destination (`bitonzi.unity`)**: The final delivery of the medicine, successfully healing the patient.

---

## 👥 Credits & Roles

Developed during **Mağara Jam**:

- **Enes Bozdemir** — *Game Development & Level Design*
  - Gameplay programming, chain constraint physics simulation, mechanics implementation, camera systems, and level design.
- **Kenan Ay** — *2D Art & Visual Assets*
  - Character design (Bot, Box, Humanoid), 2D environment illustrations, backgrounds, and user interface art.

---

## 🛠️ Tech Stack & Engine Specifications

- **Engine**: Unity 6 (`6000.3.22f1`)
- **Rendering Pipeline**: Universal Render Pipeline (URP 2D)
- **Physics Engine**: Unity 2D Physics (Rigidbody2D, BoxCollider2D, CircleCollider2D, PhysicsMaterial2D)
- **Language**: C# (.NET Standard)
- **Audio**: 2D Sound Effects & Looping Ambient Soundtrack

---

## 📁 Project Structure

```
Assets/
├── Audio/            # Sound effects and music tracks (gunshot WAV, background lounge MP3)
├── Prefabs/          # Player (Bot), Box, Bullet, Lever, Door, Elevator, Enemies
├── Scenes/           # All game stages (MAINMENU, GAME, yemek, mide, bitonzi)
├── Scripts/          # Clean, modular C# scripts
│   ├── Bullet.cs
│   ├── ButtonSound.cs
│   ├── CameraFollow.cs
│   ├── CameraFollowY.cs
│   ├── ChainDistanceConstraint.cs   # Core chain solver (formerly deneme.cs)
│   ├── DoorController.cs
│   ├── ElevatorController.cs
│   ├── Enemy.cs
│   ├── LeverController.cs
│   ├── MenuManager.cs
│   ├── MusicManager.cs
│   ├── MusicVolumeSlider.cs
│   ├── PlayerController.cs
│   ├── RopeLimit.cs
│   ├── RopeStabilizer.cs
│   ├── SceneChanger.cs
│   ├── SceneMusic.cs
│   ├── SceneResetKey.cs
│   └── SceneResetTrigger.cs
├── Settings/         # URP 2D Render Pipeline settings and scene templates
└── Sprites/          # 2D character sprites, UI buttons, backgrounds, and level art
```

---

## 🚀 Getting Started

1. Clone the repository:
   ```bash
   git clone https://github.com/your-username/botandbox.git
   ```
2. Open the project in **Unity 6000.3.22f1** or newer.
3. Open `Assets/Scenes/MAİNMENU.unity` in the Project window.
4. Press **Play** in the Unity Editor to experience the game!
