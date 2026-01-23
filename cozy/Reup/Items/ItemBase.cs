using Reup.Interfaces;


namespace Reup.Items
{
    public abstract class ItemBase : IDamagable
    {
        public int dmgBuff;
        public int healing;
        public int shield;
        public string itemName;
        public int playerHP;
        public abstract int Equip(int stat);
        public void ApplyDamage(int amount)
        {
            shield -= amount;
        }

    }
}
