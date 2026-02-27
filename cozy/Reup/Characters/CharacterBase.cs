using Reup.Interfaces;
using Reup.Items;
namespace Reup.Characters
{
    public abstract class CharacterBase : IDamagable
    {
        public int xCoords;
        public int yCoords;
        private int health;
        public int _health
        {
            get => health;
            set
            {
                if (value > 200)
                    health = 100;
                else if (value < 1)
                {
                    health = 0;
                    alive = false;
                }
                else
                    health = value;
            }
        }
        public int baseDmg { get => 7; }
        private int damage;
        public virtual int _damage
        {
            get => damage;
            set
            {
                damage = (equippedWeapon?.dmgBuff ?? 0) + baseDmg;
            }
        }
        public int shield = 0;
        public string name;
        public bool alive = true;
        public List<ItemBase> inventory;
        public EquippableItem? equippedWeapon { get; set; }

        public CharacterBase()
        {
            inventory = new List<ItemBase>();
            _health = 100;
            _damage = baseDmg;
        }
        public string ViewStats()
        {
            return $"DMG: {_damage}, HP: {_health}";
        }
        public void Attacked(CharacterBase attacker)
        {
            ApplyDamage(attacker._damage);
        }
        public void Attack(CharacterBase victim)
        {
            victim.Attacked(this);
        }
        public void ApplyDamage(int amount)
        {
            if (shield > 0)
            {
                shield = shield - amount;
            }
            else
            {
                _health = _health - amount;
            }
        }
        public virtual void UseItem(int inventoryIndex)
        {
            if (inventoryIndex >= inventory.Count)
                return;

            var item = inventory[inventoryIndex];

            if (item.isConsumable)
            {
                var consumable = (ConsumableItem)item;
                inventory.Remove(item);
            }
            else
            {
                equippedWeapon = (EquippableItem)item;
                inventory.Remove(item);
            }
            _damage = _damage;
        }
    }
}