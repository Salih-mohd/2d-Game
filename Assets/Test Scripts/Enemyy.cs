using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Internal.Commands;
using UnityEngine;
using UnityEngine.XR;

public class Enemyy : MonoBehaviour
{
    public EnemyStatsSo enemyStatsSO;

    private StateBase currentState;
    public Animator enemyAnimator;

    // reference to all possible states
    public IdleState idleState;
    //public ChaseState chaseState;
    public AttackState attackState;


    private Stack<ICommand> commandHistory = new Stack<ICommand>();

    private void Start()
    {


        idleState=new IdleState(this);
        attackState=new AttackState(this);

        ChangeState(idleState);
    }

    private void Update()
    {
        //currentState.Attack();

        if(Input.GetKeyDown(KeyCode.C))
        {
            ICommand moveLeft = new MoveLeftCommands(this.transform,3f);
            moveLeft.Excecute();
            commandHistory.Push(moveLeft);
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            ICommand moveRight=new MoveRightCommand(this.transform,3f); 
            moveRight.Excecute();
            commandHistory.Push(moveRight);
        }

        if(Input.GetKeyDown(KeyCode.Z))
        {
            if (commandHistory.Count!=0)
            {

                ICommand lastCommand = commandHistory.Pop();
                lastCommand.Undo();
            }

        }
    }

    public void ChangeState(StateBase newStae)
    {
        currentState?.Exit();
        currentState = newStae;
        currentState.Enter();
    }




}
