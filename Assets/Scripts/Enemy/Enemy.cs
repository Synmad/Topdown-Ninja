using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    GameObject player;
    PlayerController playercontroller;
    Transform playertransform;

    [SerializeField] int damage = 1;

   [field: SerializeField] public int maxHealth { get; set; }
   [field: SerializeField] public int curHealth { get; set; }

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playertransform = player.transform;
        playercontroller = player.GetComponent<PlayerController>();
        PlayerController.onPlayerAttack += ReactToPlayer;
    }

    void ReactToPlayer()
    {
        Debug.Log("¡El enemigo mira feo al jugador!");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerWeapon")) TakeDamage(1); 
        if (collision.CompareTag("Player")) playercontroller.TakeDamage(1); 
    }

    public void TakeDamage(int damageAmount)
    {
        curHealth -= damageAmount;
        if (curHealth <= 0) { Destroy(gameObject); }
    }
}
