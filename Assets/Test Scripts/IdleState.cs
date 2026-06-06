using UnityEngine;

public class IdleState : StateBase
{


    public IdleState(Enemyy enemy) : base(enemy) { }
    




    public override void Enter()
    {
        Debug.Log("enemy is in idle");
        enemy.enemyAnimator.SetTrigger("Idle");
    }

    public override void Attack()
    {
        enemy.ChangeState(enemy.attackState);
        enemy.enemyAnimator.SetTrigger("Attack");
    }

    
    public override void Exit()
    {
        Debug.Log("Exit from idle");   
    }
}
