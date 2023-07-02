using UnityEngine;

public class EnemyChaseState : State
{
    bool canAttack;
    EnemyAttackState attackstate;

    public override State RunCurrentState()
    {
        if (canAttack) { return attackstate; }
        else return this;
    }
}
