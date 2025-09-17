using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Champion : MonoBehaviour
{
    [Header("Champion Data")]
    [SerializeField] private ChampionStatData statData;

    // --- CHampionStat ---
    // Level
    [SerializeField] int currentChampionLevel;
    // HP
    [Header("HP")]
    [SerializeField] float bonusHP;
    private float currentLevelBaseHP;
    private float maxHP;
    [SerializeField] float bonusHPRegen;
    private float currentLevelBaseHPRegen;
    private float maxHPRegen;
    // Armor
    [Header("AR")]
    [SerializeField] float bonusAR;
    private float maxAR;
    private float currentLevelBaseAR;
    // Magic Res
    [Header("MR")]
    [SerializeField] float bonusMR;
    private float currentLevelBaseMR;
    private float maxMR;
    // Attack Damage
    [Header("AD")]
    [SerializeField] float bonusAD;
    private float currentLevelBaseAD;
    private float maxAD;
    // Ability Power
    [Header("AP")]
    [SerializeField] float bonusAP;
    private float currentLevelBaseAP;
    private float maxAP;
    // Attack Speed
    [Header("AS")]
    [SerializeField] float bonusAS;
    private float currentLevelBaseAS;
    private float maxAS;
    // Attack Range
    [Header("Attack Range")]
    [SerializeField] float attackRange = 0;
    // Crit Rate
    [Header("Crit Rate")]
    [SerializeField] float bonusCritRate;
    private float maxCritRate;
    // Crit Damage
    [Header("Crit Damage")]
    [SerializeField] float bonusCritDamage;
    private float maxCritDamage;
    // Melee / Ranged
    [Header("Melee / Ranged")]
    [SerializeField] bool isMelee;
    // Auto Attack Prefab
    [Header("Ranged Prefab")]
    [SerializeField] GameObject AttackProjectilePrefab;
    // Cooldown Reduction
    [Header("CD")]
    [SerializeField] float bonusCD;
    private float currentLevelBaseCD;
    private float maxCD;
    // Movement Speed
    [Header("MS")]
    [SerializeField] float bonusMS = 0;
    private float maxMS;
    // Mana
    [Header("Mana")]
    [SerializeField] float bonusMana = 0;
    private float currentLevelBaseMana = 0;
    private float maxMana;
    [SerializeField] float bonusManaRegen = 0;
    private float currentLevelBaseManaRegen = 0;
    private float maxManaRegen;
    // Energy
    [Header("Energy")]
    [SerializeField] float bonusEnergy = 0;
    private float currentLevelBaseEnergy = 0;
    private float maxEnergy;
    [SerializeField] float bonusEnergyRegen = 0;
    private float currentLevelBaseEnergyRegen = 0;
    private float maxEnergyRegen;
    // Anger
    [Header("Anger")]
    [SerializeField] float bonusAnger = 0;
    private float currentLevelBaseAnger = 0;
    private float maxAnger;
    [SerializeField] float bonusAngerRegen = 0;
    private float currentLevelBaseAngerRegen = 0;
    private float maxAngerRegen;
    // Shield
    [Header("Shield")]
    [SerializeField] float bonusShield = 0;
    private float currentLevelBaseShield = 0;
    [SerializeField] float bonusShieldRegen = 0;
    private float currentLevelBaseShieldRegen = 0;
    // Ferocity
    [Header("Ferocity")]
    [SerializeField] float bonusFerocity = 0;
    private float currentLevelBaseFerocity = 0;
    [SerializeField] float bonusFerocityRegen = 0;
    private float currentLevelBaseFerocityRegen = 0;
    // Flow
    [Header("Flow")]
    [SerializeField] float bonusFlow = 0;
    private float currentLevelBaseFlow = 0;
    [SerializeField] float bonusFlowRegen = 0;
    private float currentLevelBaseFlowRegen = 0;
    // BloodWell
    [Header("BloodWell")]
    [SerializeField] float bonusBloodWell = 0;
    private float currentLevelBaseBloodWell = 0;
    [SerializeField] float bonusBloodWellRegen = 0;
    private float currentLevelBaseBloodWellRegen = 0;
    // Frenzy
    [Header("Frenzy")]
    [SerializeField] float bonusFrenzy = 0;
    private float currentLevelBaseFrenzy = 0;
    [SerializeField] float bonusFrenzyRegen = 0;
    private float currentLevelBaseFrenzyRegen = 0;
    // Heat
    [Header("Head")]
    [SerializeField] float bonusHeat = 0;
    private float currentLevelBaseHeat = 0;
    [SerializeField] float bonusHeatRegen = 0;
    private float currentLevelBaseHeatRegen = 0;
    // Grit
    [Header("Grit")]
    [SerializeField] float bonusGrit = 0;
    private float currentLevelBaseGrit = 0;
    [SerializeField] float bonusGritRegen = 0;
    private float currentLevelBaseGritRegen = 0;
    // Style
    [Header("Style")]
    [SerializeField] float bonusStyle = 0;
    private float currentLevelBaseStyle = 0;
    [SerializeField] float bonusStyleRegen = 0;
    private float currentLevelBaseStyleRegen = 0;
    // Moonlight
    [Header("Moonlight")]
    [SerializeField] float bonusMoonlight = 0;
    private float currentLevelBaseMoonlight = 0;
    [SerializeField] float bonusMoonlightRegen = 0;
    private float currentLevelBaseMoonlightRegen = 0;
    // Ammo
    [Header("Ammo")]
    [SerializeField] float bonusAmmo = 0;
    private float currentLevelBaseAmmo = 0;
    [SerializeField] float bonusAmmoRegen = 0;
    private float currentLevelBaseAmmoRegen = 0;
    // Countdown
    [Header("CD")]
    [SerializeField] float bonusCooldown = 0;
    private float currentLevelBaseCooldown = 0;
    [SerializeField] float bonusCooldownRegen = 0;
    private float currentLevelBaseCooldownRegen = 0;
    // Step - like
    [Header("Step")]
    [SerializeField] float bonusStep = 0;
    private float currentLevelBaseStep = 0;
    [SerializeField] float bonusStepRegen = 0;
    private float currentLevelBaseStepRegen = 0;

    // --- AutoAttack Controller ---
    public AutoAttackController autoAttackController { get; private set; }

    // --- Core State Machine ---
    public CoreChampionStateMachine StateMachine { get; private set; }
    public CoreChampionStateCollection States { get; private set; }

    // --- Buff Manager ---
    public BuffManager Buffs { get; private set; }

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
    public void MaxAngerCheck()
    {
        currentLevelBaseAnger = statData.BaseAnger + statData.AngerGrowth * currentChampionLevel;
        currentLevelBaseAngerRegen = statData.BaseAngerRegen + statData.AngerRegenGrowth *currentChampionLevel;
        maxAnger = currentLevelBaseAnger + bonusAnger;
        maxAngerRegen = currentLevelBaseAngerRegen + bonusAngerRegen;
    }
    
    private void Awake()
    {
        // Buff manager
        Buffs = new BuffManager(this);

        // State machine
        StateMachine = new CoreChampionStateMachine();
        States = new CoreChampionStateCollection(GetComponent<PlayerGeneral>(), StateMachine);
        autoAttackController = new AutoAttackController(this);
    }

    private void Start()
    {
        StateMachine.Initialize(States.IDLESTATE);
    }

    private void Update()
    {
        Buffs.UpdateBuffs();
        StateMachine.state.Update();
        autoAttackController.Update();
    }

    private void FixedUpdate()
    {
        StateMachine.state.FixedUpdate();
    }

    private void LateUpdate()
    {
        StateMachine.state.LateUpdate();
    }

    // --- Combat Methods ---
    public void TakeDamage(float amount)
    {
        if (IsDead) return;

        CurrentHP -= amount;
        if (CurrentHP <= 0)
        {
            CurrentHP = 0;
            Die();
        }
    }

    public void Heal(float amount)
    {
        
    }

    private void Die()
    {
        Debug.Log($"{gameObject.name} has died.");
        StateMachine.Change(States.DEADSTATE);
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
