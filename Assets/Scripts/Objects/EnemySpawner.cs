using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float cooldownTime;
    [SerializeField] int maxSpawns;

    private int availableSpawns;
    private bool spawnIsOnCooldown;

    private void Start()
    {
        availableSpawns = maxSpawns;
        spawnIsOnCooldown = false;
    }

    public bool CanSpawn ()
    {
        return (availableSpawns > 0 & !spawnIsOnCooldown);
    }

    private void ResetSpawn()
    {
        spawnIsOnCooldown = false;
    }

    public void SpawnMob (GameObject mob)
    {
        Instantiate(mob, transform.position, Quaternion.identity);
        availableSpawns--;
        spawnIsOnCooldown = true;
        Invoke("ResetSpawn", cooldownTime);
    }
}
