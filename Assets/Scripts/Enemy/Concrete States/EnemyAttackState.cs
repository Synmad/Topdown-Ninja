using UnityEngine;

public class EnemyAttackState : EnemyBaseState
{
    Transform playerTransform;
    Vector3 playerPosition;
    Animator animator;


    float attackCurTime;
    float attackMaxTime = 2;
    float attackCooldown = 1;
    float attackRange = 5;
    bool attackReady = true;

    EnemyController enemycontroller;
    public override void EnterState(EnemyController enemy)
    {
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
        enemycontroller = enemy.GetComponent<EnemyController>();
        animator = enemy.GetComponent<Animator>();

        attackCurTime = attackMaxTime;
    }

    public override void ExitState(EnemyController enemy)
    {
        animator.SetBool("Attacking", false);
    }

    public override void LateUpdateState(EnemyController enemy)
    {
    }

    public override void OnCollisionEnter(EnemyController enemy)
    {
    }

    public override void UpdateState(EnemyController enemy)
    {
        attackCurTime -= Time.deltaTime;

        if (attackCurTime == attackMaxTime)
        {
            animator.SetBool("Attacking", true);
            Debug.Log("atacando");
        }

        if (attackCurTime <= 0)
        {
            animator.SetBool("Attacking", false);
            attackCooldown -= Time.deltaTime;
            if (attackCooldown <= 0) { Debug.Log("listo para atacar"); attackCurTime = attackMaxTime; }
            
            //el tema es que el tipo se va a quedar atacando en la misma dirección aunque el jugador se aparte del ataque mientras no se aleje del alcance... 
        }

        playerPosition = playerTransform.position;
        if(Vector3.Distance(enemy.transform.position, playerPosition) > attackRange)
        {
            enemycontroller.ChangeState(enemy.ChaseState);
        }
    }
}
