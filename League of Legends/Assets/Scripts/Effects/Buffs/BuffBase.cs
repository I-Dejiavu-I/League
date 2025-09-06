using UnityEngine;

public abstract class BuffBase
{
    public float Duration;
    public Champion Owner;
    protected float startTime;

    public BuffBase(float duration, Champion owner)
    {
        Duration = duration;
        Owner = owner;
        startTime = Time.time;
    }

    public bool IsExpired => Time.time >= startTime + Duration;

    // called every frame
    public virtual void OnTick()
    {

    }

    // called when the buff is applied
    public virtual void OnApply()
    {

    }

    // called when the buff expires or is removed
    public virtual void OnExpire()
    {

    }
}
