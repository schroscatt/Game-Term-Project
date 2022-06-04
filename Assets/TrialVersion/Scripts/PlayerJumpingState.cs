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
        Debug.Log("State : Jump");

    }
    public override void Exit()
    {
        base.Exit();
    }
    public override void HandleInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");

    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (playerController.IsGrounded())
        {
            Debug.Log("change state");
            stateMachine.ChangeState(stateMachine.IdleState);
        }
        
        if (playerController.isSwing && stateMachine.CurState != stateMachine.SwingState)
        {
            Debug.Log("change state");
            stateMachine.ChangeState(stateMachine.SwingState);
        }

    }

    public override void PhysxUpdate()
    {
        base.PhysxUpdate();
        Debug.Log("physx");
        if (playerController.IsGrounded())
        {
            playerController.Jump();
            /*if (playerController.GetVerticalVelocity() < 0) //falling, so accelerate faster for better gamefeel
            {
                playerController.AddGravity(3f);
            }
            else
            {
                
            }*/
            playerController.AddGravity(0.5f);
        }
    }    

}
