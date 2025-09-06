using UnityEngine;

public abstract class AbilitiesBase
{
    // --- Basic Info ---
    public string AbilityName { get; protected set; }
    public Champion Owner { get; protected set; }

    // --- Leveling ---
    private int currentLevel = 0; // 0 = unlearned
    private float[] cooldownsPerLevel;
    private float[] costsPerLevel;

    // --- Cooldown Handling ---
    private float lastCastTime = float.NegativeInfinity;

    // --- Resource Type ---
    public ResourceType ResourceType { get; protected set; }

    // --- Properties ---
    public int CurrentLevel => currentLevel;
    public bool IsLearned => currentLevel > 0;

    public bool IsOnCooldown => Time.time < lastCastTime + Cooldown;
    public float Cooldown => IsLearned ? cooldownsPerLevel[currentLevel - 1] : 0f;
    public float Cost => IsLearned ? costsPerLevel[currentLevel - 1] : 0f;

    // --- Constructor ---
    protected AbilitiesBase(string abilityName, Champion owner, float[] cooldowns, float[] costs, ResourceType resourceType)
    {
        AbilityName = abilityName;
        Owner = owner;
        cooldownsPerLevel = cooldowns;
        costsPerLevel = costs;
        ResourceType = resourceType;
    }

    // --- Public Methods ---
    public void LevelUp()
    {
        if (currentLevel < cooldownsPerLevel.Length)
        {
            currentLevel++;
            Debug.Log($"{AbilityName} leveled up to {currentLevel}");
        }
    }

    public void TryCast()
    {
        if (!IsLearned)
        {
            Debug.Log($"{AbilityName} is not learned yet.");
            return;
        }

        if (IsOnCooldown)
        {
            Debug.Log($"{AbilityName} is on cooldown.");
            return;
        }

        if (!Owner.HasEnoughResource(ResourceType, Cost))
        {
            Debug.Log($"Not enough {ResourceType} to cast {AbilityName}.");
            return;
        }

        // Pay cost
        Owner.SpendResource(ResourceType, Cost);

        // Perform ability logic
        Cast();

        // Start cooldown
        lastCastTime = Time.time;
    }

    // --- Abstract method ---
    public abstract void Cast();
}