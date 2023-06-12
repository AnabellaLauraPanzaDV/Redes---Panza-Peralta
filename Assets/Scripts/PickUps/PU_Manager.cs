using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class PU_Manager : MonoBehaviour
{
    [SerializeField] PU_Star starPrefab;
    [SerializeField] GameObject[] spawnPositions;
    [SerializeField] float timeToSpawn;

    PU_Star currentStar;
    float timer;
    int currentSpawnIndex;

    private void Update()
    {
        if(currentStar == null)
        {
            timer += Time.fixedDeltaTime;

            if (timer >= timeToSpawn)
            {
                timer = 0;
                SpawnStar(SetSpawnPos());
            }
        }        
    }

    GameObject SetSpawnPos()
    {
        if (currentSpawnIndex > spawnPositions.Length-1) currentSpawnIndex = 0;
        GameObject current = spawnPositions[currentSpawnIndex];
        currentSpawnIndex++;        
        return current;
    }

    public void SpawnStar(GameObject spawnGO)
    {
        currentStar = Instantiate(starPrefab);
        currentStar.transform.position = spawnGO.transform.position;
    }

}
