using UnityEngine;

public class BonusDamageOnHit : IOnHitEffect
{
    public void OnHit(Champion attacker, Champion target, float damageDealt)
    {
        float physicalOnHit = attacker.GetOnHItPhysicalDamage();
        float magicOnHit = attacker.GetOnHitMagicDamage();

        if (physicalOnHit > 0)
        {
            target.TakeDamage(physicalOnHit);
        }

        if (magicOnHit > 0)
        {
            target.TakeDamage(magicOnHit);
        }
    }
}
