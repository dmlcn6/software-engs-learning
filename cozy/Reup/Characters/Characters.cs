using Reup.Items;
namespace Reup.Characters
{
    public class Player : CharacterBase
    {
        public string playerName;
        EquippableItem defBuff;

        public Player()
        {
            damage = Equip(damage);

        }
        public virtual int Equip(int stat)
        {
            stat = stat + buff;

            return stat;

        }

    }
    public class Bandit : CharacterBase
    {
        public Bandit()
        {
            name = "Bandit";
            damage = weapon[0].Equip(damage);
        }

    }
    public class Stranger : CharacterBase
    {
        public Stranger()
        {
            name = "???";
            damage = tote[0].Equip(damage);
            health = tote[1].Equip(health);
        }
    }
}

