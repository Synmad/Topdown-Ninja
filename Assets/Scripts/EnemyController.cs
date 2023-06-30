using UnityEngine;

public class EnemyController : CharacterClass
{
    GameObject player;
    PlayerController playercontroller;
    Transform playertransform;

    [SerializeField] int damage = 1;
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
        if (collision.CompareTag("PlayerWeapon")) CurHealth--; 
        if (collision.CompareTag("Player")) playercontroller.CurHealth--; 
    }

    //to-do checkear distancia, if distancia < x ataque()
}
