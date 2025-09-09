using UnityEngine;

public class PositiveForcedActionBase : BuffBase
{
    public PositiveForcedActionBase(Champion owner, Champion source, float duration) : base(owner, source, duration)
    {

    }

    public override void OnApply()
    {
        Debug.Log($"{Owner.name} has gained a positive forced action buff: {BuffName}");
    }

    public override void OnExpire()
    {
        Debug.Log($"{Owner.name} has lost a positive forced action buff: {BuffName}");
    }
}
