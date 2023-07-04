using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Scriptable Objects/Enemy Data")]
public class EnemyDataSO : ScriptableObject
{
    public int maxHealth;
    public int damage;
    public float speed;
}
