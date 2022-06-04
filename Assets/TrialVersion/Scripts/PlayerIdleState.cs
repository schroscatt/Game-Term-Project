using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    private PlayerStateMachine _sm;
    private float _horizontalInput;
    public PlayerIdleState(PlayerStateMachine stateMachine, string animBoolName) : base(stateMachine, animBoolName)
    {
        _sm = stateMachine;
    }
    public override void Enter()
    {
        base.Enter();
        _horizontalInput = 0f;
    }
    public override void Exit()
    {
        base.Exit();
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        _horizontalInput = Input.GetAxis("Horizontal");
        if (Mathf.Abs(_horizontalInput) > Mathf.Epsilon)
            stateMachine.ChangeState(_sm.WalkState);
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
