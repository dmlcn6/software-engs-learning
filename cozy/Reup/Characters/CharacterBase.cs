using Reup.Interfaces;
using Reup.Items;
namespace Reup.Characters
{
    public abstract class CharacterBase : IDamagable
    {
        public int health = 100;
        public int damage = 7;
        public int shield = 0;
        public string name;
        public bool alive = true;
        public List<ItemBase> inventory;
        public EquippableItem? equippedWeapon { get; set; }

        public CharacterBase()
        {
            inventory = new List<ItemBase>();
        }
        public string ViewStats()
        {
            return $"DMG: {damage}, HP: {health}";
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