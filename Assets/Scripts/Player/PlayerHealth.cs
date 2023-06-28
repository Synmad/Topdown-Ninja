using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    PlayerMovement playermovement;

    [SerializeField] int curHealth;
    [SerializeField] int maxHealth;
    private void Awake() { curHealth = maxHealth; playermovement = GetComponent<PlayerMovement>(); }

    public void TakeDamage(int damageAmount)
    {
        curHealth -= damageAmount;
        if (curHealth <= 0) { Destroy(gameObject); }
        playermovement.Knockback();
        //to-do knockback, invencibilidad temporal
    }


}
