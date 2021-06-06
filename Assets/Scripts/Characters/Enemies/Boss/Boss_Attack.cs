using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    public class Boss_Attack : MonoBehaviour
    {
        public Settings.SO_Settings_Balance settings;

        float damage;

        float damageSpikeTime = 55f / 60f;
        float damagePeriod = 1f;

        [SerializeField] Transform maskTr;
        [SerializeField] Transform damageIndicator;

        float innerReach;
        float outerReach;
        Player_State playerSt;
        Player_MovementController playerMC;

        void Setup()
        {
            innerReach = settings.Boss_InnerReach;
            outerReach = settings.Boss_OuterReach;
            
            maskTr.localScale = innerReach * Vector3.one;
            damageIndicator.localScale = outerReach * Vector3.one;
            damage = settings.Boss_Damage;

            playerSt = EnemiesManager.GetInstance().player;
            playerMC = playerSt.gameObject.GetComponent<Player_MovementController>();

            StartCoroutine(DamageCoroutine());
        }

        float distanceToPlayer;
        float playerSphericSize = 1.3f;
        IEnumerator DamageCoroutine()
        {
            yield return new WaitForSeconds(damageSpikeTime);
            while (true)
            {
                distanceToPlayer = (transform.position - playerMC.GetCenterPoint()).magnitude;
                if (distanceToPlayer > (innerReach/2 - playerSphericSize) & distanceToPlayer <= (outerReach/2 + playerSphericSize))
                {
                    ((IHitable)playerSt).GetHit(damage);
                }
                yield return new WaitForSeconds(damagePeriod);
            }
        }

        private void Start()
        {
            Setup();
        }


    }
}
