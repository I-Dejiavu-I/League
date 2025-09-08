using UnityEngine;

public class BriarW : AbilitiesBase
{
    private float berserkDuration;

    public BriarW (Champion owner) : base ("Briar W", owner, new float[] {8f, 7f, 6f, 5f}, new float[] {0f, 0f, 0f, 0f, 0f}, ResourceType.Frenzy)
    {

    }

    public override void Cast()
    {
        Debug.Log($"{Owner.name} casts {AbilityName}!");

        // Resource dacaying while active
    }
}
