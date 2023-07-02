using UnityEngine;

public class EnemyIdleState : State
{
    bool noticedPlayer;
    EnemyChaseState chasestate;

    public override State RunCurrentState()
    {
        if (noticedPlayer) { return chasestate; }
        else return this;
    }
}
