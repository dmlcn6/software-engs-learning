using Reup.Characters;

namespace Reup.Items
{
    public abstract class IUsableItems
    {
        public int dmgBuff;
        public int healing;
        public int shield;
        public string itemName;
        public int playerHP;
        public abstract void Equip(ICharacter character);
    }
}
