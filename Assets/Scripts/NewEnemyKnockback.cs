using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEnemyKnockback : MonoBehaviour
{
    [SerializeField] float duration;
    [SerializeField] float force;

    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void StarKnockback(Transform attacker)
    {
        StartCoroutine(Knockback(attacker));
    }

    IEnumerator Knockback(Transform attacker)
    {
        float timer = 0;
        while (duration > timer)
        {
            timer += Time.fixedDeltaTime;
            Vector2 direction = (attacker.transform.position - this.transform.position).normalized;
            rb.AddForce(-direction * force);
        }

        yield return 0;
    }
}
