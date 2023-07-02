using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    void TakeDamage(int damageAmount);

    int maxHealth { get; set; }
    int curHealth { get; set; }
}
