using UnityEngine;

public class NegativeMovementBase : BuffBase
{
    protected float _movementSPeedReduction;
    public NegativeMovementBase(Champion owner, Champion source, float duration, float movementSpeedReduction) : base(owner, source, duration)
    {
        this._movementSPeedReduction = movementSpeedReduction;
    }

    public override void OnApply()
    {
        Debug.Log($"{Owner.name} has gained a negative movement debuff: {BuffName}");
        // Owner.MovementSpeed -= movementSpeedReduction;
    }

    public override void OnExpire()
    {
        Debug.Log($"{Owner.name} has lost a negative movement debuff: {BuffName}");
        // Owner.MovementSpeed += movementSpeedReduction;
    }
}
