using UnityEngine;

public class StateCharging : StateSuperOnGround
{
    public StateCharging(PlayerGeneral CORECHAMPIONPLAYER, CoreChampionStateMachine CORECHAMPIONSTATEMACHINE, float duration) : base (CORECHAMPIONPLAYER, CORECHAMPIONSTATEMACHINE)
    {
        this.chargingDuration = duration;
    }

    public override void Enter()
    { 
        base.Enter();
    }

    protected override void OnDurationEnd()
    { 
        CORECHAMPIONSTATEMACHINE.Change(PLAYERGENERAL.CORECHAMPIONSTATES.IDLESTATE);
    }

    public override void Exit()
    {

    }
}
