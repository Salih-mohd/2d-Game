using UnityEngine;

public class AttackState : StateBase
{

    public AttackState(Enemyy enemy) : base(enemy) { }
    

    public override void Enter()
    {
        Debug.Log("Entered to attacck state");
        enemy.enemyAnimator.SetTrigger("Attack");
    }


    public override void Attack()
    {
        Debug.Log("Attacking");
    }


    public override void Exit()
    {
        Debug.Log("Exited from attack state");
    }
}
