using UnityEngine;

public class EnemyChaseState : EnemyBaseState
{
    Rigidbody2D rb;
    GameObject player;
    Vector3 playerPosition;
    Vector2 moveVelocity;
    EnemyController enemycontroller;
    
    float speed;
    float attackRange;

    public override void EnterState(EnemyController enemy)
    {
        rb = enemy.gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        speed = enemy.MoveSpeed;
        attackRange = enemy.AttackRange;
        enemycontroller = enemy.GetComponent<EnemyController>();
    }

    public override void OnCollisionEnter(EnemyController enemy)
    {
    }

    public override void UpdateState(EnemyController enemy)
    {
        if(player == null) { return; }

        float distance = Vector3.Distance(playerPosition, enemy.transform.position);

        playerPosition = player.transform.position;
        Vector2 moveDirection = (playerPosition - enemy.transform.position).normalized;
        
        if (distance < attackRange)
        {
            enemycontroller.ChangeState(enemy.AttackState);
        }
        Debug.Log("chase");
    }
    public override void LateUpdateState(EnemyController enemy)
    {
        enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, playerPosition, speed * Time.deltaTime);
    }

    public override void ExitState(EnemyController enemy)
    {
        
    }
}
