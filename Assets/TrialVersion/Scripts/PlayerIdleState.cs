using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public override void Enter(PlayerStateMachine _manager)
    {
        Debug.Log("idle");
    }
    public override void Update(PlayerStateMachine _manager)
    {
        Debug.Log("updating");

    }
}
