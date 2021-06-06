using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    public class BossState : MonoBehaviour, IHitable
    {
        public Settings.SO_Settings_Balance settings;
        [SerializeField] private Animator myAnimator;

        private CharacterType myType = CharacterType.Boss;
        private float hp;

        void Setup()
        {
            hp = settings.Boss_Health;
        }

        private void Start()
        {
            Setup();
        }

        void IHitable.GetHit(float damage)
        {
            hp -= damage;
            if (hp <= 0)
            {
                hp = 0;
                Die();
            }
            else
            {
                //myAnimator.SetTrigger("GotHit");
            }
        }

        bool IHitable.CompareType(CharacterType comparedType)
        {
            if (comparedType == myType)
            {
                return true;
            }
            return false;
        }

        [SerializeField] GameObject body;
        [SerializeField] GameObject damageIndicator;
        [SerializeField] private GameObject deathVisualisation;
        void Die()
        {
            body.SetActive(false);
            damageIndicator.SetActive(false);
            deathVisualisation.SetActive(true);
            //LevelManager.GetInstance().WinLvl();
        }

        public void OnParticleSystemStopped()
        {
            Destroy(gameObject);
        }
    }
}
