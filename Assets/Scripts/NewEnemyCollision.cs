using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEnemyCollision : MonoBehaviour
{
    NewEnemyDamage damageController;
    PlayerController playerController;

    private void OnEnable()
    {
        damageController = GetComponent<NewEnemyDamage>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerWeapon")) { damageController.TakeDamage(1, collision.gameObject); }
        if (collision.CompareTag("Player")) playerController.TakeDamage(1, this.gameObject);
    }
}
