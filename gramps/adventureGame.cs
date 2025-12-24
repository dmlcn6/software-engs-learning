

namespace AdventureGame
{
    #region GAME LOGIC
    public static class Game
    {
        // player declaration lives on the class
        public static Player player1;

        public static void Main(string[] args)
        {
            //i want to fill in the class variable with the new instance
            player1 = new Player();
            // i want to know how many enemies the player has killed
            var killCount = 0;
            // i want the player to fight until the end
            var keepFighting = true;
            do
            {
                // create a tinymonster for the first 4 kills, then fight the boss for your final battle
                Character enemy;
                if (player1.killCount < 4)
                {
                    enemy = new TinyMonster();
                }
                else
                {
                    player1._inventory.Add(new HiPotion());
                    enemy = new Boss();
                }

                // run the encounter, until someone dies
                var player1SurvivedFight = EnemyEncounter(enemy);

                // keepfighting is true when the player survived the encounter and did not get 5 kills yet
                // if the player died in the enemey encounter or their kills count is 5 or more
                // then keepfighting will be false
                keepFighting = player1SurvivedFight && player1.killCount < 5;

                // after each encounter, checke if the player won
                if (player1.killCount == 5)
                {
                    Console.WriteLine("You've endured your first set of Trials! and deserve a new Weapon");
                    Console.WriteLine("You've won!");
                    return;
                }

            } while (keepFighting);

            Console.WriteLine("You have died! Get a 5 monster kill streak to proceede.");
            Console.WriteLine("GAMEOVER!");
        }

        private static bool EnemyEncounter(Character enemy)
        {
            // I want to alternate attacking/ item use, starting with the player 
            // until someone dies

            do
            {
                Console.WriteLine("");
                Console.WriteLine("Select your action: number");
                Console.WriteLine("");
                Console.WriteLine("1. Attack");
                Console.WriteLine("2. Use Item");

                // get the users input w ConsoleReadLine
                // try to parse it to an integer
                // whether the parse is succ or not, the function TryParse() returns a bool the bool is captured in isChoice
                // if the parse is successful, TryParse() will output the parsed string into the new variable type
                var isChoice = int.TryParse(Console.ReadLine(), out int choice);

                if (isChoice)
                {
                    switch (choice)
                    {
                        case 1:
                            player1.Attack(enemy);
                            break;

                        case 2:
                            Console.WriteLine("");
                            Console.WriteLine("Here is your inventory: ");


                            var localInventory = player1._inventory;


                            for (var i = 0; i < localInventory.Count; i++)
                            {
                                Console.WriteLine($"{i}: {localInventory[i].name}");
                            }
                            Console.WriteLine("");
                            Console.WriteLine("Select your item number: ");


                            var isItemChoice = int.TryParse(Console.ReadLine(), out int itemChoice);

                            if (isItemChoice)
                            {
                                player1._inventory[itemChoice].Use(player1);
                                Console.WriteLine("");
                                Console.WriteLine("Item used successfully");
                                player1.ViewStats();
                            }
                            else
                            {
                                // you didnt provide a proper choice
                            }
                            break;
                    }
                }
                else
                {
                    // you didnt provide a proper choise
                }

                if (enemy.IsAlive())
                {
                    enemy.Attack(player1);
                }
            } while (player1.IsAlive() && enemy.IsAlive());


            // returns if the player survived the encounter
            return player1.IsAlive();
        }
    }
    #endregion

    #region CHARACTERS

    public abstract class Character
    {
        public int _dmg = 4;


        public int _hp = 20;

        public string _name;

        public List<UsableItem> _inventory;

        public bool _dead = false;

        public Character()
        {
            // create players new inventory
            _inventory = new List<UsableItem>();

            // player spawn with base item
            _inventory.Add(new Sword());
        }

        public abstract void Attack(Character victim);

        public void ViewStats()
        {
            Console.WriteLine("");
            Console.WriteLine($"{_name} Stats:  DMG: {_dmg}, HP: {_hp}");
            Console.WriteLine("");
        }

        public bool AttackedBy(Character attacker)
        {
            //int _hp = 0;
            _hp -= attacker.GetDmg();  // same as _hp = _hp - attacker.dmg

            ViewStats();
            attacker.ViewStats();

            if (_hp <= 0)
            {
                Dead();
                return true;
            }


            return false;
        }

        public int GetDmg()
        {
            return _inventory[0].amountOfEffectToHp + _dmg;
        }

        public virtual void Dead()
        {
            Console.WriteLine($"[{_name}]: I i Wait please help me! im Dying ple- Please, i cant fe- .....");
            _dead = true;
        }

        public bool IsAlive()
        {
            return !_dead;
        }
    }

    public class Player : Character
    {
        public int killCount = 0;
        public Player()
        {
            _name = "Player 1";
            _inventory.Add(new Potion());
        }

        public override void Attack(Character victim)
        {
            var victimIsDead = victim.AttackedBy(this);
            if (victimIsDead)
            {

                killCount += 1;
                // everytime Player kills a monster, they get 1 health potion
                _inventory.Add(new Potion());

                _dmg += 11;
            }
        }

        public override void Dead()
        {
            Console.WriteLine($"[{_name}]: I will never stop! ...");
            _dead = true;
        }
    }

    public class TinyMonster : Character
    {
        public TinyMonster()
        {
            _name = "Tiny Monster";
        }

        public override void Attack(Character victim)
        {
            Console.WriteLine($"[{_name}]: ** in high pitch ** THIS IS GOnNA HURT!!");
            var victimIsDead = victim.AttackedBy(this);
            if (victimIsDead)
            {
                // everytime a TinyMonster kills a character, they scream
                Console.WriteLine($"[{_name}]: ** in high pitch ** DIE DIE DIE!!");
            }
        }


    }

    public class Boss : Character
    {
        public Boss()
        {
            _name = "First FInal Boss";
            _dmg = 50;
            _hp = 200;
        }

        public override void Attack(Character victim)
        {
            var victimIsDead = victim.AttackedBy(this);
            if (victimIsDead)
            {
                // everytime a Boss kills a character, they scream
                Console.WriteLine($"[{_name}]: GOODBYE ONCE AND FOR ALL {victim._name}! ");
            }
        }

        public override void Dead()
        {
            Console.WriteLine($"[{_name}]: **NOooo NO N)O@!, i'll never y-yi-YIEield! Iim THE lORD of EvilL! !!!");
            _dead = true;
        }
    }

    #endregion

    #region ITEMS
    public abstract class UsableItem
    {
        public abstract int amountOfEffectToHp { get; set; }

        public abstract string name { get; set; }

        public abstract int Use(Character victim);

        public void Alert()
        {
            Console.WriteLine("Alert");
        }
    }

    public class Potion : UsableItem
    {
        public override int amountOfEffectToHp { get; set; }
        public override string name { get; set; }

        public Potion()
        {
            amountOfEffectToHp = 50;
            name = "Potion";
        }

        public override int Use(Character character)
        {
            character._hp = amountOfEffectToHp + character._hp;
            character._inventory.Remove(this);
            return character._hp;
        }
    }

    public class HiPotion : UsableItem
    {
        public override int amountOfEffectToHp { get; set; }
        public override string name { get; set; }

        public HiPotion()
        {
            amountOfEffectToHp = 150;
            name = "Hi Potion";
        }

        public override int Use(Character character)
        {
            character._hp = amountOfEffectToHp + character._hp;
            character._inventory.Remove(this);
            return character._hp;
        }
    }

    public class Sword : UsableItem
    {
        public override int amountOfEffectToHp { get; set; }
        public override string name { get; set; }

        public Sword()
        {
            amountOfEffectToHp = 10;
            name = "Sword";
        }

        public override int Use(Character character)
        {
            character._hp -= amountOfEffectToHp;
            return character._hp;
        }
    }
    #endregion
}
