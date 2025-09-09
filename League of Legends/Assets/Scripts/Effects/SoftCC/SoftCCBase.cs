using UnityEngine;

public class SoftCCBase : BuffBase
{
    public SoftCCBase(Champion owner, Champion source, float duration) : base(owner, source, duration)
    {

    }

    public override void OnApply()
    {
        Debug.Log($"{Owner.name} has gained a soft CC debuff: {BuffName}");
    }

    public override void OnExpire()
    {
        Debug.Log($"{Owner.name} has lost a soft CC debuff: {BuffName}");
    }
}
