public interface IDamageable
{
    int maxHealth { get; set; }
    int curHealth { get; set; }
    void TakeDamage(int damageAmount);
}
