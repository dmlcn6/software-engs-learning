# software-engs-learning
The repo for up and coming SWEs

---
here is what we covered so far
- **Week 1: Development Environment & Version Control and Variables and Data Types**
    - Set up IDE, terminal, and command line tools
      - Resources
    - Git fundamentals: clone, commit, push, pull, branches
    - GitHub workflow and collaboration basics
    - *Project: Create first repository and practice branching practiced merging and PRs*
- **Sprint 1: Control Flow & Logic, Functions & Methods, Arrays & Collections, Strings, OOP, Calculator **
    - We successfully created calculators that followed this AC:
    - AC - Acceptance Criteria
      4 functions - Add Div Subtract Multi
      Display output to user
      disply equation
      display divide by 0 error
      2 point decimal outputs for division
      Show use of classes/functions to organize code

- **Sprint 2: Create Adventure Game **
    - Sun 11/30: Start
    - Tue 12/2: we are creating AC for our work item
      - user must be identified by player name (input)
      - at least 5 prompts before one of the endings
      - 2 endings: Win or Lose


      - show use of constructors, static classes
      - 4 Object Oriented Programming principles (inheritance, encapsulation, poly, abstraction) 
        - player (with or without hp)
        - meter, counter, hp, progress tracking, 
        - combat/competition
        - Usable items in inventory

- **Sprint 3: Create Adventure Game w OOP principles **
    - Sun 12/14: Start the week with reps on variable creation class creation accessMods keywords
    - We will dive heavier into 4 OOP principels while finishing our text based adventure  game
    - finished out our sprint by finishing the commmand line adventrure games with 4 oop principles

- **Sprint 4: Refactor Adventure game **
    - Sun 12/28: We are skipping Data Structure and Advanced Data Strucutres for now to progress to HTML and beyond
    - Mon 12/29: Reps on for/each while loops; 
    - Tue 12/30:
    - Tue 1/6: 
    - Wed 1/7: learned how to create a full solution / project c# strucutre
    - Fri 1/9: learned how to get rid of circular dependencies
    - the rest of the sprint was spent working on refactoring the adventure
    - schedule update, shifted 1 day to the left one day 
      - insted of Tue Wed Fri Sun
      - its now   Mon Tue Thur Sat

- **Sprint 5:  **
    - 1/14 - Wise missed 4 consecutive classes due to change of schedule and getting him caught up
    - 1/14 - Cozy set up his env on the laptop
    - 1/15 - Reps on DRY Code
    - 1/17 - We have identified the next sprint work! AC
      - 
        ---
        Path 1: The "Architectural" System (Encapsulation & Interfaces)
        1. **Enhance the Logging System** - Ability to log to console and/or local .txt file:
          - Using an ILogger interface and polymorphism on the Send()
        
        2. **Optimization Tasks**
          - Rename Abstract Classes: Change ICharacter to CharacterBase and IUsableItem to ItemBase.
          - Introduce Real Interfaces: Create an actual interface IDamageable that forces anything that can be attacked to have an ApplyDamage(int amount) method.
          - Encapsulate Player _hp using public/private class members and getter/setters


        Path 2: The "Equipment System" (Composition vs. Inheritance)
        1. **Create specific Slots**
          -  Add a property public IUsableItem EquippedWeapon { get; set; } to the Player class.

        2. **Modify the Inventory System**
          - Split the concept of "Backpack" (List of items) vs "Equipped" (Active items).
          - Create a method EquipItem(int inventoryIndex) that moves an item from the backpack to the EquippedWeapon slot.
          - Update Dmg calculateion

        3. **Equipment System**
          - Item Equipment System - Create an Equipment subclass (Armor, Helmets, Rings) that provide stat bonuses when equipped (not consumed). This teaches:

          - Inheritance hierarchy beyond just consumables
          - Active/passive effects vs consumable effects
          - State management (equipped vs unequipped)


        Path 3: The "Dungeon Crawler" (2D Arrays & Coordinates)
        1. **The Map**
          - Create a 2D array in Program.cs. string[,] map = new string[5,5];
          - Coordinates: Give the Player int x and int y properties.
        2. **The Game Loop**
            - the main loop asks: "North, South, East, or West?"
            - Update x and y based on input.
            - Check map[x,y]. Is it an "Enemy"? If yes, trigger the EnemyEncounter function you already wrote.
            - Is it a "Chest"? Trigger a new LootDrop function.

        3. **Shop/Upgrade System** - A between-battle menu where players spend resources:
          - Currency system (gold drops from enemies or other spaces)
          - buy items 

        4. Optional - **Skill/Ability System** - Let players unlock special attacks as they level up:
          ```csharp
          // New concept: polymorphic abilities
          public interface IAbility {
              void Execute(ICharacter target);
              int CooldownTurns { get; }
          }
          
          public class PowerAttack : IAbility { }
          public class Heal : IAbility { }
          ```
        5. Optional - **Difficulty Scaling** - Procedural enemy generation:
          - Create enemies with random stats based on player level
          - Teaches factory patterns and algorithm design
        ---
    - 1/19
        - Today we are starting the game v2
    - 1/24
        - Getter/Setter, Created 2 new Item Base classes for equippable or consumable items, Add EquippedWeapon to CharBase.

- ** Spint 8: Develop a Blog**
    - 3/28 - Wise & Gramps played a CSS game called "Grid Attack"
    - 3/29 - Cozy & Gramps played "Grid Attack" as well.
    - AC - Accemptance Criteria
      Title, Must stand out from rest of text. Clearly recognizable as the title.
        - Import a Google font
      Logo, in Top Left or Middle. (Can be sourced from wherever)
      Grid
        - Use a container for the group of posts
        - Use a container for the header, logo, title, and "about" links
        - Use row/column gaps
      "About" page
        - Linked-to from Homepage and can link back-to homepage
      Each Post
        - Distinct rows
        - Date/Time Logging
        - Title
        - Location
        - Images
        - Text Passage
        - Share Button (using html anchors)
        - Tags for each topic
- ** 4/22 : Discussed Coding Principles **
  - "Review every line of every Pull Request"
  - "After every session, commit all changes"
- ** 4/27 : How to teach new subjects **
  - What is it? ex What is JavaScript
  -


Tyree made this Change 11/14/25+

Rocket has something of a rough around the edges attitude. Rocket is a brash, hot headed, snarky and trigger happy raccoon, it takes very little to set off his temper, being called a raccoon being one of them (which he is). He is also a bit of a kleptomaniac, often stealing things that he can get his paws on, including stuff from other heroes like Peni’s mech, Frank’s turret and so on. While it’s these traits that makes it difficult For Rocket to get along with others (Star-Lord included) and his status as a hero questionable, he is not without his perks, one of them being his rarely expressed kindness and care for his friends, including his closest friend, Groot. Rocket possesses a highly advanced knowledge of technology and a tactical mindset, often using those gifts in fixing up the ship or making a plan for any problems he and his team run into. Rocket’s source of his anger is from his past of being painfully experimented on, and it’s that pain that often leads him to push others away, so that he never feels that pain again.

This week went really well!
I'm having a blast brushing up on my coding skills!

T-Rex late changes.....Sickle Cell Sucks but I can smoke Weed!!! I also love to eat butt.
Let's Code

Maccom in dis bitch!!
Big line 2 test 