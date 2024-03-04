using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEnemyCollision : MonoBehaviour
{
    NewEnemyDamage damageController;

    private void Awake()
    {
        damageController = GetComponent<NewEnemyDamage>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerWeapon")) { damageController.TakeDamage(1, collision.gameObject); }
    }
}
