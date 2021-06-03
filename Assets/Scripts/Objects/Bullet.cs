using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : MonoBehaviour
    {
        [SerializeField] Rigidbody2D myRb;
        [SerializeField] Settings.SO_Settings_Balance settings;
        private float speed;
        private float damage;

        private CharacterType[] hitableTypes = new CharacterType[2] { CharacterType.Boss, CharacterType.Mob };

        private void Setup()
        {
            speed = settings.BulletSpeed;
            damage = settings.PlayerDamage;
        }

        public void SetVelocity(Vector2 direction)
        {
            Setup();
         
            if (direction.magnitude == 0)
            {
                Debug.LogError("Aim point moved to the player's center");
                return;
            }

            myRb.velocity = direction.normalized * speed;
            transform.up = direction.normalized;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            IHitable target = collision.GetComponentInParent<IHitable>();
            if (target!=null)
            {
                foreach (CharacterType type in hitableTypes)
                {
                    if (target.CompareType(type))
                    {
                        target.GetHit(damage);
                        break;
                    }
                }
            }
            Destroy(gameObject);
        }
    }
}
