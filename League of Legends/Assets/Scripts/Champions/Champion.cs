using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Champion : MonoBehaviour
{
    [Header("Champion Data")]
    [SerializeField] private ChampionStatData statData;

    // --- Champion Stat ---
    // Level
    [SerializeField] public int currentChampionLevel;
    // HP
    [Header("HP")]
    [SerializeField] public float bonusHP;
    private float currentLevelBaseHP;
    private float maxHP;
    [SerializeField] public float bonusHPRegen;
    private float currentLevelBaseHPRegen;
    private float maxHPRegen;
    // Armor
    [Header("AR")]
    [SerializeField] public float bonusAR;
    private float maxAR;
    private float currentLevelBaseAR;
    // Magic Res
    [Header("MR")]
    [SerializeField] public float bonusMR;
    private float currentLevelBaseMR;
    private float maxMR;
    // Attack Damage
    [Header("AD")]
    [SerializeField] public float bonusAD;
    private float currentLevelBaseAD;
    private float maxAD;
    // Ability Power
    [Header("AP")]
    [SerializeField] public float bonusAP;
    private float currentLevelBaseAP;
    private float maxAP;
    // Attack Speed
    [Header("AS")]
    [SerializeField] public float bonusAS;
    private float currentLevelBaseAS;
    private float maxAS;
    // Attack Range
    [Header("Attack Range")]
    [SerializeField] public float attackRange = 0;
    // Crit Rate
    [Header("Crit Rate")]
    [SerializeField] public float bonusCritRate;
    private float maxCritRate;
    // Crit Damage
    [Header("Crit Damage")]
    [SerializeField] public float bonusCritDamage;
    private float maxCritDamage;
    // Melee / Ranged
    [Header("Melee / Ranged")]
    [SerializeField] bool isMelee;
    // Auto Attack Prefab
    [Header("Ranged Prefab")]
    [SerializeField] GameObject AttackProjectilePrefab;
    // Cooldown Reduction
    [Header("CD")]
    [SerializeField] public float bonusCD;
    private float currentLevelBaseCD;
    private float maxCD;
    // Movement Speed
    [Header("MS")]
    [SerializeField] public float bonusMS;
    private float maxMS;
    // Mana
    [Header("Mana")]
    [SerializeField] public float bonusMana;
    private float currentLevelBaseMana;
    private float maxMana;
    [SerializeField] public float bonusManaRegen;
    private float currentLevelBaseManaRegen;
    private float maxManaRegen;
    // Energy
    [Header("Energy")]
    [SerializeField] public float bonusEnergy;
    private float currentLevelBaseEnergy;
    private float maxEnergy;
    [SerializeField] public float bonusEnergyRegen;
    private float currentLevelBaseEnergyRegen;
    private float maxEnergyRegen;
    // Anger
    [Header("Anger")]
    [SerializeField] public float bonusAnger;
    private float currentLevelBaseAnger;
    private float maxAnger;
    [SerializeField] public float bonusAngerRegen;
    private float currentLevelBaseAngerRegen;
    private float maxAngerRegen;
    // Shield
    [Header("Shield")]
    [SerializeField] public float bonusShield;
    private float currentLevelBaseShield;
    private float maxShield;
    [SerializeField] public float bonusShieldRegen;
    private float currentLevelBaseShieldRegen;
    private float maxShieldRegen;
    // Ferocity
    [Header("Ferocity")]
    [SerializeField] public float bonusFerocity;
    private float currentLevelBaseFerocity;
    private float maxFerocity;
    [SerializeField] public float bonusFerocityRegen;
    private float currentLevelBaseFerocityRegen;
    private float maxFerocityRegen;
    // Flow
    [Header("Flow")]
    [SerializeField] public float bonusFlow;
    private float currentLevelBaseFlow;
    private float maxFlow;
    [SerializeField] public float bonusFlowRegen;
    private float currentLevelBaseFlowRegen;
    private float maxFlowRegen;
    // BloodWell
    [Header("BloodWell")]
    [SerializeField] public float bonusBloodWell;
    private float currentLevelBaseBloodWell;
    private float maxBloodWell;
    [SerializeField] public float bonusBloodWellRegen;
    private float currentLevelBaseBloodWellRegen;
    private float maxBloodWellRegen;
    // Frenzy
    [Header("Frenzy")]
    [SerializeField] public float bonusFrenzy;
    private float currentLevelBaseFrenzy;
    private float maxFrenzy;
    [SerializeField] public float bonusFrenzyRegen;
    private float currentLevelBaseFrenzyRegen;
    private float maxFrenzyRegen;
    // Heat
    [Header("Head")]
    [SerializeField] public float bonusHeat;
    private float currentLevelBaseHeat;
    private float maxHeat;
    [SerializeField] public float bonusHeatRegen;
    private float currentLevelBaseHeatRegen;
    private float maxHeatRegen;
    // Grit
    [Header("Grit")]
    [SerializeField] public float bonusGrit;
    private float currentLevelBaseGrit;
    private float maxGrit;
    [SerializeField] public float bonusGritRegen;
    private float currentLevelBaseGritRegen;
    private float maxGritRegen;
    // Style
    [Header("Style")]
    [SerializeField] public float bonusStyle;
    private float currentLevelBaseStyle;
    private float maxStyle;
    [SerializeField] public float bonusStyleRegen;
    private float currentLevelBaseStyleRegen;
    private float maxStyleRegen;
    // Moonlight
    [Header("Moonlight")]
    [SerializeField] public float bonusMoonlight;
    private float currentLevelBaseMoonlight;
    private float maxMoonlight;
    [SerializeField] public float bonusMoonlightRegen;
    private float currentLevelBaseMoonlightRegen;
    private float maxMoonlightRegen;
    // Ammo
    [Header("Ammo")]
    [SerializeField] public float bonusAmmo;
    private float currentLevelBaseAmmo;
    private float maxAmmo;
    [SerializeField] public float bonusAmmoRegen;
    private float currentLevelBaseAmmoRegen;
    private float maxAmmoRegen;
    // Countdown
    [Header("CD")]
    [SerializeField] public float bonusCooldown;
    private float currentLevelBaseCooldown;
    private float maxCooldown;
    [SerializeField] public float bonusCooldownRegen;
    private float currentLevelBaseCooldownRegen;
    private float maxCooldownRegen;
    // Step - like
    [Header("Step")]
    [SerializeField] public float bonusStep;
    private float currentLevelBaseStep;
    private float maxStep;
    [SerializeField] public float bonusStepRegen;
    private float currentLevelBaseStepRegen;
    private float maxStepRegen;

    // --- Core State Machine ---
    public CoreChampionStateMachine stateMachine { get; private set; }
    public CoreChampionStateCollection states { get; private set; }

    public AutoAttackHandler autoAttackHandler { get; private set; }

    // --- Buff Manager ---
    public BuffManager buffs { get; private set; }

    // --- Resources ---
    public float CurrentHP { get; set; }
    public float CurrentMana { get; set; }
    public float CurrentEnergy { get; set; }
    public float CurrentFury { get; set; }
    public float CurrentShield { get; set; }
    public float CurrentFerocity { get; set; }
    public float CurrentFlow { get; set; }
    public float CurrentBloodWell { get; set; }
    public float CurrentFrenzy { get; set; }
    public float CurrentHeat { get; set; }
    public float CurrentStyle { get; set; }
    public float CurrentMoonlight { get; set; }
    public float CurrentAmmo { get; set; }
    public float CurrentCountdown { get; set; }
    public float CurrentStep { get; set; }

    // --- Champion State ---
    public bool IsDead => CurrentHP <= 0;

    // --- HP Checker ---
    public void MaxHPCheck() // to be called every time an item is bought
    {
        currentLevelBaseHP = statData.BaseHP + statData.HPGrowth * currentChampionLevel;
        currentLevelBaseHPRegen = statData.BaseHPRegen + statData.HPGrowth * currentChampionLevel;
        maxHP = currentLevelBaseHP + bonusHP;
        maxHPRegen = currentLevelBaseHPRegen + bonusHPRegen;
    }
    // --- AR Checker ---
    public void MaxARCheck() // to be called every time an item is bought
    {
        currentLevelBaseAR = statData.BaseAR + statData.ARGrowth * currentChampionLevel;
        maxAR = currentLevelBaseAR + bonusAR;
    }

    // --- MR Checker ---
    public void MaxMRCheck() // to be called every time an item is bought
    {
        currentLevelBaseMR = statData.BaseMR + statData.MRGrowth * currentChampionLevel;
        maxMR = currentLevelBaseMR + bonusMR;
    }

    // --- AD Checker ---
    public void MaxADCheck() // to be called every time an item is bought
    {
        currentLevelBaseAD = statData.BaseAD + statData.ADGrowth * currentChampionLevel;
        maxAD = currentLevelBaseAD + bonusAD;
    }

    // --- AP Checker ---
    public void MaxAPCheck() // to be called every time an item is bought
    {
        currentLevelBaseAP = statData.BaseAP + statData.APGrowth * currentChampionLevel;
        maxAP = currentLevelBaseAP + bonusAP;
    }

    // --- AS Checker ---
    public void MaxASCheck() // to be called every time an item is bought
    {
        currentLevelBaseAS = statData.BaseAS + statData.ASGrowth * currentChampionLevel;
        maxAS = currentLevelBaseAS + bonusAS;
    }

    // --- Crit Rate Checker ---
    public void MaxCritRateCheck() // to be called every time an item is bought
    {
        maxCritRate = statData.BaseCritRate + bonusCritRate;
    }

    // --- Crit Damage Checker ---
    public void MaxCritDamageCheck() // to be called every time an item is bought
    {
        maxCritDamage = statData.BaseCritDamage + bonusCritDamage;
    }

    // --- CD Checker ---
    public void MaxCDCheck() // to be called every time an item is bought
    {
        currentLevelBaseCD = statData.baseCD + statData.CDGrowth * currentChampionLevel;
        maxCD = currentLevelBaseCD + bonusCD;
    }

    // --- MS Checker ---
    public void MaxMSCheck() // to be called every time an item is bought
    {
        maxMS = statData.BaseMS + bonusMS; // possible problem when buying a item with a slow or buff to the MS
    }

    // --- Mana Checker ---
    public void MaxManaCheck() // to be called every time an item is bought
    {
        currentLevelBaseMana = statData.BaseMana + statData.ManaGrowth * currentChampionLevel;
        currentLevelBaseManaRegen = statData.BaseManaRegen + statData.ManaRegenGrowth * currentChampionLevel;
        maxMana = currentLevelBaseMana + bonusMana;
        maxManaRegen = currentLevelBaseManaRegen + bonusManaRegen;
    }

    // --- Energy Checker ---
    public void MaxEnergyCheck() // to be called every time an item is bought
    {
        currentLevelBaseEnergy = statData.BaseEnergy + statData.EnergyGrowth * currentChampionLevel;
        currentLevelBaseEnergyRegen = statData.BaseEnergyRegen + statData.EnergyRegenGrowth * currentChampionLevel;
        maxEnergy = currentLevelBaseEnergy + bonusEnergy;
        maxEnergyRegen = currentLevelBaseEnergyRegen + bonusEnergyRegen;
    }

    // --- Anger Checker ---
    public void MaxAngerCheck() // to be called every time an item is bought
    {
        currentLevelBaseAnger = statData.BaseAnger + statData.AngerGrowth * currentChampionLevel;
        currentLevelBaseAngerRegen = statData.BaseAngerRegen + statData.AngerRegenGrowth *currentChampionLevel;
        maxAnger = currentLevelBaseAnger + bonusAnger;
        maxAngerRegen = currentLevelBaseAngerRegen + bonusAngerRegen;
    }

    // --- Shield Checker ---
    public void MaxShieldCheck() // to be called every time an item is bought
    {
        currentLevelBaseShield = statData.BaseShield + statData.ShieldGrowth * currentChampionLevel;
        currentLevelBaseShieldRegen = statData.BaseShieldRegen + statData.ShieldRegenGrowth * currentChampionLevel;
        maxShield = currentLevelBaseShield + bonusShield;
        maxShieldRegen = currentLevelBaseShieldRegen + bonusShieldRegen;
    }

    // --- Ferocity Checker ---
    public void MaxFerocityCheck() // to be called every time an item is bought
    {
        currentLevelBaseFerocity = statData.BaseFerocity + statData.FerocityGrowth * currentChampionLevel;
        currentLevelBaseFerocityRegen = statData.BaseFerocityRegen + statData.FerocityRegenGrowth * currentChampionLevel;
        maxFerocity = currentLevelBaseFerocity + bonusFerocity;
        maxFerocityRegen = currentLevelBaseFerocityRegen + bonusFerocityRegen;
    }

    // --- Flow Checker ---
    public void MaxFlowCheck() // to be called every time an item is bought
    {
        currentLevelBaseFlow = statData.BaseFlow + statData.FlowGrowth * currentChampionLevel;
        currentLevelBaseFlowRegen = statData.BaseFlowRegen + statData.FlowRegenGrowth * currentChampionLevel;
        maxFlow = currentLevelBaseFlow + bonusFlow;
        maxFlowRegen = currentLevelBaseFlowRegen + bonusFlowRegen;
    }

    // --- BloodWell Checker ---
    public void MaxBloodWellCheck() // to be called every time an item is bought
    {
        currentLevelBaseBloodWell = statData.BaseBloodWell + statData.BloodWellGrowth * currentChampionLevel;
        currentLevelBaseBloodWellRegen = statData.BaseBloodWellRegen + statData.BloodWellRegenGrowth * currentChampionLevel;
        maxBloodWell = currentLevelBaseBloodWell + bonusBloodWell;
        maxBloodWellRegen = currentLevelBaseBloodWellRegen + bonusBloodWellRegen;
    }

    // --- Frenzy Checker ---
    public void MaxFrenzyCheck() // to be called every time an item is bought
    {
        currentLevelBaseFrenzy = statData.BaseFrenzy + statData.FrenzyGrowth * currentChampionLevel;
        currentLevelBaseFrenzyRegen = statData.BaseFrenzyRegen + statData.FrenzyRegenGrowth * currentChampionLevel;
        maxFrenzy = currentLevelBaseFrenzy + bonusFrenzy;
        maxFrenzyRegen = currentLevelBaseFrenzyRegen + bonusFrenzyRegen;
    }

    // --- Heat Checker ---
    public void MaxHeatCheck() // to be called every time an item is bought
    {
        currentLevelBaseHeat = statData.BaseHeat + statData.HeatGrowth * currentChampionLevel;
        currentLevelBaseHeatRegen = statData.BaseHeatRegen + statData.HeatRegenGrowth * currentChampionLevel;
        maxHeat = currentLevelBaseHeat + bonusHeat;
        maxHeatRegen = currentLevelBaseHeatRegen + bonusHeatRegen;
    }

    // --- Grit Checker ---
    public void MaxGritCheck() // to be called every time an item is bought
    {
        currentLevelBaseGrit = statData.BaseGrit + statData.GritGrowth * currentChampionLevel;
        currentLevelBaseGritRegen = statData.BaseGritRegen + statData.GritRegenGrowth * currentChampionLevel;
        maxGrit = currentLevelBaseGrit + bonusGrit;
        maxGritRegen = currentLevelBaseGritRegen + bonusGritRegen;
    }

    // --- Style Checker ---
    public void MaxStyleCheck() // to be called every time an item is bought
    {
        currentLevelBaseStyle = statData.BaseStyle + statData.StyleGrowth * currentChampionLevel;
        currentLevelBaseStyleRegen = statData.BaseStyleRegen + statData.StyleRegenGrowth * currentChampionLevel;
        maxStyle = currentLevelBaseStyle + bonusStyle;
        maxStyleRegen = currentLevelBaseStyleRegen + bonusStyleRegen;
    }

    // --- Moonlight Checker ---
    public void MaxMoonlightCheck() // to be called every time an item is bought
    {
        currentLevelBaseMoonlight = statData.BaseMoonlight + statData.MoonlightGrowth * currentChampionLevel;
        currentLevelBaseMoonlightRegen = statData.BaseMoonlightRegen + statData.MoonlightRegenGrowth * currentChampionLevel;
        maxMoonlight = currentLevelBaseMoonlight + bonusMoonlight;
        maxMoonlightRegen = currentLevelBaseMoonlightRegen + bonusMoonlightRegen;
    }

    // --- Ammo Checker ---
    public void MaxAmmoCheck() // to be called every time an item is bought
    {
        currentLevelBaseAmmo = statData.BaseAmmo + statData.AmmoGrowth * currentChampionLevel;
        currentLevelBaseAmmoRegen = statData.BaseAmmoRegen + statData.AmmoRegenGrowth * currentChampionLevel;
        maxAmmo = currentLevelBaseAmmo + bonusAmmo;
        maxAmmoRegen = currentLevelBaseAmmoRegen + bonusAmmoRegen;
    }

    // --- Countdown Checker ---
    public void MaxCountdownCheck() // to be called every time an item is bought
    {
        currentLevelBaseCooldown = statData.BaseCountdown + statData.CountdownGrowth * currentChampionLevel;
        currentLevelBaseCooldownRegen = statData.BaseCountdownRegen + statData.CountdownRegenGrowth * currentChampionLevel;
        maxCooldown = currentLevelBaseCooldown + bonusCooldown;
        maxCooldownRegen = currentLevelBaseCooldownRegen + bonusCooldownRegen;
    }

    // --- Step Checker ---
    public void MaxStepCheck() // to be called every time an item is bought
    {
        currentLevelBaseStep = statData.BaseStep + statData.StepGrowth * currentChampionLevel;
        currentLevelBaseStepRegen = statData.BaseStepRegen + statData.StepRegenGrowth * currentChampionLevel;
        maxStep = currentLevelBaseStep + bonusStep;
        maxStepRegen = currentLevelBaseStepRegen + bonusStepRegen;
    }

    // --- Auto Attack Needed Stat ---
    public float GetAD()
    {
        return maxAD;
    }

    public float GetAS()
    {
        return maxAS;
    }

    private void Awake()
    {
        // Buff manager
        buffs  = new BuffManager(this);

        // State machine
        stateMachine = new CoreChampionStateMachine();
        states = new CoreChampionStateCollection(GetComponent<PlayerGeneral>(), stateMachine);

        // AutoAttackHandler
        autoAttackHandler = new AutoAttackHandler(this, isMelee, AttackProjectilePrefab);
    }

    private void Start()
    {
        stateMachine.Initialize(states.IDLESTATE);
    }

    private void Update()
    {
        buffs.UpdateBuffs();
        stateMachine.state.Update();
        autoAttackHandler.Update();
    }

    private void FixedUpdate()
    {
        stateMachine.state.FixedUpdate();
    }

    private void LateUpdate()
    {
        stateMachine.state.LateUpdate();
    }

    // --- Combat Methods ---
    public void TakeDamage(float amount)
    {
        
    }

    public void Heal(float amount)
    {
        
    }

    private void Die()
    {
        Debug.Log($"{gameObject.name} has died.");
        stateMachine.Change(states.DEADSTATE);
    }
    /*
    public bool HasEnoughResource(ResourceType resourceType, float cost)
    {
        switch (resourceType)
        {
            case ResourceType.None:
                return true;
            
            case ResourceType.Mana:
                return CurrentMana >= cost;

            case ResourceType.HP:
                return CurrentHP >= cost;
            
            case ResourceType.Energy:
                return CurrentEnergy >= cost;
            
            case ResourceType.Fury:
                return CurrentFury >= cost;
            
            case ResourceType.Shield:
                return CurrentShield >= cost;
            
            case ResourceType.Ferocity:
                return CurrentFerocity >= cost;
            
            case ResourceType.Flow:
                return CurrentFlow >= cost;
            
            case ResourceType.BloodWell:
                return CurrentBloodWell >= cost;
            
            case ResourceType.Frenzy:
                return CurrentHP > cost;
            
            case ResourceType.Heat:
                return (CurrentHeat + cost) <= MaxHeat;
            
            case ResourceType.Style:
                return CurrentStyle >= cost;
            
            case ResourceType.Moonlight:
                return CurrentMoonlight >= cost;
            
            case ResourceType.Ammo:
                return CurrentAmmo >= cost;
            
            case ResourceType.Countdown:
                return CurrentCountdown >= cost;
            
            case ResourceType.Step:
                return CurrentStep >= cost;
            
            case ResourceType.Custom:
                return HasCustomResource(cost);

            default:
                return true;
        }
    }*/

    /*
    public void SpendResource(ResourceType resourceType, float cost)
    {
        switch (resourceType)
        {
            case ResourceType.None: 
                break;
            
            case ResourceType.Mana: 
                CurrentMana -= cost; 
                break;

            case ResourceType.HP:
                CurrentHP -= cost;
                break;
            
            case ResourceType.Energy: 
                CurrentEnergy -= cost; 
                break;
            
            case ResourceType.Fury: 
                CurrentFury -= cost; 
                break;
            
            case ResourceType.Shield: 
                CurrentShield -= cost; 
                break;
            
            case ResourceType.Ferocity: 
                CurrentFerocity -= cost; 
                break;
            
            case ResourceType.Flow: 
                CurrentFlow -= cost; 
                break;
            
            case ResourceType.BloodWell: 
                CurrentBloodWell -= cost; 
                break;
            
            case ResourceType.Frenzy: 
                TakeDamage(cost); 
                break;
            
            case ResourceType.Heat: 
                CurrentHeat += cost; 
                if (CurrentHeat > MaxHeat) CurrentHeat = MaxHeat; 
                break;
            
            case ResourceType.Style: 
                CurrentStyle -= cost; 
                break;
            
            case ResourceType.Moonlight: 
                CurrentMoonlight -= cost; 
                break;
            
            case ResourceType.Ammo: 
                CurrentAmmo -= cost; 
                break;
            
            case ResourceType.Countdown: 
                CurrentCountdown -= cost; 
                break;
            
            case ResourceType.Step: 
                CurrentStep -= cost; 
                break;
            
            case ResourceType.Custom: 
                SpendCustomResource(cost); 
                break;
        }
    }*/

    // --- Custom Resource Hooks ---
    public virtual bool HasCustomResource(float cost) => true;
    public virtual void SpendCustomResource(float cost) { }
}
