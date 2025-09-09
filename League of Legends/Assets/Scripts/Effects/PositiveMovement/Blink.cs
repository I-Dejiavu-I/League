using UnityEngine;

public class Blink : PositiveMovementBase
{
    public Vector3 _targetPosition;

    public Blink(Champion owner, Champion source, float duration, float movementSpeedBonus, Vector3 targetPosition) : base(owner, source, 0.1f, movementSpeedBonus)
    {
        this._targetPosition = targetPosition;
    }

    public override void OnApply()
    {
        Debug.Log($"{Owner.name} stats to teleport");

        Owner.transform.position = _targetPosition;

        Debug.Log($"{Owner.name} blinked");
    }

    public override void OnTick()
    {
        
    }

    public override void OnExpire()
    {
        
    }
}
