using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    private PlayerStateMachine _sm;

    public PlayerIdleState(PlayerStateMachine stateMachine, string animBoolName) : base(stateMachine, animBoolName)
    {
        _sm = stateMachine;
    }
    public override void Enter()
    {
        base.Enter();
        Debug.Log("State : Idle");
    }
    public override void Exit()
    {
        base.Exit();
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (playerController.isSwing)
        {
            Debug.Log("change state");
            stateMachine.ChangeState(stateMachine.SwingState);
        }
        else if (Mathf.Abs(horizontalInput) > Mathf.Epsilon)
        {
            stateMachine.ChangeState(_sm.WalkState);
        }

        else if (verticalInput)
        {
            stateMachine.ChangeState(_sm.JumpingState);
        }
    }

    public override void PhysxUpdate()
    {
        base.PhysxUpdate();
       
    }
}
