

namespace Reup.Items
{
    public abstract class ItemBase
    {
        public int dmgBuff;
        public int healing;
        public int shield;
        public string itemName;
        public int playerHP;
        public abstract int Equip(int stat);
    }
}
