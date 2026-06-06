using UnityEngine;

public abstract class StateBase
{
    protected Enemyy enemy;

    public StateBase(Enemyy enemy)
    {
        this.enemy = enemy;
    }

    public abstract void Enter();
    public abstract void Attack();
    public abstract void Exit();
}
