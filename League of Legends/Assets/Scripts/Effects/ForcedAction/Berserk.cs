using UnityEngine;

public class Berserk : ForcedActionBase
{
    public Berserk (Champion owner, float duration) : base(owner, duration)
    {

    }

    public override void OnApply()
    {
        Debug.Log($"{owner.name} Berserk activated. Champion cannot be controlled.");
        // to be added the actual effect
    }

    public override void OnTick()
    {
        // here the decaing of the second bar
    }

    public override void OnExpire()
    {
        Debug.Log($"{owner.name} Berserk ended.");
        // end the effect
    }
}
