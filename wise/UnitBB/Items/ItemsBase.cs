


using UnitBB.Interfaces;

namespace UnitBB.Items
{
    public abstract class ItemsBase : IBoardPiece
    {
        private string name = "--";

        //------------------

        public abstract string CallItemType();

        public string Initname(string createdName)
        {
            name = createdName;

            return name;
        }

        //------------------

        public string CallName()
        {
            return name;
        }

        public abstract (int, int) Interact();

    }

}

