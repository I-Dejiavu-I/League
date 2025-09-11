using UnityEngine;

public abstract class ChampionPassive : MonoBehaviour
{
    protected PlayerGeneral player;

    public virtual void Initialize(PlayerGeneral player)
    {
        this.player = player;
    }

    public virtual void OnTick() // called every frame
    {

    }

    public virtual void OnHit()
    {

    }
}
