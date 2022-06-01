using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    PlayerBaseState curState;
    PlayerWalkingState walkingState = new PlayerWalkingState();
    PlayerIdleState idleState = new PlayerIdleState();
    PlayerJumpingState jumpingState = new PlayerJumpingState();

    private void Awake()
    {
        curState = idleState;
        curState.Enter(this);
    }

    private void Update()
    {
        curState.Update(this);
    }
}
