using Platformer.Mechanics;
using UnityEngine;

public class PlayerSwingingState : PlayerBaseState
{
    private PlayerStateMachine _sm;
    
    public PlayerSwingingState(PlayerStateMachine stateMachine, string animBoolName) : base(stateMachine, animBoolName)
    {
        _sm = stateMachine;
    }
    public override void Enter()
    {
        base.Enter();
        Debug.Log("State : Swing");

    }
    public override void Exit()
    {
        base.Exit();
    }
    public override void HandleInput()
    {

    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (playerController.col.enabled)
        {
            stateMachine.ChangeState(stateMachine.IdleState);
        }

    }

    public override void PhysxUpdate()
    {
        base.PhysxUpdate();
        playerController.Swing();
    }    

}