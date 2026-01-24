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

        EquippableItemBase EquippedWeapon { get; set; }

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
            var item = _inventory[inventoryIndex];

            if (item.isConsumable)
                return;

            EquippedWeapon = (EquippableItemBase)item;
            _inventory.Remove(item);
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

            // TODO: change this to getter/setter
            if (_hp <= 0)
            {
                Dead();
                return true;
            }


            return false;
        }

        // TODO: change this to getter/setter
        public int GetDmg()
        {
            return EquippedWeapon.amountOfEffectToHp + _dmg;
        }

        // TODO: change this to getter/setter
        public virtual void Dead()
        {
            Console.WriteLine($"[{_name}]: I i Wait please help me! im Dying ple- Please, i cant fe- .....");
            _dead = true;
        }

        // TODO: change this to getter/setter
        public bool IsAlive()
        {
            return !_dead;
        }
    }
}

