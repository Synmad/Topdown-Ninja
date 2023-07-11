using System;
using UnityEngine;

public class PlayerController : MonoBehaviour, IDamageable
{
    PlayerMovement movement;
    PlayerAttack attack;

    public static Action onPlayerAttack;
    public static Action onPlayerHurt;

    [SerializeField] int maxHealth;
    [SerializeField] int curHealth;

    public int MaxHealth { get { return maxHealth; } }
    public int CurHealth { get { return curHealth; } set { if (curHealth > maxHealth) { curHealth = maxHealth; } } }

    void Awake() 
    { 
        movement = GetComponent<PlayerMovement>(); attack = GetComponent<PlayerAttack>();
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
        if (curHealth <= 0) { Destroy(gameObject); }
    }
}