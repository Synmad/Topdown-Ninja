using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    Rigidbody2D rb;
    GameObject player;
    Vector3 playerPosition;
    Vector2 moveDirection;
    [SerializeField] float attackRange;
    [SerializeField] float speed;
    float distance;

    Transform attackaim;
    float attackMaxTime = 2;
    float attackCountdown;
    bool attacking;

    private void Awake()
    {

        rb = gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        if (player == null) { return; }

        distance = Vector3.Distance(playerPosition, transform.position);

        if (distance < attackRange)
        {
            attacking = true;
        }

        if (distance > attackRange)
        {
            attacking = false;
        }

        if (attacking)
        {
            Attack();
        }

            UpdateMovement();
        
    }

    private void LateUpdate()
    {
        if (!attacking)
        {
            rb.MovePosition((Vector2)transform.position + (moveDirection * speed * Time.deltaTime));
        }
        
    }

    void Attack()
    {
        if (attackCountdown <= 0f)
        {
            Debug.Log("ataque");
            attackCountdown = attackMaxTime;
        }
        else
        {
            Debug.Log("no puedo atacar");
            attackCountdown -= Time.deltaTime;
        }
    }

    void UpdateMovement()
    {
        playerPosition = player.transform.position;
        moveDirection = (playerPosition - transform.position); moveDirection.Normalize();
    }
}
