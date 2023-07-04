using UnityEngine;

public class EnemyController : MonoBehaviour, IDamageable
{
    #region State Machine Variables
    EnemyBaseState currentState;

    public EnemyIdleState IdleState = new EnemyIdleState();
    public EnemyHurtState HurtState = new EnemyHurtState();
    public EnemyChaseState ChaseState = new EnemyChaseState();
    public EnemyAttackState AttackState = new EnemyAttackState();
    #endregion

    GameObject player;
    PlayerController playercontroller;

    private void Awake() { player = GameObject.FindGameObjectWithTag("Player"); playercontroller = player.GetComponent<PlayerController>(); }

    private void Start()
    {
        currentState = ChaseState; currentState.EnterState(this);
    }
    private void Update() { currentState.UpdateState(this); }

    private void OnCollisionEnter(Collision collision) { currentState.OnCollisionEnter(this); }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerWeapon")) TakeDamage(1);
        if (collision.CompareTag("Player")) playercontroller.TakeDamage(1);
    }

    public void ChangeState(EnemyBaseState newState)
    {
        currentState = newState; currentState.EnterState(this);
    }

    #region Health & TakeDamage()
    [field: SerializeField] public int maxHealth { get; set; }
    [field: SerializeField] public int curHealth { get; set; }

    public void TakeDamage(int damageAmount)
    {
        ChangeState(HurtState);
        curHealth -= damageAmount;
        if (curHealth <= 0) { Destroy(gameObject); }
    }
    #endregion
}
