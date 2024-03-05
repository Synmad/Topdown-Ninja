using Unity.VisualScripting;
using UnityEngine;

public class NewEnemyStateManager : MonoBehaviour
{
    public enum State
    {
        Idle,
        Following,
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
        if(StageManager.currentStage == myStageID
            && !reset.loading)
        {
            currentState = State.Following;
        }
        else currentState = State.Idle;
    }
}
    
