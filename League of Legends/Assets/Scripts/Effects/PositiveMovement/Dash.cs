using UnityEngine;

public class Dash : PositiveMovementBase
{
    private Vector3 _direction;
    private float _dashSpeed;
    private float _distance;
    private float _travelled;

    public Dash(Champion owner, Champion source, float duration, float movementSpeedBonus, Vector3 direction, float dashSpeed, float distance) : base(owner, source, duration, movementSpeedBonus)
    {
        BuffName = "Dash";
        this._direction = direction;
        this._dashSpeed = dashSpeed;
        this._distance = distance;
        this._travelled = 0f;
    }

    public override void OnApply()
    {
        // disable movement while dashing (optional) disabling AA and abilities
        Debug.Log($"{Owner.name} is dashing");

    }

    public override void OnTick()
    {
        if (IsExpired) return;

        float moveStep = _dashSpeed * Time.deltaTime;
        Owner.transform.position += _direction * moveStep;
        _travelled += moveStep;
    }

    public override void OnExpire()
    {
        
    }
}
