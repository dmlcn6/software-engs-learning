using Reup.Interfaces;


namespace Reup.Items
{
    public abstract class ItemBase : IDamagable
    {
        public abstract int dmgBuff { get; set; }
        public abstract int healing { get; set; }
        public abstract int shield { get; set; }
        public abstract string itemName { get; set; }
        public abstract bool isConsumable { get; set; }
        public abstract bool isEquippable { get; set; }
        public abstract int Equip(int stat);
        public void ApplyDamage(int amount)
        {
            shield -= amount;
        }

    }
}
