using System;
using UnityEngine;

public class PlayerController : MonoBehaviour, IDamageable
{
    PlayerMovement movement;
    PlayerAttack attack;
    PlayerDamageFlash damageFlash;

    BoxCollider2D triggerCollider;

    public static Action onPlayerAttack;
    public static Action onPlayerHurt;

    [SerializeField] public int maxHealth;
    [SerializeField] public int curHealth;

    void Awake() 
    { 
        movement = GetComponent<PlayerMovement>(); attack = GetComponent<PlayerAttack>(); damageFlash = GetComponent<PlayerDamageFlash>(); triggerCollider = GetComponent<BoxCollider2D>();
        curHealth = maxHealth;
    }

    void Update()
    {
        movement.MovementControls(); attack.AttackUpdate(); attack.ShurikenUpdate();

        if (Input.GetKeyDown(KeyCode.Space)) attack.Katana();
        if (Input.GetMouseButtonDown(0)) attack.Shuriken(); 
    }
    void FixedUpdate()
    {
        if (attack.attacking == false) movement.MovementPhysics();
    }

    public void TakeDamage(int damageAmount)
    {
        curHealth -= damageAmount;
        onPlayerHurt?.Invoke();
        triggerCollider.enabled = false;
        damageFlash.Flash();
        triggerCollider.enabled = true;
        if (curHealth <= 0) { Destroy(gameObject); }
        
    }
}