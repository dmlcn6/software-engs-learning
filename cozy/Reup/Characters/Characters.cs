using Reup.Items;
using Reup.Logger;
namespace Reup.Characters
{
    public class Player : CharacterBase
    {
        private ILogger _logger;
        public string playerName;
        EquippableItem? equippedExtraItem { get; set; }
        private int damage;
        public override int _damage
        {
            get => damage;
            set
            {
                damage = (equippedWeapon?.dmgBuff ?? 0) + (equippedExtraItem?.dmgBuff ?? 0) + baseDmg;
            }
        }

        public Player()
        {
            var sword = new Sword();
            _logger = new AuditLog();
            inventory.Add(sword);
            UseItem(inventory.IndexOf(sword));

        }
        public override void UseItem(int inventoryIndex)
        {
            if (inventoryIndex >= inventory.Count)
                return;

            var item = inventory[inventoryIndex];

            if (item.isConsumable)
            {
                var consumable = (ConsumableItem)item;
                _health = consumable.healing + _health;
                inventory.Remove(item);
            }

            else if (equippedWeapon == null)
            {
                equippedWeapon = (EquippableItem)item;
                inventory.Remove(item);
            }
            else if (equippedExtraItem == null)
            {
                equippedExtraItem = (EquippableItem)item;
                inventory.Remove(item);
            }
            else
            {
                _logger.Log("You dont have any open slots");
            }
            _damage = _damage;
        }

    }
    public class Bandit : CharacterBase
    {
        public Bandit()
        {
            name = "Bandit";
            var dagger = new Knife();
            inventory.Add(dagger);
            UseItem(inventory.IndexOf(dagger));
        }

    }
    public class Stranger : CharacterBase
    {
        public Stranger()
        {
            name = "???";
            var glocky = new Blick();
            var poshun = new Potion();
            inventory.Add(glocky);
            inventory.Add(poshun);
            UseItem(inventory.IndexOf(glocky));
            UseItem(inventory.IndexOf(poshun));
        }
    }
}
