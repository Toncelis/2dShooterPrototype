using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    public class Mob_Attack : MonoBehaviour
    {
        public Settings.SO_Settings_Balance settings;
        public MobType mobVariant;

        float size;
        float damage;

        float damageSpikeTime = 55f/60f;
        float damagePeriod = 1f;

        void Setup ()
        {
            size = settings.MobReach[(int)mobVariant];
            transform.localScale = Vector3.one * size;
            damage = settings.MobDamage[(int)mobVariant];

            StartCoroutine(DamageCoroutine());
        }

        IEnumerator DamageCoroutine ()
        {
            yield return new WaitForSeconds(damageSpikeTime);
            while (true)
            {
                foreach (Collider2D collider in Physics2D.OverlapCircleAll(transform.position, size/2))
                {
                    IHitable hit = collider.GetComponent<IHitable>();
                    if (hit!=null)
                    {
                        if (hit.CompareType(CharacterType.Player))
                        {
                            hit.GetHit(damage);
                        }
                    }
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
