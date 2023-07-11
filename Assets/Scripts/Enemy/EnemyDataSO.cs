using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemYData", menuName = "Scriptable Objects/Enemy Data")]
public class EnemyDataSO : ScriptableObject
{
    public int maxHealth;
    public int damage;
    public float moveSpeed;
    public float attackRange;
}
