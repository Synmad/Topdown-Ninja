using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float attackForce;

    Rigidbody2D rb;
    Animator animator;
    Vector2 movement;
    [SerializeField] GameObject shurikenprefab;
    [SerializeField] Transform attackpoint;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal"); movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();

        animator.SetFloat("Horizontal", movement.x); animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.magnitude);

        if(Input.GetMouseButtonDown(0))
        {
            ThrowShuriken();
        }
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
    void ThrowShuriken()
    {
        GameObject shuriken = Instantiate(shurikenprefab, attackpoint.position, Quaternion.identity);
        shuriken.GetComponent<Rigidbody2D>().AddForce(attackpoint.right * attackForce);

    }
}
