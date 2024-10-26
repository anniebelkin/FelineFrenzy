# FelineFrenzy

### <a name="_8vjhr7bl6gdz"></a>**Game Overview:**
"Feline Frenzy" is a strategic action-puzzle game where players control three different cat characters, each with unique abilities. The goal is to navigate various random traps scattered across the level and destroy them by switching between cats. Each cat is equipped to deal with specific traps but will face penalties if confronted with an unsuitable trap. Players must use strategy to switch between characters at the right moment and reach the finish line for victory.

-----
### <a name="_2rktfw6w08dw"></a>**Core Gameplay Mechanics:**
- **Three Playable Cat Characters:**
  - **Ginger Cat (The Plant Destroyer)**
    - **Ability:** Destroys potted plants (Trap 2)
    - **Description:** This mischievous cat is excellent at toppling potted plants with ease, dealing maximum damage to them. However, it's not useful for other traps.
    - **Damage:** Deals **50 damage** to plants. Deals **10 damage** to other traps.
  - **Black Cat (The Laser Specialist)**
    - **Ability:** Shoots laser beams to disable the Roomba (Trap 3)
    - **Description:** This nimble cat uses its laser vision to neutralize the Roomba traps efficiently. It doesn’t handle other traps as effectively.
    - **Damage:** Deals **50 damage** to Roomba. Deals **10 damage** to other traps.
  - **Fat White Cat (The Food Lover)**
    - **Ability:** Eats food traps (Trap 1)
    - **Description:** This chunky kitty loves food but moves slower than the others. It excels at devouring food traps but struggles with others.
    - **Damage:** Deals **50 damage** to food. Deals **10 damage** to other traps.
- **Trap System:**
  - **Trap 1 - Food Trap:**
    - Attracts the white fat cat. It slows down other cats but will be eaten by the white cat.
    - **Damage:** Causes **20 damage** to any cat that isn’t the white cat.
  - **Trap 2 - Potted Plants:**
    - A dangerous obstacle for all cats except the ginger cat, who can destroy it.
    - **Damage:** Causes **20 damage** to any cat that isn’t the ginger cat.
  - **Trap 3 - Roomba:**
    - Patrols the area, posing a threat to all but the black cat, who can disable it with its laser beam.
    - **Damage:** Causes **20 damage** to any cat that isn’t the black cat.
- **Random Trap Placement:**
  The traps are randomly placed at predetermined locations at the start of each level, adding a dynamic element to every playthrough.
- **Character Switching Mechanic:**
  Players can switch between cats at any time using a character switch button. Each cat must be used strategically to overcome the specific trap they are best suited for.
- **Trap Destruction and Damage:**
  - When the wrong cat confronts a trap, it deals **reduced damage** and receives **increased damage**.
    - **Wrong cat damage to trap:** **10 damage**
    - **Increased trap damage to wrong cat:** **20 damage**
- **Score System:**
  - Players earn points for successfully destroying traps with the correct cat.
  - **Bonus Points** are awarded for completing levels without taking too much damage.
  - **Penalty Points** are applied when a trap damages the wrong cat.
-----
### <a name="_s3hxwpo33mwp"></a>**Game Objective:**
- Players must navigate through the level, destroying the traps, and reach the end to achieve victory.
- The game ends successfully when all traps are destroyed and the player reaches the finish point with any cat still alive.
-----
### <a name="_2t7lh8r3eat4"></a>**End Conditions:**
- **Victory:**
  Reach the end of the level after destroying all traps using the correct cats.
- **Failure:**
  If all cats take too much damage and are unable to continue, the player loses the level.
-----
### <a name="_ptp52a1692hn"></a>**UI Elements:**
- **Character Switch Button:**
  Allows the player to switch between the three cats instantly.
- **Health Bars:**
  Display the health of each cat. Health decreases when a cat encounters the wrong trap.
- **Trap Damage Indicator:**
  Displays how much damage a trap does to the current cat.
- **Scoreboard:**
  Shows the total points earned by the player in the current level.
-----
### <a name="_cr5znmdrcwih"></a>**Damage Breakdown:**

|**Trap**|**Correct Cat Damage**|**Wrong Cat Damage**|**Trap Damage to Wrong Cat**|
| :-: | :-: | :-: | :-: |
|Food Trap|50 (White Cat)|10|20|
|Potted Plants|50 (Ginger Cat)|10|20|
|Roomba|50 (Black Cat)|10|20|

-----


