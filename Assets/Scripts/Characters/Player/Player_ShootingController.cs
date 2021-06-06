using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooting
{
    public class Player_ShootingController : MonoBehaviour
    {
        [SerializeField] private Transform aim;
        [SerializeField] private GameObject bulletPrefab;

        [SerializeField] Settings.SO_Settings_Balance settings;
        [SerializeField] RingIndicator indicator;

        int bulletsLeft;
        int bulletsInClip;
        float reloadTime;
        
        private void Setup ()
        {
            bulletsInClip = settings.BulletsInClip;
            bulletsLeft = bulletsInClip;
            reloadTime = settings.ReloadTime;
            indicator.Setup(reloadTime);
        }

        [SerializeField] AudioSource audioSource;

        private void Shoot ()
        {
            audioSource.Play();
            Vector3 direction = aim.position - transform.position;
            Instantiate(bulletPrefab, aim.position, Quaternion.identity).
                GetComponent<Battle.Bullet>().SetVelocity(direction);
            bulletsLeft--;
            //Debug.Log(((float)bulletsLeft) / bulletsInClip);
            indicator.UpdateVisual( ((float)bulletsLeft) / bulletsInClip);
        }

        float shootingPeriod = 0.1f;
        float timeTillShotIsPossible = 0f;

        private void Start()
        {
            Setup();
        }

        private void Update()
        {
            timeTillShotIsPossible = Mathf.Max(0, timeTillShotIsPossible - Time.deltaTime);
            if (timeTillShotIsPossible>shootingPeriod)
            {
                return;
            }
            if (Input.GetButtonDown("Reload"))
            {
                if (ScoreNBulletManager.GetInstance().Reload())
                {
                    timeTillShotIsPossible = reloadTime;
                    indicator.ReloadAnimation();
                    bulletsLeft = bulletsInClip;
                }
            }
            else if (Input.GetButton("Fire1"))
            {
                if (timeTillShotIsPossible == 0 & bulletsLeft > 0)
                {
                    Shoot();
                    timeTillShotIsPossible = shootingPeriod;
                }
            }
        }

        public void TurnOff ()
        {
            this.enabled = false;
        }
    }
}
