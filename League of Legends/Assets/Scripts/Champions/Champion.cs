using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Champion : MonoBehaviour
{
    [Header("Champion Data")]
    [SerializeField] private ChampionStatData statData;

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

    // --- Max Values ---
    public float MaxHP => statData.CurrentHP;
    public float MaxMana => statData.CurrentMana;
    public float MaxEnergy => statData.CurrentEnergy;
    public float MaxFury => statData.CurrentFury;
    public float MaxShield => statData.CurrentShield;
    public float MaxFerocity => statData.MaxFerocity;
    public float MaxFlow => statData.CurrentFlow;
    public float MaxBloodWell => statData.MaxBloodWell;
    public float MaxFrenzy => statData.MaxFrenzy;
    public float MaxHeat => statData.MaxHeat;
    public float MaxStyle => statData.BaseStyle;
    public float MaxMoonlight => statData.baseMoonLight;
    public float MaxAmmo => statData.BaseAmmo;
    public float MaxCountdown => statData.BaseCountdown;
    public float MaxStep => statData.BaseStep;

    // --- Champion State ---
    public bool IsDead => CurrentHP <= 0;

    private void Awake()
    {
        // Initialize resources
        CurrentHP = MaxHP;
        CurrentMana = MaxMana;
        CurrentEnergy = MaxEnergy;
        CurrentFury = 0;
        CurrentShield = 0;
        CurrentFerocity = 0;
        CurrentFlow = 0;
        CurrentBloodWell = 0;
        CurrentFrenzy = 0;
        CurrentHeat = 0;
        CurrentStyle = 0;
        CurrentMoonlight = MaxMoonlight;
        CurrentAmmo = MaxAmmo;
        CurrentCountdown = 0;
        CurrentStep = 0;

        // Buff manager
        Buffs = new BuffManager(this);

        // State machine
        StateMachine = new CoreChampionStateMachine();
        States = new CoreChampionStateCollection(GetComponent<PlayerGeneral>(), StateMachine);
    }

    private void Start()
    {
        StateMachine.Initialize(States.IDLESTATE);
    }

    private void Update()
    {
        Buffs.UpdateBuffs();

        // --- Frenzy Decay ---
        if (CurrentFrenzy > 0)
        {
            // decay logic handled elsewhere
        }

        // --- Auto death transition ---
        if (IsDead && !(StateMachine.state is StateDead))
        {
            StateMachine.Change(States.DEADSTATE);
        }

        StateMachine.state.Update();
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
        if (IsDead) return;

        CurrentHP += amount;
        if (CurrentHP > MaxHP) CurrentHP = MaxHP;
    }

    private void Die()
    {
        Debug.Log($"{gameObject.name} has died.");
        StateMachine.Change(States.DEADSTATE);
    }

    public bool HasEnoughResource(ResourceType resourceType, float cost)
    {
        switch (resourceType)
        {
            case ResourceType.None:
                return true;
            
            case ResourceType.Mana:
                return CurrentMana >= cost;
            
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
    }

    public void SpendResource(ResourceType resourceType, float cost)
    {
        switch (resourceType)
        {
            case ResourceType.None: 
                break;
            
            case ResourceType.Mana: 
                CurrentMana -= cost; 
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
    }

    // --- Frenzy Gain (Briar autos) ---
    public void GainFrenzy(float amount)
    {
        CurrentFrenzy += amount;
        if (CurrentFrenzy > MaxFrenzy) CurrentFrenzy = MaxFrenzy;
    }

    // --- Custom Resource Hooks ---
    public virtual bool HasCustomResource(float cost) => true;
    public virtual void SpendCustomResource(float cost) { }
}
