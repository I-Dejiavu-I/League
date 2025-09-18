using UnityEngine;

public class AutoAttackHandler
{
    private Champion _owner;
    private IAttackType attackType;

    private float attackCooldown;
    private float lastAttackTime;

    public AutoAttackHandler(Champion owner, bool isMelee, GameObject projectilePrefab)
    {
        this._owner = owner;

        if (isMelee)
        {
            attackType = new MeleeType();
        }
        else
        {
            attackType = new RangedType(projectilePrefab);
        }

        attackCooldown =owner.GetAS();
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            TryAttack();
        }
    }

    public void TryAttack()
    {
        if (Time.time - lastAttackTime < attackCooldown)
        {
            return; // Still in cooldown
        }

        Champion target = FindTarget();

        if (target != null)
        {
            return;
        }

        attackType.ExecuteAttack(_owner, target);
        lastAttackTime = Time.time;
    }

    private Champion FindTarget()
    {
        Collider[] hits = Physics.OverlapSphere(_owner.transform.position, _owner.attackRange);
        foreach (var hit in hits)
        {
            Champion champ = hit.GetComponent<Champion>();

            if (champ != null && champ != _owner && champ.IsDead)
            {
                return champ;
            }
        }

        return null;
    }
}
