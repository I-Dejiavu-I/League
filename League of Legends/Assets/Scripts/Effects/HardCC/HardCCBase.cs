using UnityEngine;

public class HardCCBase : BuffBase
{
    public HardCCBase(Champion owner, Champion source, float duration, float movementSpeedBonus) : base(owner, source, duration)
    {
        
    }

    public override void OnApply()
    {
        Debug.Log($"{Owner.name} has gained a hard CC debuff: {BuffName}");
    }

    public override void OnExpire()
    {
        Debug.Log($"{Owner.name} hase lost a hard CC debuff: {BuffName}");
    }
}
