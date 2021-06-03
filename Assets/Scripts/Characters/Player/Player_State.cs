using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    [RequireComponent(typeof(Animator))]
    public class Player_State : MonoBehaviour, IHitable
    {
        [SerializeField] Settings.SO_Settings_Balance settings;

        private CharacterType myType = CharacterType.Player;
        private float hp;
        private Animator myAnimator;

        private void Setup()
        {
            hp = settings.PlayerHealth;
        }

        private void Start()
        {
            Setup();
            myAnimator = GetComponent<Animator>();
        }

        [SerializeField] Events.SO_Event PlayerDeath;
        void Die()
        {
            PlayerDeath.Raise();
            myAnimator.SetTrigger("Died");
        }
        
        void IHitable.GetHit(float damage)
        {
            hp -= damage;
            if (hp<=0)
            {
                hp = 0;
                Die();
            }
            else
            {
                myAnimator.SetTrigger("GotHit");
            }
        }

        bool IHitable.CompareType(CharacterType type)
        {
            if (type == myType)
            {
                return true;
            }
            return false;
        }
    }
}
