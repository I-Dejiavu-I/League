using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class AutoAttackController
{
    private Champion owner;
    private float lastAttackTime;
    private List <Champion> targetsInRange = new List<Champion>();
    private Champion currentTarget;

    public AutoAttackController(Champion owner)
    {
        this.owner = owner;
    }

    public void Update()
    {
        if (currentTarget == null || currentTarget.IsDead)
        {
            FindTarget();
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            TryAutoAttack();
        }
    }

    public void AddTarget(Champion target)
    {
        if (!targetsInRange.Contains(target))
        {
            targetsInRange.Add(target);
        }
    }

    public void RemoveTarget(Champion target)
    {
        if (targetsInRange.Contains(target))
        {
            targetsInRange.Remove(target);
        }
    }

    public void FindTarget()
    {
        if (targetsInRange.Count > 0)
        {
            currentTarget = targetsInRange[0];
        }
    }

    private void TryAutoAttack()
    {
        if (Time.time > lastAttackTime + 1f / owner.AttackSpeed)
            return;

        if (currentTarget == null || currentTarget.IsDead)
            return;

        if (owner.isMelee)
        {
            PerformMeleeAttack();
        }
        else
        {
            PerformRangedAttack();
        }

        lastAttackTime = Time.time;
    }

    private void PerformMeleeAttack()
    {
        Debug.Log($"{owner.name} hits {currentTarget.name} for {owner.AttackDamage} Damage");
        currentTarget.TakeDamage(owner.AttackDamage);
    }

    private void PerformRangedAttack()
    {
        if (owner.AttackProjectilePrefab == null)
            return;

        GameObject proj = GameObject.Instantiate(owner.AttackProjectilePrefab, owner.transform.position + Vector3.up, Quaternion.identity);

        Projectile projectile = proj.GetComponent<Projectile> ();
        projectile.Initialize(owner, currentTarget, owner.AttackDamage);
    }
}
