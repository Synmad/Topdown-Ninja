using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerMovement movement;
    PlayerAttack attack;
    void Awake()
    {
        movement = GetComponent<PlayerMovement>();
        attack = GetComponent<PlayerAttack>();
    }
    void Update()
    {
        movement.MovementControls();
        attack.Aim();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            attack.Katana();
        }
        if(Input.GetMouseButtonDown(0))
        {
            attack.Shuriken();
        }
    }
    void FixedUpdate()
    {
        movement.MovementPhysics();
    }
}
