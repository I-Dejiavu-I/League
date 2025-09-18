using UnityEngine;

public class MeleeType : IAttackType
{
    public void ExecuteAttack(Champion attacker, Champion target)
    {
        float damage = attacker.GetAD();
        target.TakeDamage(damage);
        Debug.Log($"{attacker.name} attacked {target.name} for {damage} damage.");
    }
}
