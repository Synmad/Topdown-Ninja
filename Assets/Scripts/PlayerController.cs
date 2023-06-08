using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerMovement movement;
    PlayerAttack attack;
    
    void Awake()
    {
        movement = GetComponent<PlayerMovement>();
    }
    void Update()
    {
        movement.MovementLogic();

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
