using System.Runtime.CompilerServices;
using UnityEngine;

public class RangedType : IAttackType
{
    private GameObject _projectilePrefab;

    public RangedType (GameObject projectilePrefab)
    {
        _projectilePrefab = projectilePrefab;
    }

    public void ExecuteAttack(Champion attacker, Champion target)
    {
        GameObject proj = GameObject.Instantiate(_projectilePrefab, attacker.transform.position, Quaternion.identity);
        Projectile projectile = proj.GetComponent<Projectile>();
        projectile.Initialize(attacker, target, attacker.GetAD());
    }
}
