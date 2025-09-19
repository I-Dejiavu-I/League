using UnityEngine;

public interface IOnHitEffect
{
    void OnHit(Champion attacker, Champion target, float damageDealt);
}
