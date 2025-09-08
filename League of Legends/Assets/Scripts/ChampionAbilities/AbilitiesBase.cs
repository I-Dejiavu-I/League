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
    [Header("Resource")]
    [SerializeField] string resourceName;
    private ResourceType cashedResource;
    private bool resourceInitialized = false;

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
        cashedResource = resourceType;
    }

    // --- Private Methods ---
    private void InitializeResource()
    {
        if (resourceInitialized) return;
        
        switch (resourceName.ToLower())
        {
            case "": 
                cashedResource = ResourceType.None;
                break;
            case "HP": 
                cashedResource = ResourceType.HP;
                break;
            case "Energy": 
                cashedResource = ResourceType.Energy;
                break;
            case "Mana": 
                cashedResource = ResourceType.Mana;
                break;
            case "Fury":  
                cashedResource = ResourceType.Fury;
                break;
            case "Anger":
                cashedResource = ResourceType.Anger;
                break;
            case "Shield":
                cashedResource = ResourceType.Shield;
                break;
            case "Ferocity":
                cashedResource = ResourceType.Ferocity;
                break;
            case "Flow":
                cashedResource = ResourceType.Flow;
                break;
            case "BloodWell":
                cashedResource = ResourceType.BloodWell;
                break;
            case "Frenzy":
                cashedResource = ResourceType.Frenzy;
                break;
            case "Heat":
                cashedResource = ResourceType.Heat;
                break;
            case "Grit":
                cashedResource = ResourceType.Grit;
                break;
            case "Style":
                cashedResource = ResourceType.Style;
                break;
            case "Moonlight":
                cashedResource = ResourceType.Moonlight;
                break;
            case "Ammo":
                cashedResource = ResourceType.Ammo;
                break;
            case "Countdown":
                cashedResource = ResourceType.Countdown;
                break;
            case "Step":
                cashedResource = ResourceType.Step;
                break;
            case "Custom":
                cashedResource = ResourceType.Custom;
                break;
        }
        resourceInitialized = true;
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

        if (!Owner.HasEnoughResource(cashedResource, Cost))
        {
            Debug.Log($"Not enough {cashedResource} to cast {AbilityName}.");
            return;
        }

        // Pay cost
        Owner.SpendResource(cashedResource, Cost);

        // Perform ability logic
        Cast();

        // Start cooldown
        lastCastTime = Time.time;
    }

    public bool HasEnoughResource()
    {
        InitializeResource();
        return Owner.HasEnoughResource(cashedResource, Cost);
    }

    public void SpendResource()
    {
        InitializeResource();
        Owner.SpendResource(cashedResource,Cost);
    }
    // --- Abstract method ---
    public abstract void Cast();
}