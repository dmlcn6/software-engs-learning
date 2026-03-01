

using System.ComponentModel;
using System.Data.Common;

namespace UnitBB.Items
{
    public abstract class UsableItemBase : ItemsBase
    {
        private int hBuff = 0;
        private int dBuff = 0;

        public override string CallItemType()
        {
            return "usable";
        }
        public int CallHBuff()
        {
            return hBuff;
        }
        public int CallDBuff()
        {
            return dBuff;
        }
        //--------------------------
        public int InitHBuff(int amount)
        {
            hBuff = amount;

            return hBuff;
        }
        public int InitDBuff(int amount)
        {
            dBuff = amount;

            return dBuff;
        }
        //---------------------------
        public override (int, int) Interact()
        {
            return (hBuff, dBuff);
        }
    }
}

