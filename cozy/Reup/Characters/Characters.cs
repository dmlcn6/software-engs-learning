using Reup.Items;
using Reup.Logger;
namespace Reup.Characters
{
    public class Player : CharacterBase
    {
        private ILogger _logger;
        public string playerName;
        EquippableItem defBuff;
        ItemBase? equippedExtraItem { get; set; }

        public Player()
        {
            var sword = new Sword();
            _logger = new AuditLog();
            inventory.Add(sword);
            EquipItem(inventory.IndexOf(sword));

        }
        public override void EquipItem(int inventoryIndex)
        {
            if (inventoryIndex >= inventory.Count)
                return;

            var item = inventory[inventoryIndex];

            if (item.isConsumable)
                return;

            if (equippedWeapon == null)
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
            EquipItem(inventory.IndexOf(dagger));
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
            EquipItem(inventory.IndexOf(glocky));
            EquipItem(inventory.IndexOf(poshun));
        }
    }
}

