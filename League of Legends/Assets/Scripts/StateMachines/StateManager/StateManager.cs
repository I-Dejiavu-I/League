using UnityEngine;

public class StateManager
{
    protected PlayerGeneral PLAYERGENERAL;

    protected CoreChampionStateMachine CORECHAMPIONSTATEMACHINE;

    protected float unstopppableDuration;
    protected float unstopppableDurationTimer;

    protected float recoveryDuration;
    protected float recoveryDurationTimer;

    protected float mobileCastingDuration;
    protected float mobileCastingDurationTimer;

    protected float slowedCastingDuration;
    protected float slowedCastingDurationTimer;

    protected float immobileCastingDuration;
    protected float immobileCastingDurationTimer;

    protected float chargingDuration;
    protected float chargingDurationTimer;

    protected float channellingDuration;
    protected float channellingDurationTimer;

    public StateManager(PlayerGeneral CORECHAMPIONPLAYER, CoreChampionStateMachine CORECHAMPIONSTATEMACHINE)
    {
        this.PLAYERGENERAL = CORECHAMPIONPLAYER;
        this.CORECHAMPIONSTATEMACHINE = CORECHAMPIONSTATEMACHINE;
    }

    public virtual void Enter()
    { 
        
    }

    public virtual void Update()
    {
        
    }

    protected virtual void OnDurationEnd()
    { 
    
    }

    public virtual void FixedUpdate()
    {

    }

    public virtual void LateUpdate()
    {

    }

    public virtual void Exit()
    { 
    
    }
}
