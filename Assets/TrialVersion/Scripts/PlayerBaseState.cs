using UnityEngine;

public abstract class PlayerBaseState
{
    public abstract void Enter(PlayerStateMachine _manager);
    public abstract void Update(PlayerStateMachine _manager);
}
