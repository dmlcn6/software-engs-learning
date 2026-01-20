namespace Reup.Characters
{
    public abstract class CharacterBase
    {
        public int health = 100;
        public int damage = 7;
        public string name;
        public bool alive = true;
        public CharacterBase()
        {

        }
        public string ViewStats()
        {
            return $"DMG: {damage}, HP: {health}";
        }
        public abstract void Attacked(CharacterBase attacker);
        public void Attack(CharacterBase victim)
        {
            victim.Attacked(this);
        }
    }
}