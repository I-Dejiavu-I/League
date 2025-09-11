using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Champion _owner;
    private Champion _target;
    private float _damage;
    [SerializeField] private float projectileSpeed = 15f;

    public void Initialize(Champion owner, Champion target, float damage)
    {
        _owner = owner;
        _target = target;
        _damage = damage;
    }

    private void Update()
    {
        if (_target == null || _target.IsDead)
        {
            Destroy(gameObject);
            return;
        }

        // Move towards the target
        transform.position = Vector3.MoveTowards(
            transform.position,
            _target.transform.position,
            projectileSpeed * Time.deltaTime
        );

        // Check if reached the target
        if (Vector3.Distance(transform.position, _target.transform.position) < 0.5f)
        {
            _target.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }
}
