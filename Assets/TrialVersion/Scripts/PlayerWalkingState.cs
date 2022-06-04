using UnityEngine;

public class PlayerWalkingState : PlayerBaseState
{
    private PlayerStateMachine _sm;
    private float _horizontalInput;

    public PlayerWalkingState(PlayerStateMachine stateMachine, string animBoolName) : base(stateMachine, animBoolName)
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
        if (Mathf.Abs(_horizontalInput) < Mathf.Epsilon)
            stateMachine.ChangeState(_sm.IdleState);
    }

    public override void PhysxUpdate()
    {
        base.PhysxUpdate();
        Vector2 vel = _sm.GetComponent<Rigidbody>().velocity;
        vel.x = _horizontalInput * _sm.speed;
        _sm.GetComponent<Rigidbody>().velocity = vel;
    }
}
