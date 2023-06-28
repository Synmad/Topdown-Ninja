using UnityEngine;

public class EnemyController : MonoBehaviour
{
    PlayerHealth playerhealth;
    [SerializeField] int damage = 1;
    private void Awake(){ playerhealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>(); }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerWeapon")) { Destroy(gameObject); }
        if (collision.CompareTag("Player")) { playerhealth.TakeDamage(damage); }
    }

    // checkear distancia, if distancia < x ataque()
}
