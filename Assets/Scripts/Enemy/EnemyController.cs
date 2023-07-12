using System.Collections;
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

    [SerializeField] EnemyDataSO data;

    [SerializeField] int damage;
    [SerializeField] float moveSpeed;
    public float MoveSpeed { get { return moveSpeed; } }
    [SerializeField] float attackRange;
    public float AttackRange { get { return attackRange; } }

    GameObject player;
    PlayerController playercontroller;

    [SerializeField] bool immune;
    [SerializeField] float immunityDuration;

    Rigidbody2D rb;
    SpriteRenderer sprite;

    Material defaultMaterial;
    [SerializeField] Material flashMaterial;
    [SerializeField] float flashDuration;
    Coroutine flashCoroutine;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player"); playercontroller = player.GetComponent<PlayerController>(); sprite = GetComponent<SpriteRenderer>(); defaultMaterial = sprite.material; rb = GetComponent<Rigidbody2D>();
        maxHealth = data.maxHealth; curHealth = maxHealth;
        damage = data.damage;
        moveSpeed = data.moveSpeed;
        attackRange = data.attackRange;
        ChangeState(ChaseState);
    }

    private void Update() { currentState.UpdateState(this); }

    private void LateUpdate() { currentState.LateUpdateState(this); }

    private void OnCollisionEnter(Collision collision) { currentState.OnCollisionEnter(this); }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerWeapon")) TakeDamage(1, collision.gameObject);
        if (collision.CompareTag("Player")) playercontroller.TakeDamage(damage, this.gameObject);
    }

    public void ChangeState(EnemyBaseState newState)
    {
        currentState?.ExitState(this); 
        currentState = newState; 
        currentState.EnterState(this);
    }

    #region Health & TakeDamage()
    [field: SerializeField] public int maxHealth { get; set; }
    [field: SerializeField] public int curHealth { get; set; }

    public void TakeDamage(int damageAmount, GameObject attacker)
    {
        //ChangeState(HurtState);
        if (immune) { return; }
        curHealth -= damageAmount;
        StartCoroutine(ImmunityCoroutine());
        StartCoroutine(Knockback(1f, 60, attacker.transform));
        DamageFlash();
        if (curHealth <= 0) { Destroy(gameObject); }
    }

    IEnumerator ImmunityCoroutine()
    {
        immune = true;
        yield return new WaitForSeconds(immunityDuration);
        immune = false;
    }

    void DamageFlash()
    {
        if (flashCoroutine != null)
        {
            StopCoroutine(flashCoroutine);
        }
        flashCoroutine = StartCoroutine(FlashCoroutine());
    }

    IEnumerator FlashCoroutine()
    {
        sprite.material = flashMaterial;
        yield return new WaitForSeconds(flashDuration);
        sprite.material = defaultMaterial;
        yield return new WaitForSeconds(flashDuration);
        sprite.material = flashMaterial;
        yield return new WaitForSeconds(flashDuration);
        sprite.material = defaultMaterial;
        flashCoroutine = null;
    }

    public IEnumerator Knockback(float duration, float force, Transform attacker)
    {
        float timer = 0;
        while (duration > timer)
        {
            timer += Time.deltaTime;
            Vector2 direction = (attacker.transform.position - this.transform.position).normalized;
            rb.AddForce(-direction * force);
        }

        yield return 0;
    }
    #endregion
}
