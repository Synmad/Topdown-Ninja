using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    GameObject player;
    PlayerController playercontroller;
    Transform playertransform;

    [SerializeField] int damage = 1;

    [field: SerializeField] public int maxHealth { get; set; }
    [field: SerializeField] public int curHealth { get; set; }

    #region State Machine Variables

    EnemyStateMachine stateMachine {get; set;}
    EnemyIdleState idleState { get; set; }
    EnemyChaseState chaseState { get; set; }
    EnemyAttackState attackState { get; set; }

    #endregion

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playertransform = player.transform;
        playercontroller = player.GetComponent<PlayerController>();

        #region State Machine Instances
        stateMachine = new EnemyStateMachine();

        idleState = new EnemyIdleState(this, stateMachine);
        chaseState = new EnemyChaseState(this, stateMachine);
        attackState = new EnemyAttackState(this, stateMachine);
        #endregion
    }

    private void Start()
    {
        curHealth = maxHealth;

        stateMachine.Initialize(idleState);
    }

    private void Update()
    {
        stateMachine.currentEnemyState.FrameUpdate();
    }

    private void LateUpdate()
    {
        stateMachine.currentEnemyState.PhysicsUpdate();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerWeapon")) TakeDamage(1); 
        if (collision.CompareTag("Player")) playercontroller.TakeDamage(1); 
    }

    public void TakeDamage(int damageAmount)
    {
        curHealth -= damageAmount;
        if (curHealth <= 0) { Destroy(gameObject); }
    }
}
