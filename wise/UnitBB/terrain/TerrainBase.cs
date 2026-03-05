

using System.ComponentModel;
using System.Data.Common;

using UnitBB.Interfaces;

namespace UnitBB.Terrain
{
    public abstract class TerrainBase : IBoardPiece
    {
        string name = "--";

        public string Initname(string createdName)
        {
            name = createdName;

            return name;
        }
        public string CallName()
        {
            return name;
        }
    }
}

