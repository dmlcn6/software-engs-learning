

namespace UnitBB.Items
{
    public abstract class EquippableItemBase : ItemsBase
    {
        int extraHealth = 0;
        int extraDamage = 0;
        //-------------------------
        public override string CallItemType()
        {
            return "equippable";
        }
        public int CallHealthIncrease()
        {
            return extraHealth;
        }
        public int CallDamageIncrease()
        {
            return extraDamage;
        }
        //--------------------------
        public int InitHealthIncrease(int amount)
        {
            extraHealth = amount;

            return extraHealth;
        }
        public int InitDamageIncrease(int amount)
        {
            extraDamage = amount;

            return extraDamage;
        }
        //---------------------------
        public override (int, int) Interact()
        {
            return (extraHealth, extraDamage);
        }
    }
}