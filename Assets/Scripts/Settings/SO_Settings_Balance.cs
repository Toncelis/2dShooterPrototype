using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Settings
{

    [CreateAssetMenu(fileName = "BalanceSettings", menuName = "SO/Settings/Balance", order = 1)]
    public class SO_Settings_Balance : ScriptableObject
    {
        #region Inspector Setup
        [Header("Wave Settings")]
            [Tooltip("Amount of first tier mobs in Wave 1")]
            [Min(0)]
            [SerializeField] int T;

            [Tooltip("Amount of first tier mobs in Wave 2")]
            [Min(0)]
            [SerializeField] int U;

            [Tooltip("Amount of second tier mobs in Wave 2")]
            [Min(0)]
            [SerializeField] int Z;

        #region Mob&Boss Settings
        [Header("Mob Settings")]
            [Tooltip("Size of first tier mob")]
            [Min(0.01f)]
            [SerializeField] float N1;

            [Tooltip("Speed of first tier mob")]
            [Min(0.01f)]
            [SerializeField] float M1;

            [Tooltip("Damage of first tier mob")]
            [Min(0.01f)]
            [SerializeField] float K1;

            [Tooltip("Damage reach of first tier mob")]
            [Min(0.01f)]
            [SerializeField] float L1;

            [Tooltip("Health of first tier mob")]
            [Min(1f)]
            [SerializeField] float O1;

            [Min(0)]
            [SerializeField] int mob1_ScorePrice;

        [Space(5)]

            [Tooltip("Size of second tier mob")]
            [Min(0.01f)]
            [SerializeField] float N2;

            [Tooltip("Speed of second tier mob")]
            [Min(0.01f)]
            [SerializeField] float M2;

            [Tooltip("Damage of second tier mob")]
            [Min(0.01f)]
            [SerializeField] float K2;

            [Tooltip("Damage reach of second tier mob")]
            [Min(0.01f)]
            [SerializeField] float L2;

            [Tooltip("Health of second tier mob")]
            [Min(1f)]
            [SerializeField] float O2;

            [Min(0)]
            [SerializeField] int mob2_ScorePrice;

        [Header("Boss Settings")]

            [Tooltip("Size of boss")]
            [Min(0.01f)]
            [SerializeField] float N3;

            [Tooltip("Speed of boss")]
            [Min(0.01f)]
            [SerializeField] float M3;

            [Tooltip("Damage of boss")]
            [Min(0.01f)]
            [SerializeField] float K3;

            [Tooltip("Inner reach of boss attack")]
            [Min(0.01f)]
            [SerializeField] float L3_1;

            [Tooltip("Outer reach of boss attack")]
            [Min(0.01f)]
            [SerializeField] float L3_2;

            [Tooltip("Boss health")]
            [Min(0.01f)]
            [SerializeField] float O3;
        #endregion

        [Header("Player Settings")]

            [Min(0)]
            [SerializeField] float playerSpeed;

            [Min(1)]
            [SerializeField] float playerDamage;

            [Min(0)]
            [SerializeField] float bulletSpeed;

            [Min(0.1f)]
            [SerializeField] float reloadTime;

            [Min(1)]
            [SerializeField] float playerHealth;

        [Header("Bullets Settings")]

            [Min(1)]
            [SerializeField] float salesPeriod;

            [Min(1)]
            [SerializeField] int reloadsPerSale;

            [Min(1)]
            [SerializeField] int bulletsInClip;

            [Min(0)]
            [SerializeField] int reloadsCost;

            [Min(0)]
            [SerializeField] int reloadsOnStart;
            //[SerializeField] bool losingBulletsOnReload;
        #endregion

        #region Access methods
        public int Wave1_Mob1_Amount => T;
        public int Wave2_Mob1_Amount => U;
        public int Wave2_Mob2_Amount => Z;

        private float Mob1_Size => N1;
        private float Mob1_Speed => M1;
        private float Mob1_Damage => K1;
        private float Mob1_Reach => L1;
        private float Mob1_Health => O1;
        private int Mob1_ScorePrice => mob1_ScorePrice;

        private float Mob2_Size => N2;
        private float Mob2_Speed => M2;
        private float Mob2_Damage => K2;
        private float Mob2_Reach => L2;
        private float Mob2_Health => O2;
        private int Mob2_ScorePrice => mob2_ScorePrice;

        public List<float> MobSize => new List<float> { Mob1_Size, Mob2_Size };
        public List<float> MobSpeed => new List<float> { Mob1_Speed, Mob2_Speed };
        public List<float> MobDamage => new List<float> { Mob1_Damage, Mob2_Damage };
        public List<float> MobReach => new List<float> { Mob1_Reach, Mob2_Reach };
        public List<float> MobHealth => new List<float> { Mob1_Health, Mob2_Health };

        public List<int> MobPrice => new List<int> { Mob1_ScorePrice, Mob2_ScorePrice };

        public float Boss_Size => N3;
        public float Boss_Speed => M3;
        public float Boss_Damage => K3;
        public float Boss_InnerReach => L3_1;
        public float Boss_OuterReach => L3_2;
        public float Boss_Health => O3;

        public float PlayerSpeed => playerSpeed;
        public float PlayerDamage => playerDamage;
        public float BulletSpeed => bulletSpeed;
        public float ReloadTime => reloadTime;
        public float PlayerHealth => playerHealth;

        public float SalesPeriod => salesPeriod;
        public int ReloadsPerSale => reloadsPerSale;
        public int BulletsInClip => bulletsInClip;
        public int ReloadsCost => reloadsCost;
        public int ReloadsOnStart => reloadsOnStart;
        //public bool LosingBulletsOnReload => losingBulletsOnReload;
        #endregion
    }
}