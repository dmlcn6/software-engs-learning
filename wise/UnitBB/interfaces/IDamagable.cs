namespace UnitBB.Interfaces;

public interface IDamagables
{
    public int IntiHealth(int amount);
    public (int, int) HDAdj(int healthAdj, int damageAdj, string oper);
    public bool IsAlive();
}
