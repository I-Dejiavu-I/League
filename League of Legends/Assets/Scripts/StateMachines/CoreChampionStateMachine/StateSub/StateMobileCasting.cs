using UnityEngine;

public class StateMobileCasting : StateSuperOnGround
{
    public StateMobileCasting(PlayerGeneral CORECHAMPIONPLAYER, CoreChampionStateMachine CORECHAMPIONSTATEMACHINE, float duration) : base (CORECHAMPIONPLAYER, CORECHAMPIONSTATEMACHINE)
    {
        this.mobileCastingDuration = duration;
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
