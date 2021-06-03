using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    private static EnemiesManager _instance = null;

    private void Awake()
    {
        if (GetInstance()==null)
            _instance = this;
    }

    public static EnemiesManager GetInstance()
    {
        return _instance;
    }

    [SerializeField] public Battle.Player_State player;


    [SerializeField] List<Transform> spawnPoints;

    [SerializeField] GameObject mobCreation;
    void Spawn (Vector3 position)
    {
        Instantiate(mobCreation, position, Quaternion.identity);
    }

    IEnumerator SpawnCoroutine ()
    {
        yield return new WaitForSeconds(1f); 
        foreach (Transform tr in spawnPoints)
        {
            Spawn(tr.position);
        }

        int i = 0;

        while (true)
        {
            if (i==spawnPoints.Count)
            {
                i = 0;
            }
            Spawn(spawnPoints[i].position);
            i++;
            yield return new WaitForSeconds(2f);
        }
    }

    private void Start()
    {
        StartCoroutine(SpawnCoroutine());
    }
}
