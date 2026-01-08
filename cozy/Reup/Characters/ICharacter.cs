namespace Reup.Characters
{
    public abstract class ICharacter
    {
        public int health = 100;
        public int damage = 7;
        public string name;
        public bool alive = true;
        public ICharacter()
        {

        }
        public string ViewStats()
        {
            return $"DMG: {damage}, HP: {health}";
        }
        public abstract void Attacked(ICharacter attacker);
        public void Attack(ICharacter victim)
        {
            victim.Attacked(this);
        }
    }
}