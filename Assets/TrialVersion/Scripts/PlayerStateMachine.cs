using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    public PlayerBaseState CurState { get; private set; }
    public Player PlayerController;
    public float speed;

    #region State Variables
    public PlayerIdleState IdleState { get; private set; }
    public PlayerWalkingState WalkState { get; private set; }
    public PlayerJumpingState JumpingState { get; private set; }
    
    public PlayerSwingingState SwingState { get; private set; }
    #endregion
    private void Awake()
    {
        IdleState = new PlayerIdleState(this, "idle");
        WalkState = new PlayerWalkingState(this, "walk");
        JumpingState = new PlayerJumpingState(this, "jump");
        SwingState = new PlayerSwingingState(this, "swing");
        speed = 3.5f;
        PlayerController = GetComponent<Player>();
        Initialize(JumpingState);
    }
    void Update()
    {
        if (CurState != null)
        {
            CurState.HandleInput();
            CurState.LogicUpdate();
        }
            
    }

    void LateUpdate()
    {
        if (CurState != null)
            CurState.PhysxUpdate();
    }
    public void Initialize(PlayerBaseState startingState)
    {
        CurState = startingState;
        CurState.Enter();
    }

    public void ChangeState(PlayerBaseState newState)
    {
        CurState.Exit();
        CurState = newState;
        CurState.Enter();
    }
}
