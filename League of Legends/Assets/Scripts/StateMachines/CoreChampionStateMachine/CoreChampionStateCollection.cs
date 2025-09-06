using UnityEngine;

public class CoreChampionStateCollection
{
    public StateIdle IDLESTATE { get; private set; }
    public StateMoving MOVINGSTATE { get; private set; }
    public StateDead DEADSTATE { get; private set; }

    public CoreChampionStateCollection(PlayerGeneral playerGeneral, CoreChampionStateMachine stateMachine)
    {
        IDLESTATE = new StateIdle(playerGeneral, stateMachine);
        MOVINGSTATE = new StateMoving(playerGeneral, stateMachine);
        DEADSTATE = new StateDead(playerGeneral, stateMachine); 
    }

    public StateUnstoppable UNSTOPPABLESTATE (PlayerGeneral playerGeneral, CoreChampionStateMachine stateMachine, float duration) => new StateUnstoppable(playerGeneral, stateMachine, duration);
    public StateMobileCasting MOBILECASTINGSTATE (PlayerGeneral playerGeneral, CoreChampionStateMachine stateMachine, float duration) => new StateMobileCasting(playerGeneral, stateMachine, duration);
    public StateSlowedCasting SLOWEDCASTINGSTATE (PlayerGeneral playerGeneral, CoreChampionStateMachine stateMachine, float duration) => new StateSlowedCasting(playerGeneral, stateMachine, duration);
    public StateImmoblileCasting IMMOBILECASTINGSTATE (PlayerGeneral playerGeneral, CoreChampionStateMachine stateMachine, float duration) => new StateImmoblileCasting(playerGeneral, stateMachine, duration);
    public StateCharging CHARGINGSTATE (PlayerGeneral playerGeneral, CoreChampionStateMachine stateMachine, float duration) => new StateCharging(playerGeneral, stateMachine, duration);
    public StateChanneling CHANNELINGSTATE (PlayerGeneral playerGeneral, CoreChampionStateMachine stateMachine, float duration) => new StateChanneling(playerGeneral, stateMachine, duration);
}
