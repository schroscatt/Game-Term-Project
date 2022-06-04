using UnityEngine;

public abstract class PlayerBaseState
{
    
    protected PlayerStateMachine stateMachine;

    protected bool isAnimationFinished;
    protected bool isExitingState;

    protected float startTime;

    private string animBoolName;

    protected Player playerController;

    public float horizontalInput;
    public bool verticalInput;

    public PlayerBaseState(PlayerStateMachine stateMachine, string animBoolName)
    {
        this.stateMachine = stateMachine;
        this.animBoolName = animBoolName;
        playerController = stateMachine.PlayerController;
        horizontalInput = 0.0f;
        verticalInput = false;
    }

    public virtual void Enter()
    {
        DoChecks();
        startTime = Time.time;
        isAnimationFinished = false;
        isExitingState = false;
    }

    public virtual void Exit()
    {
        isExitingState = true;
    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void HandleInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetButton("Jump");
    }
    public virtual void PhysxUpdate()
    {
        DoChecks();
    }

    public virtual void DoChecks() { }

    public virtual void AnimationTrigger() { }

    public virtual void AnimationFinishTrigger() => isAnimationFinished = true;

}
