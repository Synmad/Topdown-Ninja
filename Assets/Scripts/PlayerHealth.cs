using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int curHealth;
    [SerializeField] int maxHealth;
    private void Awake() { curHealth = maxHealth; }

    public void TakeDamage(int damageAmount)
    {
        curHealth -= damageAmount;
        if (curHealth <= 0) { Destroy(gameObject); }
        //knockback, invencibilidad temporal
    }
}
