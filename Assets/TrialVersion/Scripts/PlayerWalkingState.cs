using UnityEngine;

public class PlayerWalkingState : PlayerBaseState
{
    private PlayerStateMachine _sm;

    public PlayerWalkingState(PlayerStateMachine stateMachine, string animBoolName) : base(stateMachine, animBoolName)
    {
        _sm = stateMachine;
    }
    public override void Enter()
    {
        base.Enter();
        Debug.Log("State : Walking");
    }
    public override void Exit()
    {
        base.Exit();
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (Mathf.Abs(horizontalInput) < Mathf.Epsilon)
            stateMachine.ChangeState(_sm.IdleState);
        else if (verticalInput)
            stateMachine.ChangeState(_sm.JumpingState);
    }

    public override void PhysxUpdate()
    {
        base.PhysxUpdate();
        /*Vector2 vel = _sm.GetComponent<Rigidbody>().velocity;
        vel.x = _horizontalInput * _sm.speed;
        _sm.GetComponent<Rigidbody>().velocity = vel;*/
    }
}
