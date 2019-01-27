using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnersControllers : MonoBehaviour
{
    public List<MonsterSpawner> spawners;

    [Range (0,100)]
    public List<int> chanceToSpawn;

    public float timeBetween;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SortSpawners());
    }

    IEnumerator SortSpawners()
    {
        List<MonsterSpawner> spawnersList = spawners.GetRange(0, spawners.Count);
        yield return new WaitForSeconds(timeBetween);

        for (int i = 0; i < chanceToSpawn.Count; i++)
        {
            int aux = Random.Range(0, 100);

            if(aux <= chanceToSpawn[i])
            {
                int spawnIndex = Random.Range(0, spawnersList.Count);
                spawnersList[spawnIndex].Spawn();
                spawnersList.RemoveAt(spawnIndex);
            }
        }

        StartCoroutine(SortSpawners());
        
    }
}
