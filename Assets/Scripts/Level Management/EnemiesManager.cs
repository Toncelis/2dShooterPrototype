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

    [SerializeField] public Settings.SO_Settings_Balance settings;

    [SerializeField] public Battle.Player_State player;


    [SerializeField] List<EnemySpawner> spawners;

    [SerializeField] GameObject mobCreation1;
    [SerializeField] GameObject mobCreation2;

    void Spawn (GameObject obj)
    {
        int i = Random.Range(0, spawners.Count);
        while (!spawners[i].CanSpawn())
        {
            i++;
            i = i % spawners.Count;
        }
        spawners[i].SpawnMob(obj);
    }

    private float timebreakBetweenWaves = 3f;

    IEnumerator SpawnCoroutine ()
    {
        yield return new WaitForSeconds(1f);
        
        MobWave mobWave1 = new MobWave(1, new List<GameObject>() { mobCreation1 }, new List<int>() { settings.Wave1_Mob1_Amount });
        MobWave mobWave2 = new MobWave(2, new List<GameObject>() { mobCreation1, mobCreation2 }, 
            new List<int>() { settings.Wave2_Mob1_Amount, settings.Wave2_Mob2_Amount });
        
        while (mobWave1.CalculateAmountToSpawn()>0)
        {
            Spawn(mobWave1.SpawnRandomMob());
            yield return new WaitForSeconds(1f);
        }
        
        yield return new WaitForSeconds(timebreakBetweenWaves);
        
        while (mobWave2.CalculateAmountToSpawn() > 0)
        {
            Spawn(mobWave2.SpawnRandomMob()); 
            yield return new WaitForSeconds(1f);
        }

        yield return new WaitForSeconds(timebreakBetweenWaves);

        //SpawnBoss();

        yield return null;
    }

    private void Start()
    {
        StartCoroutine(SpawnCoroutine());
    }
}

public class MobWave
{
    int mobTypesAmount;

    private GameObject[] mobCreations;
    private int[] mobAmounts;

    public MobWave(int typesAmount, List<GameObject> types, List<int> amounts)
    {
        if (types.Count != typesAmount)
        {
            Debug.LogError($"Wave creation: invalid count of mob types ({typesAmount} {types.Count})");
            return;
        }
        if (amounts.Count != typesAmount)
        {
            Debug.LogError($"Wave creation: invalid count of mob amounts({typesAmount} {amounts.Count})");
            return;
        }

        mobTypesAmount = typesAmount;
        mobCreations = types.ToArray();
        mobAmounts = amounts.ToArray();
    }

    public int CalculateAmountToSpawn ()
    {
        int result = 0;
        foreach (int i in mobAmounts)
        {
            result += i;
        }
        return result;
    }

    public GameObject SpawnRandomMob ()
    {
        // if (CalculateAmountsToSpawn() == 0) { return null; }
        int i = Random.Range(0, mobTypesAmount);
        while (mobAmounts[i]==0)
        {
            i = (i + 1) % mobTypesAmount;
        }

        mobAmounts[i]--;
        return mobCreations[i];
    }
}
