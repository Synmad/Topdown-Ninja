using UnityEngine;

public class EnemyState
{
    protected Enemy enemy;
    protected EnemyStateMachine enemystatemachine;

    public EnemyState(Enemy enemy, EnemyStateMachine enemystatemachine)
    {
        this.enemy = enemy;
        this.enemystatemachine = enemystatemachine;
    }

    public virtual void EnterState() { }
    public virtual void ExitState() { }
    public virtual void FrameUpdate() { }
    public virtual void PhysicsUpdate() { }

}

