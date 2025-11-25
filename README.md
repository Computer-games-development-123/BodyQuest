# BodyQuest

<img width="1024" height="1536" alt="body quest" src="https://github.com/user-attachments/assets/409813ba-6a00-4085-9503-f729d2ead457" />

## 🎮 Game Title: BodyQuest
**Genre:** Simulation / Educational Adventure / Health Awareness  
**Team Members:** Itzhak Bista, Adir Ofir  
**Wiki Link:** https://github.com/Computer-games-development-123/BodyQuest/wiki/Formal-Elements-and-Market-Research
**Itch.IO Link:** https://imrfatty.itch.io/body-quest

---

# 1. Game Overview
BodyQuest is an educational adventure set inside the human body.  
You control a tiny explorer navigating organs and biological systems while collecting healthy items, avoiding viruses, and managing **Health**, **Energy**, and **Mood**.

Your goal is to survive, make healthy decisions, and see how choices affect the body in real time.

---

# 2. Core Loop (Prototype)

**Explore → Collect Items → Stats Change → Survive Timer → Win / Lose**

### Player Actions:
- Move through a 2D “organ” environment  
- Collect:  
  - **HealthyFood** → Increases Health & Energy  
  - **JunkFood** → Gives Energy boost but lowers Health & Mood  
  - **Virus** → Damages Health & lowers Mood  
- Watch stats change in real time  
- Survive until timer ends → **Win**  
- Health reaches 0 → **Game Over**

---

# 3. Player Stats System

| Stat   | Description | Affected By |
|--------|-------------|-------------|
| **Health** | Overall health status | HealthyFood, JunkFood, Virus |
| **Energy** | Energy level | Food items |
| **Mood** | Emotional state | JunkFood, Virus |

Stats are clamped between **0–100** and displayed via UI sliders.

---

# 4. Technical Architecture (Unity)

## Project Structure
```
Assets/
  Scenes/
    BodyQuest_Prototype.unity

  Scripts/
    Player/
      PlayerController.cs
      PlayerStats.cs

    World/
      HealthyFood.cs
      JunkFood.cs
      Virus.cs

    Managers/
      GameManager.cs
      UIManager.cs
      SpawnManager.cs

  Prefabs/
    Player.prefab
    HealthyFood.prefab
    JunkFood.prefab
    Virus.prefab
```

## UI System
- Health / Energy / Mood sliders  
- Timer text  
- Win Panel  
- Game Over Panel  

---

# 5. UML (Text Diagram)

```
                   ┌──────────────────┐
                   │   GameManager    │
                   ├──────────────────┤
                   │ - state          │
                   │ - levelTimer     │
                   ├──────────────────┤
                   │ + Win()          │
                   │ + GameOver()     │
                   │ + RestartLevel() │
                   └───────▲──────────┘
                           │
                           │ uses
                           │
┌──────────────────┐   ┌──────────────────┐
│    UIManager     │   │   PlayerStats    │
├──────────────────┤   ├──────────────────┤
│ - healthBar      │   │ + Health         │
│ - energyBar      │   │ + Energy         │
│ - moodBar        │   │ + Mood           │
├──────────────────┤   ├──────────────────┤
│ + UpdateStats()  │   │ + AddHealth()    │
└──────────────────┘   │ + AddEnergy()    │
                       │ + AddMood()      │
                       │ + IsDead()       │
                       └─────▲────────────┘
                             │
                             │ affected by pickups

         ┌────────────────────────────────────────────────────┐
         │                   Pickup Objects                    │
         └────────────────────────────────────────────────────┘
        ┌──────────────────┐ ┌────────────────────┐ ┌──────────────────┐
        │  HealthyFood     │ │     JunkFood       │ │      Virus       │
        ├──────────────────┤ ├────────────────────┤ ├──────────────────┤
        │ + OnTrigger...   │ │ + OnTrigger...     │ │ + OnTrigger...   │
        │ → AddHealth      │ │ → AddEnergy        │ │ → AddHealth(-)   │
        │ → AddEnergy      │ │ → AddMood(-)       │ │ → AddMood(-)     │
        └──────────────────┘ └────────────────────┘ └──────────────────┘

                    ┌──────────────────┐
                    │ PlayerController │
                    ├──────────────────┤
                    │ Reads input      │
                    │ Moves Rigidbody2D│
                    └──────────────────┘
```

---

# 6. Implemented Prototype Features

### ✔ Player Controller  
2D movement using Rigidbody2D.

### ✔ Stats System  
Health / Energy / Mood updating live.

### ✔ Pickup Mechanics  
HealthyFood, JunkFood, Virus with unique effects.

### ✔ UI  
Bars + Timer + Win/Game Over panels.

### ✔ Game Flow  
- Survive timer = Win  
- Health 0 = Game Over  

### ✔ Spawn System (Optional)  
Random spawning of pickups over time.

---

# 7. How to Run

1. Open **Unity (2022 or newer)**.  
2. Open project directory:  
   ```
   BodyQuestGame/
   ```  
3. Load the scene:  
   ```
   Assets/Scenes/BodyQuest_Prototype.unity
   ```  
4. Press **Play**.  
5. Move with **Arrow Keys**.

---

# 8. Future Development

Features planned but not included in prototype:

- Multi-organ environments (Heart, Brain, Stomach…)  
- Mini-games (digestion, sleep cycle, exercise challenges)  
- Immune system mechanics  
- Infection waves & advanced enemies  
- XP + leveling  
- 2.5D / 3D visual upgrade  
- Story mode & quests  

---

# 9. Summary

BodyQuest’s prototype includes a full Core Loop, stat-based gameplay, feedback through UI, pickups, win/lose flow, and modular system design—ready for expansion into a full educational adventure.

