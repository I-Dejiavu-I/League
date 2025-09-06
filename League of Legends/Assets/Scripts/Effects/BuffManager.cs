using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffManager
{
    public Champion owner;
    private List<BuffBase> activeBuffs = new List<BuffBase>();

    public BuffManager(Champion owner)
    {
        this.owner = owner;
    }

    public void AddBuff(BuffBase buff)
    {
        buff.OnApply();
        activeBuffs.Add(buff);
    }

    public void UpdateBuffs()
    {
        for (int i = activeBuffs.Count -1; i >= 0; i--)
        {
            BuffBase buff = activeBuffs[i];
            buff.OnTick();

            if (buff.IsExpired)
            {
                buff.OnExpire();
                activeBuffs.RemoveAt(i);
            }
        }
    }

    public IEnumerable<BuffBase> GetActiveBuffs()
    {
        return activeBuffs;
    }
}
