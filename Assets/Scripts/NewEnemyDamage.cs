using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEnemyDamage : MonoBehaviour, IDamageable
{
    [SerializeField] int maxHealth;
    [SerializeField] int curHealth;

    [SerializeField] float immunityDuration;

    [SerializeField] GameObject shurikenDrop;
    bool immune;

    NewEnemyFlash flash;
    NewEnemyKnockback knockback;

    private void Awake()
    {
        flash = GetComponent<NewEnemyFlash>();
        knockback = GetComponent<NewEnemyKnockback>();
    }

    private void OnEnable()
    {
        curHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount, GameObject attacker)
    {
        if (immune) { return; }

        curHealth -= damageAmount;

        StartCoroutine(ImmunityCoroutine());

        flash.StartFlashing();

        knockback.StarKnockback(attacker.transform);

        if(curHealth <= 0)
        {
            Instantiate(shurikenDrop, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }
    }

    IEnumerator ImmunityCoroutine()
    {
        immune = true;
        yield return new WaitForSeconds(immunityDuration);
        immune = false;
    }
}
