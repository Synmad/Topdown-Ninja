using UnityEngine;

public class EnemyChaseState : EnemyBaseState
{
    Rigidbody2D rb;
    GameObject player;
    Vector3 playerPosition;
    
    float speed = 1;

    public override void EnterState(EnemyController enemy)
    {
        rb = enemy.gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
    }

    public override void OnCollisionEnter(EnemyController enemy)
    {
    }

    public override void UpdateState(EnemyController enemy)
    {
        playerPosition = player.transform.position;
        Vector2 moveDirection = (playerPosition - enemy.transform.position).normalized;
        Vector2 velocity = moveDirection * speed;
        rb.velocity = velocity;
    }
}
