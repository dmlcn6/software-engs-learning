using TestHH.Interfaces;
using TestHH.Items;

namespace TestHH.Characters
{
    public abstract class CharacterBase : IDamagable
    {
        public int _dmg = 4;
        private int hp;
        public int _hp
        {
            get => hp;
            set
            {
                if (value > 200)
                    hp = 100;
                else if (value < 1)
                    hp = 0;
                else
                    hp = value;
            }
        }

        public string _name;

        public List<UsableItemBase> _inventory;

        public bool _dead = false;

        UsableItemBase EquippedWeapon { get; set; }

        public CharacterBase()
        {
            // set base hp
            _hp = 100;

            // create players new inventory
            _inventory = new List<UsableItemBase>();

            // player spawn with base item
            _inventory.Add(new Sword());
            EquipItem(0);
        }

        public abstract void Attack(CharacterBase victim);

        public void ViewStats()
        {
            Console.WriteLine("");
            Console.WriteLine($"{_name} Stats:  DMG: {GetDmg()}, HP: {_hp}");
            Console.WriteLine("");
        }

        private void EquipItem(int inventoryIndex)
        {
            var firstItem = _inventory[inventoryIndex];
            EquippedWeapon = firstItem;
            _inventory.Remove(firstItem);
        }

        public void ApplyDamage(int amount)
        {
            _hp -= amount;

            // _hp = _hp - amount;
        }

        public bool AttackedBy(CharacterBase attacker)
        {
            //int _hp = 0;
            ApplyDamage(attacker.GetDmg());  // same as _hp = _hp - attacker.dmg

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
            return EquippedWeapon.amountOfEffectToHp + _dmg;
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

