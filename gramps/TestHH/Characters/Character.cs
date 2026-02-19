
using TestHH.Items;

namespace TestHH.Characters
{

    #region CHARACTERS

    public class Player : CharacterBase
    {
        EquippableItemBase? EquippedExtraItem { get; set; }

        public int killCount = 0;
        public override int baseDmg { get => 15; }

        private int dmg;
        public override int _dmg
        {
            get => dmg;
            set
            {
                dmg = (EquippedWeapon?.dmg ?? 0) + (EquippedExtraItem?.dmg ?? 0) + baseDmg;

            }
        }

        public Player()
        {

            _name = "Player 1";
            _inventory.Add(new Potion());
            var armor = new Armor();
            _inventory.Add(armor);
            EquipItem(_inventory.IndexOf(armor));
        }

        public override void Attack(CharacterBase victim)
        {
            var (victimIsDead, _) = victim.AttackedBy(this);
            // var results = victim.AttackedBy(this);

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
            auditLogger.Log($"[{_name}]: I will never stop! ...");
        }

        public override void EquipItem(int inventoryIndex)
        {
            var message = "You dont have any open slots";

            if (inventoryIndex >= _inventory.Count)
                return;

            var item = _inventory[inventoryIndex];

            if (item.isConsumable)
                return;

            if (EquippedWeapon == null)
            {
                EquippedWeapon = (EquippableItemBase)item;
                _inventory.Remove(item);
                message = $"{item.name} was equipped to the first slot";
            }
            else if (EquippedExtraItem == null)
            {
                EquippedExtraItem = (EquippableItemBase)item;
                _inventory.Remove(item);
                message = $"{item.name} was equipped to the second slot";
            }
            _dmg = _dmg;

            auditLogger.Log(message);
        }
    }

    public class TinyMonster : CharacterBase
    {
        public override int baseDmg { get => 5; }

        public TinyMonster()
        {
            _name = "Tiny Monster";

            // create and equip sword to tiny monster
        }

        public override void Attack(CharacterBase victim)
        {
            auditLogger.Log($"[{_name}]: ** in high pitch ** THIS IS GOnNA HURT!!");
            var (victimIsDead, _) = victim.AttackedBy(this);
            if (victimIsDead)
            {
                // everytime a TinyMonster kills a character, they scream
                auditLogger.Log($"[{_name}]: ** in high pitch ** DIE DIE DIE!!");
            }
        }


    }

    public class Boss : CharacterBase
    {
        public override int baseDmg { get => 35; }
        public Boss()
        {
            _name = "First FInal Boss";
            _hp = 200;
        }

        public override void Attack(CharacterBase victim)
        {
            var (victimIsDead, _) = victim.AttackedBy(this);
            if (victimIsDead)
            {
                // everytime a Boss kills a character, they scream
                auditLogger.Log($"[{_name}]: GOODBYE ONCE AND FOR ALL {victim._name}! ");
            }
        }

        public override void Dead()
        {
            auditLogger.Log($"[{_name}]: **NOooo NO N)O@!, i'll never y-yi-YIEield! Iim THE lORD of EvilL! !!!");
        }
    }

    #endregion

}