using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb;

    Vector2 movement;

    [SerializeField] 
    float moveSpeed;
    [SerializeField] float knockbackMultiplier = 10;
    private void Awake(){ animator = GetComponent<Animator>(); rb = GetComponent<Rigidbody2D>(); }

    public void MovementControls()
    {
        movement.x = Input.GetAxisRaw("Horizontal"); movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();

        animator.SetFloat("Horizontal", movement.x); animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.magnitude);

        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            animator.SetFloat("IdleHorizontal", Input.GetAxisRaw("Horizontal")); animator.SetFloat("IdleVertical", Input.GetAxisRaw("Vertical"));
        }
    }
    public void MovementPhysics()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
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
}
