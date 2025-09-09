using UnityEngine;

public class PositiveBuffBase : BuffBase
{
    public PositiveBuffBase(Champion owner, Champion source, float duration) : base(owner, source, duration)
    {

    }

    public override void OnApply()
    {
        Debug.Log($"{Owner.name} has gained a positive buff: {BuffName}");
    }

    public override void OnExpire()
    {
        Debug.Log($"{Owner.name} has lost a positive buff: {BuffName}");
    }
}
