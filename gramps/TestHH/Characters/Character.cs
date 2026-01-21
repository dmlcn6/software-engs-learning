
using TestHH.Items;

namespace TestHH.Characters
{

    #region CHARACTERS

    public class Player : ICharacter
    {
        public int killCount = 0;
        public Player()
        {
            _name = "Player 1";
            _inventory.Add(new Potion());
        }

        public override void Attack(ICharacter victim)
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

    public class TinyMonster : ICharacter
    {
        public TinyMonster()
        {
            _name = "Tiny Monster";
        }

        public override void Attack(ICharacter victim)
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

    public class Boss : ICharacter
    {
        public Boss()
        {
            _name = "First FInal Boss";
            _dmg = 50;
            _hp = 200;
        }

        public override void Attack(ICharacter victim)
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

}