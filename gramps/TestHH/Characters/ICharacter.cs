using TestHH.Items;

namespace TestHH.Characters
{
    public abstract class ICharacter
    {
        public int _dmg = 4;


        public int _hp = 20;

        public string _name;

        public List<IUsableItem> _inventory;

        public bool _dead = false;

        public ICharacter()
        {
            // create players new inventory
            _inventory = new List<IUsableItem>();

            // player spawn with base item
            _inventory.Add(new Sword());
        }

        public abstract void Attack(ICharacter victim);

        public void ViewStats()
        {
            Console.WriteLine("");
            Console.WriteLine($"{_name} Stats:  DMG: {_dmg}, HP: {_hp}");
            Console.WriteLine("");
        }

        public bool AttackedBy(ICharacter attacker)
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
}

