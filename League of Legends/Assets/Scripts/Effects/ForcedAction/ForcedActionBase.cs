using UnityEngine;

public abstract class ForcedActionBase
{
    protected Champion owner;
    protected float Duration;
    protected float StartTime;

    public bool IsExpired => Time.time >= StartTime + Duration;

    public ForcedActionBase(Champion owner, float duration)
    {
        this.owner = owner;
        this.Duration = duration;
        StartTime = Time.time;
    }

    public virtual void OnApply()
    {

    }

    public virtual void OnTick()
    {

    }

    public virtual void OnExpire()
    {

    }
}
