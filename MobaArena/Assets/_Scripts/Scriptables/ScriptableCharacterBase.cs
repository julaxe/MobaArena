using System;
using UnityEngine;

namespace _Scripts.Scriptables
{
    [CreateAssetMenu(menuName = "CharacterBase")]
    public class ScriptableCharacterBase : ScriptableObject {

        [SerializeField] private Stats _stats;
        public Stats BaseStats => _stats;

        // Used in menus
        public string Description;
        public Sprite MenuSprite;
    }
    
    [Serializable]
    public struct Stats
    {
        public OffensiveStats offensiveStats;
        public DefensiveStats defensiveStats;
        public UtilityStats utilityStats;
        public OtherStats otherStats;
    }

    [Serializable]
    public struct OffensiveStats
    {
        public float attackDamage;
        public float attackDamagePerLevel;
        public float attackSpeed;
        public float attackSpeedRatio;
        public float attackWindup;
        public float critDamage;
        public float critStrikeChance;
        [NonSerialized] public float abilityPower;
        [NonSerialized] public float magicPenetration;
        [NonSerialized] public float armorPenetration;
        [NonSerialized] public float missileSpeed;
        [NonSerialized] public float lifeSteal;
        [NonSerialized] public float omnivamp;
    }
    
    [Serializable]
    public struct DefensiveStats
    {
        public float armor;
        public float armorPerLevel;
        public float magicResist;
        public float magicResistPerLevel;
        public float health;
        public float healthPerLevel;
        public float healthRegen;
        public float healthRegenPerLevel;
        [NonSerialized] public float tenacity;
        [NonSerialized] public float slowResist;
        [NonSerialized] public float healAndShieldPower;
    }

    [Serializable]
    public struct UtilityStats
    {
        public float energy;
        public float energyRegen;
        public float mana;
        public float manaPerLevel;
        public float manaRegen;
        public float manaRegenPerLevel;
        public float abilityHaste;
    }

    [Serializable]
    public struct OtherStats
    {
        public float movementSpeed;
        public float range;
        public float gameplayRadius;
        public float selectionRadius;
        public float pathingRadius;
        public float acquisitionRadius;
        [NonSerialized] public float experience;
        [NonSerialized] public float experienceNeededToLevelUp;
        [NonSerialized] public float goldGeneration;
    }
}