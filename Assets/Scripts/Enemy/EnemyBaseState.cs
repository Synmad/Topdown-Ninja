using UnityEngine;

public abstract class EnemyBaseState
{
    public abstract void EnterState(EnemyController enemy);

    public abstract void UpdateState(EnemyController enemy);

    public abstract void LateUpdateState(EnemyController enemy);

    public abstract void OnCollisionEnter(EnemyController enemy);

    public abstract void ExitState(EnemyController enemy);

}

