using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;

    Rigidbody2D rb;
    Animator animator;
    Vector2 movement;
    public void MovementLogic()
    {
        movement.x = Input.GetAxisRaw("Horizontal"); movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();

        animator.SetFloat("Horizontal", movement.x); animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.magnitude);
    }

    public void MovementPhysics()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
