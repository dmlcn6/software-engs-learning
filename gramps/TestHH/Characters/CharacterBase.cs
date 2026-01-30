using TestHH.Interfaces;
using TestHH.Items;
using TestHH.Logger;


namespace TestHH.Characters
{
    public abstract class CharacterBase : IDamagable
    {
        public AuditLog auditLogger;
        public abstract int baseDmg { get; }

        private int dmg;
        // virtual allows a base implementaion in the base class
        // then in a child(derived) class, there is an option ability to overwrite and create new behavior
        public virtual int _dmg
        {
            get => dmg;
            set
            {
                dmg = (EquippedWeapon?.dmg ?? 0) + value;

            }
        }

        private int hp;
        public int _hp
        {
            get => hp;
            set
            {
                if (value > 200)
                    hp = 100;
                else if (value < 1)
                {
                    hp = 0;
                    dead = true;
                }
                else
                    hp = value;
            }
        }

        public string _name;

        public List<UsableItemBase> _inventory;

        private bool dead = false;
        public bool _dead
        {
            get => dead;
            set { }
        }

        public EquippableItemBase? EquippedWeapon { get; set; }

        public CharacterBase()
        {
            auditLogger = new AuditLog();
            // set base hp
            _hp = 100;

            _dmg = baseDmg;

            // create players new inventory
            _inventory = new List<UsableItemBase>();

            // player spawn with base item
            _inventory.Add(new Sword());
            EquipItem(0);
        }

        public abstract void Attack(CharacterBase victim);

        public void ViewStats()
        {
            auditLogger.Log("");
            auditLogger.Log($"{_name} Stats:  DMG: {_dmg}, HP: {_hp}");
            auditLogger.Log("");
        }

        public virtual void EquipItem(int inventoryIndex)
        {
            if (inventoryIndex >= _inventory.Count)
                return;

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

        // example of a function returning a tuple
        public (bool, int) AttackedBy(CharacterBase attacker)
        {
            //int _hp = 0;
            ApplyDamage(attacker._dmg);  // same as _hp = _hp - attacker.dmg

            ViewStats();
            attacker.ViewStats();

            // TODO: change this to getter/setter
            if (_hp <= 0)
            {
                Dead();
                return (true, _hp);
            }


            return (false, _hp);
        }



        // TODO: change this to getter/setter
        public virtual void Dead()
        {
            auditLogger.Log($"[{_name}]: I i Wait please help me! im Dying ple- Please, i cant fe- .....");
        }

        // TODO: change this to getter/setter
        public bool IsAlive()
        {
            return !_dead;
        }
    }
}

