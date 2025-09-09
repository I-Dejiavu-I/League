using UnityEngine;

public abstract class BuffBase
{
    // --- General ---
    public string BuffName { get; protected set; }
    public Champion Owner {  get; protected set; }
    public Champion Source { get; protected set; }

    // --- Duration ---
    public float Duration { get; protected set; }
    public float StartTime { get; protected set; }
    public bool IsExpired => Time.time >= StartTime + Duration;

    // --- Stack / Refresh Setting ---
    public virtual bool canStack => false;
    protected int stackCount = 1;

    // --- Cunstructor ---
    protected BuffBase (Champion owner, Champion source, float duration)
    {
        Owner = owner;
        Source = source;
        Duration = duration;
        StartTime = Time.time;
    }

    // --- Life Cycle ---
    public virtual void OnApply()
    {
        Debug.Log($"{BuffName} applied on {Owner.name}");
    }

    public virtual void OnTick () // DOT
    {

    }

    public virtual void OnExpire ()
    {
        Debug.Log($"{BuffName} has expired on {Owner.name}");
    }

    // --- Refresh Logic ---
    public virtual void Refresh ()
    {
        StartTime = Time.time;
    }

    public virtual void AddStack ()
    {
        if (canStack)
        {
            stackCount++;
            Refresh();
        }

        else
        {
            Refresh();
        }
    }
}
