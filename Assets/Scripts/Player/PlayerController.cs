using System;
using UnityEngine;

public class PlayerController : MonoBehaviour, IDamageable
{
    PlayerMovement movement;
    PlayerAttack attack;

    public static Action onPlayerAttack;
    void Awake() { movement = GetComponent<PlayerMovement>(); attack = GetComponent<PlayerAttack>(); }

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

    #region Health & TakeDamage()
    [field: SerializeField] public int maxHealth { get; set; }
    [field: SerializeField] public int curHealth { get; set; }
    public void TakeDamage(int damageAmount)
    {
        curHealth -= damageAmount;
        if (curHealth <= 0) { Destroy(gameObject); }
    }
    #endregion
}