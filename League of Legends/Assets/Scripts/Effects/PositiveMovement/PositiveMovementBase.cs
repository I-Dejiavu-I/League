using UnityEngine;

public class PositiveMovementBase : BuffBase
{
    protected float _movementSpeedBonus;
    public PositiveMovementBase(Champion owner, Champion source, float duration, float movementSpeedBonus) : base(owner, source, duration)
    {
        this._movementSpeedBonus = movementSpeedBonus;
    }

    public override void OnApply()
    {
        Debug.Log($"{Owner.name} has gained a movement buff: {BuffName}");
        // Owner.MovementSpeed += movementSpeedBonus;
    }

    public override void OnExpire()
    {
        Debug.Log($"{Owner.name} has lost a movement buff: {BuffName}");
        // Owner.MovementSpeed += movementSpeedBonus;
    }
}
