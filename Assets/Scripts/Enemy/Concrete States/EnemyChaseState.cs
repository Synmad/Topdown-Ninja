using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemyChaseState : EnemyBaseState
{
    Rigidbody2D rb;
    GameObject player;
    Vector3 playerPosition;
    EnemyController enemycontroller;
    Vector2 moveDirection;  
    float attackRange;
    Vector2 velocity;


    public override void EnterState(EnemyController enemy)
    {
        rb = enemy.gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        velocity = new Vector2(2f, 2f);
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
        moveDirection = (playerPosition - enemy.transform.position);
        moveDirection.Normalize();
        
        if (distance < attackRange)
        {
            enemycontroller.ChangeState(enemy.AttackState);
        }    
    }
    public override void LateUpdateState(EnemyController enemy)
    {
        rb.MovePosition((Vector2)enemy.transform.position + (moveDirection * velocity * Time.deltaTime));
    }

    public override void ExitState(EnemyController enemy)
    {
        
    }
}
