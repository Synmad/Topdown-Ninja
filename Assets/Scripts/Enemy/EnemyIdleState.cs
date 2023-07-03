using UnityEngine;

public class EnemyIdleState : EnemyState
{
    public EnemyIdleState(Enemy enemy, EnemyStateMachine enemystatemachine) : base(enemy, enemystatemachine)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
