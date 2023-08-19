public interface EnemyInterface
{
    public int GetCost();

    public void TakeDamage(float damage);
    public void CheckDeath();
    public void ChasePlayer();
}