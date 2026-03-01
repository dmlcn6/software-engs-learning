


namespace UnitBB.Items
{
    public abstract class IItems
    {
        private string name = "--";
        private int buff = 0;
        private int debuff = 0;

        //------------------

        public string Initname(string createdName)
        {
            name = createdName;

            return name;
        }
        public int InitBuff(int amount)
        {
            buff = amount;

            return buff;
        }
        public int InitDebuff(int amount)
        {
            debuff = amount;

            return debuff;
        }

        //------------------

        public string CallName()
        {
            return name;
        }

        //------------------

        public int BuffAdj(int amount, string oper)
        {
            switch (oper)
            {
                case "+":
                    buff += amount;
                    break;

                case "x":
                case "*":
                    buff *= amount;
                    break;

                case "-":
                    buff -= amount;
                    break;

                case "/":
                    buff /= amount;
                    break;

                default:
                    Console.WriteLine("Something Went Wrong in a Item BuffAdj");
                    break;
            }

            return buff;
        }
        public int DebuffAdj(int amount, string oper)
        {
            switch (oper)
            {
                case "+":
                    debuff += amount;
                    break;

                case "x":
                case "*":
                    debuff *= amount;
                    break;

                case "-":
                    debuff -= amount;
                    break;

                case "/":
                    debuff /= amount;
                    break;

                default:
                    Console.WriteLine("Something Went Wrong in A Item debuffAdj");
                    break;
            }

            return debuff;
        }
        public int Use()
        {
            int effects = buff + debuff;
            Console.WriteLine($"Your {this.name} has just been used");

            return effects;
        }

    }

}

