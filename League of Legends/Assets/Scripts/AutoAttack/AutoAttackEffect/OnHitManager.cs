using UnityEngine;
using System.Collections.Generic;

public class OnHitManager
{
    private List<IOnHitEffect> effects = new List<IOnHitEffect>();

    public void AddEffect(IOnHitEffect effect)
    {
        effects.Add(effect);
    }

    public void RemoveEffect(IOnHitEffect effect)
    {
        effects.Remove(effect);
    }

    public void TriggerOnHit(Champion attacker, Champion target, float damageDealt)
    {
        foreach (var effect in effects)
        {
            effect.OnHit(attacker, target, damageDealt);
        }
    }
}
