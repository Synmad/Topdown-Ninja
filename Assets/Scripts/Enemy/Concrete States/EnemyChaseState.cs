using UnityEngine;

public class EnemyChaseState : EnemyBaseState
{
    Rigidbody2D rb;
    GameObject player;
    Vector3 playerPosition;
    Vector2 moveVelocity;
    EnemyController enemycontroller;
    
    float speed;

    public override void EnterState(EnemyController enemy)
    {
        rb = enemy.gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        speed = enemy.MoveSpeed;
        enemycontroller = enemy.GetComponent<EnemyController>();
    }

    //ontriggerenter { changestate(attackstate) }

    public override void OnCollisionEnter(EnemyController enemy)
    {
    }

    public override void UpdateState(EnemyController enemy)
    {
        playerPosition = player.transform.position;
        Vector2 moveDirection = (playerPosition - enemy.transform.position).normalized;
        moveVelocity = moveDirection * speed;

        float attackRange = 5f;
        if(Vector3.Distance(enemy.transform.position, playerPosition) < attackRange)
        {
            enemycontroller.ChangeState(enemy.AttackState);
        }
        
    }
    public override void LateUpdateState(EnemyController enemy)
    {
        rb.velocity = moveVelocity;
    }

    public override void ExitState(EnemyController enemy)
    {
        rb.velocity *= 0;
    }
}
