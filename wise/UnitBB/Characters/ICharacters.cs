


namespace UnitBB.Characters
{
    public abstract class ICharacters
    {

        private string name = "--";
        private int health = 0;
        private int damage = 0;
        public Items[] inventory = new Items[5] { new ArcCell(), new Available(), new Available(), new Available(), new Available() };


        public string Initname(string createdName)
        {
            name = createdName;

            return name;
        }
        public int IntiHealth(int amount)
        {
            health = amount;

            return health;
        }
        public int IntiDamage(int amount)
        {
            damage = amount;

            return damage;
        }

        //------------------

        public string CallName()
        {
            return name;
        }
        public int CallHealthAmount()
        {
            return health;
        }
        public int CallDamageAmount()
        {
            return damage;
        }

        //------------------


        public string NameAdj(string changeName)
        {
            if (changeName != "")
            {
                name = changeName;
            }
            return name;
        }

        public int HealthAdj(int amount, string oper)
        {
            switch (oper)
            {
                case "+":
                    health += amount;
                    break;

                case "x":
                case "*":
                    health *= amount;
                    break;

                case "-":
                    health -= amount;
                    break;

                case "/":
                    health /= amount;
                    break;

                default:
                    Console.WriteLine("Something Went Wrong in in A Characters HealthAdj");
                    break;
            }

            return health;
        }

        public int DamageAdj(int amount, string oper)
        {
            switch (oper)
            {
                case "+":
                    damage += amount;
                    break;

                case "x":
                case "*":
                    damage *= amount;
                    break;

                case "-":
                    damage -= amount;
                    break;

                case "/":
                    damage /= amount;
                    break;

                default:
                    Console.WriteLine("Something Went Wrong in A Characters DamageAdj");
                    break;
            }

            return damage;
        }


    }

}

