using Reup.Interfaces;
namespace Reup.Characters
{
    public abstract class CharacterBase : IDamagable
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
        public void Attacked(CharacterBase attacker)
        {
            ApplyDamage(attacker.damage);
        }
        public void Attack(CharacterBase victim)
        {
            victim.Attacked(this);
        }
        public void ApplyDamage(int amount)
        {
            health -= amount;
        }
    }
}