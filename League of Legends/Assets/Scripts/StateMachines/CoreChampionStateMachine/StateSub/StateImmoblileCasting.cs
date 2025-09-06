using UnityEngine;

public class StateImmoblileCasting : StateSuperOnGround
{
    public StateImmoblileCasting(PlayerGeneral CORECHAMPIONPLAYER, CoreChampionStateMachine CORECHAMPIONSTATEMACHINE, float duration) : base (CORECHAMPIONPLAYER, CORECHAMPIONSTATEMACHINE)
    {
        this.immobileCastingDuration = duration;
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
