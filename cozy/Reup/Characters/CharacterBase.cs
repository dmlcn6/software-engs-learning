using Reup.Interfaces;
using Reup.Items;
namespace Reup.Characters
{
    public abstract class CharacterBase : IDamagable
    {
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
        private int damage;
        public int _damage
        {
            get => damage;
            set
            {
                damage = (equippedWeapon?.dmgBuff ?? 0) + value;
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
            _damage = 7;
        }
        public string ViewStats()
        {
            return $"DMG: {_damage}, HP: {_health}";
        }
        public void Attacked(CharacterBase attacker)
        {
            ApplyDamage(attacker.damage);
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
                health = health - amount;
            }
        }
        public virtual void EquipItem(int inventoryIndex)
        {
            if (inventoryIndex >= inventory.Count)
                return;

            var item = inventory[inventoryIndex];

            if (item.isConsumable)
                return;

            equippedWeapon = (EquippableItem)item;
            inventory.Remove(item);
        }
    }
}