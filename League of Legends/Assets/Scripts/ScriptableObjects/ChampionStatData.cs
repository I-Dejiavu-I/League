using UnityEngine;

[CreateAssetMenu(fileName = "ChampionStatData", menuName = "Champion/StatData")]
public class ChampionStatData : ScriptableObject
{
    // --- HP ---
    [Header("HP")]
    public float BaseHP; // Level 1
    public float HPGrowth;
    public float BaseHPRegen; // Level 1
    public float HPRegenGrowth;

    // --- Armor ---
    [Header("Armor")]
    public float BaseAR; // Level 1
    public float ARGrowth;

    // --- Magic Resistance ---
    [Header("Magic Resistance")]
    public float BaseMR; // Level 1
    public float MRGrowth;

    // --- Movement Speed ---
    [Header("Movement Speed")]
    public float BaseMS; // Level 1

    // --- Critical ---
    [Header("Critical")]
    public float BaseCritRate;
    public float BaseCritDamage;
    public float CritRateCap; // max 100%

    // --- Attack Power ---
    [Header("AP")]
    public float BaseAP;
    public float APGrowth;

    // --- Attack Damage --
    [Header("Attack Damage")]
    public float BaseAD; // Level 1
    public float ADGrowth;

    // --- Attack Speed ---
    [Header("Attack Speed")]
    public float BaseAS; // Level 1
    public float ASGrowth;
    public float ASCap;

    // --- Cooldown Reduction ---
    [Header("CD")]
    public float baseCD;
    public float CDGrowth;

    // --- Mana ---
    [Header("Mana")]
    public float BaseMana; // Level 1
    public float ManaGrowth;
    public float BaseManaRegen; // Level 1
    public float ManaRegenGrowth;

    // --- Energy ---
    [Header("Energy")]
    public float BaseEnergy; // Level 1
    public float EnergyGrowth;
    public float BaseEnergyRegen; // Level 1
    public float EnergyRegenGrowth;

    // --- Fury ---
    [Header("Fury")]
    public float BaseFury; // Level 1
    public float FuryGrowth;
    public float BaseFuryRegen; // Level 1
    public float FuryRegenGrowth;

    // --- Anger ---
    [Header("Anger")]
    public float BaseAnger; // Level 1
    public float AngerGrowth;
    public float BaseAngerRegen; // Level 1
    public float AngerRegenGrowth;

    // --- Shield ---
    [Header("Shield")]
    public float BaseShield; // Level 1
    public float ShieldGrowth;
    public float BaseShieldRegen;
    public float tShieldGrowth;

    // --- Ferocity ---
    [Header("Ferocity")]
    public float BaseFerocity; // Level 1
    public float FerocityGrowth;
    public float BaseFerocityRegen;
    public float FerocityRegenGrowth;

    // --- Flow ---
    [Header("Flow")]
    public float BaseFlow; // Level 1
    public float FlowGrowth;
    public float BaseFlowRegen; // Level 1
    public float FlowRegenGrowth;

    // --- Blood Well ---
    [Header("Blood Well")]
    public float BaseBloodWell; // Level 1
    public float BloodWellGrowth;
    public float BaseBloodWellRegen; // Level 1
    public float BloodWellRegenGrowth;

    // --- Frenzy ---
    [Header("Frenzy")]
    public float Basefrenzy; // Level 1
    public float FrenzyGrowth;
    public float BaseFrenzyRegen; // Level 1
    public float FrenzyRegenGrowth;

    // --- Heat ---
    [Header("Heat")]
    public float BaseHeat; // Level 1
    public float HeatGrowth;
    public float BaseHeatRegen; // Level 1
    public float HeatRegenGrowth;

    // --- Grit ---
    [Header("Grit")]
    public float BaseGrit; // Level 1
    public float GritGrowth;
    public float BaseGritRegen; // Level 1
    public float GritRegenGrowth;

    // --- Style ---
    [Header("Style")]
    public float BaseStyle; // Level 1
    public float StyleGrowth;
    public float BaseStyleRegen; // Level 1
    public float StyleRegenGrowth;

    // --- MoonLight ---
    [Header("MoonLight")]
    public float baseMoonLight; // Level 1
    public float MoonLightGrowth;
    public float BaseMoonLightRegen; // Level 1
    public float MoonLightRegenGrowth;

    // --- Ammo ---
    [Header("Ammo")]
    public float BaseAmmo; // Level 1
    public float AmmoGrowth;
    public float BaseAmmoRegen; // Level 1
    public float AmmoRegenGrowth;

    // --- Countdown ---
    [Header("Countdown")]
    public float BaseCountdown; // Level 1
    public float CountDownGrowth;
    public float BaseCountdownRegen; // Level 1
    public float CountdownRegenGrowth;

    // --- Step-Like ---
    [Header("Step-Like")]
    public float BaseStep; // Level 1
    public float StepGrowth;
    public float BaseStepRegen; // Level 1
    public float StepRegenGrowth;

    // --- Prefabs ---
    [Header("Prefabs")]
    [SerializeField] GameObject Prefab;
}
