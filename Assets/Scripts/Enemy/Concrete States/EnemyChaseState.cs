using UnityEngine;

public class EnemyChaseState : EnemyBaseState
{
    Rigidbody2D rb;
    GameObject player;
    float speed;

    Vector3 playerPosition;

    public override void EnterState(EnemyController enemy)
    {
        rb = enemy.gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        speed = enemy.Data.speed;
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
