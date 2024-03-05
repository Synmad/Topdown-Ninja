using Unity.VisualScripting;
using UnityEngine;

public class NewEnemyStateManager : MonoBehaviour
{
    public enum State
    {
        Idle,
        Attacking,
        Hurt,
    }

    [SerializeField] int myStageID;
    public State currentState;
    EnemyReset reset;

    private void Awake()
    {
        reset = GetComponent<EnemyReset>();
    }

    private void Update()
    {
        if (StageManager.currentStage == myStageID
            && !reset.loading)
        {
            currentState = State.Attacking;
        }
        else
        {
            currentState = State.Idle;
        }
    }
}
    
