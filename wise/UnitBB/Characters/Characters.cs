using System.Security.Cryptography;
using UnitBB.Items;
using UnitBB.Logger;

namespace UnitBB.Characters
{

    public class Raider : CharactersBase
    {

        Logs to = new();
        public Raider()
        {
            Initname("Raider");
            InitHealth(100);
            InitDamage(100);
            InitPosition(1, 1);
            inventory[2] = new Rattler();
            inventory[3] = new Rattler();
            inventory[4] = new Rattler();
        }

        public override void AttackBase(CharactersBase target)
        {
            to.Log($"{CallName()} takes a deep breath... Bang!");
            to.Log($"{CallName()} has hit the {target.CallName()} for {CallDamageAmount()} damage");
            target.DamageRec(this);

        }
        public override int DamageRec(CharactersBase attacker)
        {
            HDAdj(attacker.CallDamageAmount(), 0, "-");
            //to.Log($"{CallName()}'s health is currently {CallHealthAmount()}");
            to.Log("----*----");

            if (CallHealthAmount() <= 0)
            {
                attacker.KillCountAdj();
            }

            return CallHealthAmount();
        }




    }
    public class Arc : CharactersBase
    {
        Logs to = new();
        public Arc()
        {
            Initname("Arc");
            InitHealth(100);
            InitDamage(1);
            InitPosition(1, 0);
        }

        public override void AttackBase(CharactersBase target)
        {
            to.Log("zzzrrrzrzrzrz... Zap!");
            to.Log($"{CallName()} has hit {target.CallName()} for {CallDamageAmount()} damage");
            target.DamageRec(this);
        }
        public override int DamageRec(CharactersBase attacker)
        {
            HDAdj(attacker.CallDamageAmount(), 0, "-");
            //to.Log($"The {CallName()} health is currently {CallHealthAmount()}");
            to.Log("----*----");

            if (CallHealthAmount() <= 0)
            {
                attacker.KillCountAdj();
            }

            return CallHealthAmount();
        }


    }

}