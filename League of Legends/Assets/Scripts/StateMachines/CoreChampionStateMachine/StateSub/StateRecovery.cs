using UnityEngine;

public class StateRecovery : StateSuperOnGround
{
    public StateRecovery(PlayerGeneral CORECHAMPIONPLAYER, CoreChampionStateMachine CORECHAMPIONSTATEMACHINE, float duration) : base (CORECHAMPIONPLAYER, CORECHAMPIONSTATEMACHINE)
    {
        this.recoveryDuration = duration;
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
