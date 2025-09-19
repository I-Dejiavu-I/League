using UnityEngine;

public class LifeStealOnHit : IOnHitEffect
{
    public void OnHit(Champion attacker, Champion target, float damageDealt)
    {
        float lifeStealPercent = attacker.GetLifestealPercentage();
        if (lifeStealPercent > 0)
        {
            float healAmount = damageDealt * lifeStealPercent;
            attacker.Heal(healAmount);
        }
    }
}
