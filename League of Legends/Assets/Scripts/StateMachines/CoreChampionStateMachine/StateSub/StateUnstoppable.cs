using UnityEngine;

public class StateUnstoppable : StateSuperOnGround
{
    public StateUnstoppable(PlayerGeneral CORECHAMPIONPLAYER, CoreChampionStateMachine CORECHAMPIONSTATEMACHINE, float duration) : base (CORECHAMPIONPLAYER, CORECHAMPIONSTATEMACHINE)
    {
        this.unstopppableDuration = duration;
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
