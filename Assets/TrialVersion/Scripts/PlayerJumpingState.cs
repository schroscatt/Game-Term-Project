using UnityEngine;

public class PlayerJumpingState : PlayerBaseState
{
    private PlayerStateMachine _sm;

    public PlayerJumpingState(PlayerStateMachine stateMachine, string animBoolName) : base(stateMachine, animBoolName)
    {
        _sm = stateMachine;
    }
    public override void Enter()
    {
        base.Enter();

    }
    public override void Exit()
    {
        base.Exit();
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (playerController.IsGrounded() && playerController.GetVerticalVelocity() < 0)
        {
            Debug.Log("change state");
            stateMachine.ChangeState(stateMachine.IdleState);
        }

    }

    public override void PhysxUpdate()
    {
        base.PhysxUpdate();
        playerController.Jump();
        if (playerController.GetVerticalVelocity() < 0) //falling, so accelerate faster for better gamefeel
        {
            playerController.AddGravity(3f);
        }
        else
        {
            playerController.AddGravity(0.5f);
        }
    }    

}
