using UnityEngine;

[CreateAssetMenu(fileName = "ChampionStatData", menuName = "Champion/StatData")]
public class ChampionStatData : ScriptableObject
{
    // --- HP ---
    [Header("HP")]
    public float BaseHP; // Level 1
    public float HPGrowth;
    public float BaseHPRegen; // Level 1
    public float CurrentHPRegen;
    public float CurrentHP;

    // --- Armor ---
    [Header("Armor")]
    public float BaseAR; // Level 1
    public float ARGrowth;
    public float CurrentAR;

    // --- Magic Resistance ---
    [Header("Magic Resistance")]
    public float BaseMR; // Level 1
    public float MRGrowth;
    public float CurrentMR;

    // --- Movement Speed ---
    [Header("Movement Speed")]
    public float BaseMS; // Level 1
    public float CurrentMS;

    // --- Critical ---
    [Header("Critical")]
    public float CritRate;
    public float CritDamage;
    public float CritRateCap; // max 100%

    // --- Attack Damage --
    [Header("Attack Damage")]
    public float BaseAD; // Level 1
    public float ADGrowth;
    public float CurrentAD;

    // --- Attack Speed ---
    [Header("Attack Speed")]
    public float BaseAS; // Level 1
    public float ASGrowth;
    public float ASCap;

    // --- Mana ---
    [Header("Mana")]
    public float BaseMana; // Level 1
    public float ManaGrowth;
    public float BaseManaRegen; // Level 1
    public float CurrentManaRegen;
    public float CurrentMana;

    // --- Energy ---
    [Header("Energy")]
    public float BaseEnergy; // Level 1
    public float EnergyGrowth;
    public float BaseEnergyRegen; // Level 1
    public float CurrentEnergyRegen;
    public float CurrentEnergy;

    // --- Fury ---
    [Header("Fury")]
    public float BaseFury; // Level 1
    public float FuryGrowth;
    public float BaseFuryRegen; // Level 1
    public float CurrentFuryRegen;
    public float CurrentFury;

    // --- Anger ---
    [Header("Anger")]
    public float BaseAnger; // Level 1
    public float AngerGrowth;
    public float BaseAngerRegen; // Level 1
    public float CurrentAngerRegen;
    public float CurrentAnger;

    // --- Shield ---
    [Header("Shield")]
    public float BaseShield; // Level 1
    public float ShieldGrowth;
    public float BaseShieldRegen;
    public float CurrentShield;

    // --- Ferocity ---
    [Header("Ferocity")]
    public float BaseFerocity; // Level 1
    public float FerocityGrowth;
    public float BaseFerocityRegen;
    public float CurrentFerocity;
    public float MaxFerocity;

    // --- Flow ---
    [Header("Flow")]
    public float BaseFlow; // Level 1
    public float FlowGrowth;
    public float BaseFlowRegen; // Level 1
    public float CurrentFlowRegen;
    public float CurrentFlow;

    // --- Blood Well ---
    [Header("Blood Well")]
    public float BaseBloodWell; // Level 1
    public float BloodWellGrowth;
    public float BaseBloodWellRegen; // Level 1
    public float MaxBloodWell;

    // --- Frenzy ---
    [Header("Frenzy")]
    public float Basefrenzy; // Level 1
    public float FrenzyGrowth;
    public float BaseFrenzyRegen; // Level 1
    public float MaxFrenzy;

    // --- Heat ---
    [Header("Heat")]
    public float BaseHeat; // Level 1
    public float HeatGrowth;
    public float BaseHeatRegen; // Level 1
    public float MaxHeat;

    // --- Grit ---
    [Header("Grit")]
    public float BaseGrit; // Level 1
    public float GritGrowth;
    public float BaseGritRegen; // Level 1
    public float MaxGrit;

    // --- Style ---
    [Header("Style")]
    public float BaseStyle; // Level 1
    public float StyleGrowth;
    public float BaseStyleRegen; // Level 1
    public float MaxStyle;

    // --- MoonLight ---
    [Header("MoonLight")]
    public float baseMoonLight; // Level 1
    public float MoonLightGrowth;
    public float BaseMoonLightRegen; // Level 1
    public float MaxMoonLight;

    // --- Ammo ---
    [Header("Ammo")]
    public float BaseAmmo; // Level 1
    public float AmmoGrowth;
    public float BaseAmmoRegen; // Level 1
    public float MaxAmmo;

    // --- Countdown ---
    [Header("Countdown")]
    public float BaseCountdown; // Level 1
    public float CountDownGrowth;
    public float BaseCountdownRegen; // Level 1
    public float CurrentCountdown;

    // --- Step-Like ---
    [Header("Step-Like")]
    public float BaseStep; // Level 1
    public float StepGrowth;
    public float BaseStepRegen; // Level 1
    public float MaxStep;

    // --- Prefabs ---
    [Header("Prefabs")]
    [SerializeField] GameObject Prefab;
}
