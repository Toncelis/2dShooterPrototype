using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Boss_MovementController : MonoBehaviour
    {
        public Settings.SO_Settings_Balance settings;
        [SerializeField] Rigidbody2D myRb;
        [SerializeField] Transform body;

        float speed;
        float size;

        Transform playerTransform;

        private void Start()
        {
            speed = settings.Boss_Speed;
            size = settings.Boss_Size;
            playerTransform = EnemiesManager.GetInstance().player.transform;

            body.localScale = Vector3.one * size;
        }

        private void Update()
        {
            myRb.velocity = (playerTransform.position - transform.position).normalized * speed;
        }

    }
}
