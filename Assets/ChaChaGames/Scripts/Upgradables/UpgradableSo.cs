using System;
using Bayat.SaveSystem;
using nyy.System_Extensions.Odin;
using Sirenix.OdinInspector;
using Sirenix.Utilities.Editor;
using UnityEngine;
using UnityEngine.Serialization;

namespace ChaChaGames.Scripts.Upgradables
{
    [CreateAssetMenu(fileName = "New Upgradable", menuName = "Create Upgradable", order = 0)]
    public class UpgradableSo : ScriptableObject
    {
        [ColoredGroup("Save",.1f,.5f,1f)]
        [Required] public string SaveKey;
        
        [ColoredGroup("Stats", .1f, 1f, .1f)][ShowInInspector][Indent(2)]
        public int CurrentLevel
        {
            get => _levelBase;
            set
            {
                if (_levelBase == 0) _levelBase = 1;
                _levelBase = value;
                
                if (IncreaseType == IncreaseTypee.Incremental)
                    _sum = BaseCost += IncrementalCost;

                if (IncreaseType == IncreaseTypee.Exponential)
                    _sum = (int)Mathf.Pow(BaseCost, CostsExponential[CurrentLevel]);
            }
        }
        [ColoredGroup("Stats", .1f, 1f, .1f)] [ShowInInspector]
        private int _levelBase = 1;

        [ColoredGroup("Stats", .1f, 1f, .1f)][ShowInInspector]
        public int BaseCost
        {
            get;
            set;
        }

        private float _sum;
        [ColoredGroup("Stats",.1f,1f,.1f)]
        [ShowInInspector] public float Cost
        {
            get
            {
                if (IsMaxedOut == false)
                {
                    if (IncreaseType == IncreaseTypee.Incremental)
                        return BaseCost + IncrementalCost;

                    if (IncreaseType == IncreaseTypee.Exponential)
                        return Mathf.RoundToInt(Mathf.Pow(BaseCost,CostsExponential[CurrentLevel]));
                }
                
                return _sum;
            }
            
            set => _sum = value;
        }
        
        [ColoredGroup("Constraints", 1f, .5f, .2f)][ShowInInspector]
        private int _maxUpgradedLevelBase;
        [ColoredGroup("Constraints", 1f, .5f, .2f)][ShowInInspector][Indent(2)]
        public int MaxUpgradeLevel
        {
            get => _maxUpgradedLevelBase;
            set
            {
                _maxUpgradedLevelBase = value;
                
                CostsExponential = new float[MaxUpgradeLevel];
                
                UpgradeAmountsExponential = new float[MaxUpgradeLevel];
            }   
        }
        [ColoredGroup("Constraints",1f,.5f,.2f)]
        [ReadOnly, ShowInInspector] public bool IsMaxedOut => CurrentLevel == MaxUpgradeLevel;
        
        [ColoredGroup("Process",1f,.5f,1f)]
        public IncreaseTypee IncreaseType;
        [ColoredGroup("Process",1f,.5f,1f)][Indent(3)][ShowIf("@this.IncreaseType == IncreaseTypee.Incremental")]
        public int UpgradeAmount;

        [ColoredGroup("Process", 1f, .5f, 1f)] [Indent(3)] [ShowIf("@this.IncreaseType == IncreaseTypee.Incremental")]
        public int IncrementalCost;

        [FormerlySerializedAs("IncrementalCostsExponential")] [ColoredGroup("Process", 1f, .5f, 1f)] [Indent(3)] [ShowIf("@this.IncreaseType == IncreaseTypee.Exponential")]
        public float[] CostsExponential = new float[1];
        [ColoredGroup("Process",1f,.5f,1f)][Indent(3)][ShowIf("@this.IncreaseType == IncreaseTypee.Exponential")]
        public float[] UpgradeAmountsExponential = new float[1];

        [ColoredGroup("Progress",1f,.7f,.1f),ShowInInspector]
        private int _baseValue;
        [ColoredGroup("Progress",1f,.7f,.1f)]
        [ReadOnly, ShowInInspector][Indent(2)] public int CurrentValue
        {
            get
            {
                if (IncreaseType == IncreaseTypee.Incremental)
                    return UpgradeAmount * CurrentLevel;

                if (IncreaseType == IncreaseTypee.Exponential)
                    return (int)Mathf.Pow(_baseValue, UpgradeAmountsExponential[CurrentLevel]);

                return 0;
            }
        }

        public void Upgrade()
        {
            if (IsMaxedOut)
                return;
            CurrentLevel++;
        }

        public void Save()
        {
            SaveSystemAPI.SaveAsync(SaveKey, CurrentLevel);
        }

        public void Load()
        {
            CurrentLevel = SaveSystemAPI.LoadAsync<int>(SaveKey).Result;
        }
    }

    [Serializable][EnumToggleButtons]
    public enum IncreaseTypee
    {
        Incremental,
        Exponential
    }
}