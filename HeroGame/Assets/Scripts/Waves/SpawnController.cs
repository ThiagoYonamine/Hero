using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] List<WaveConfiguration> waves;
    [SerializeField] List<Transform> spawnPoints;

    int currentWaveIndex;

    private void Start()
    {
        currentWaveIndex = 0;
        StartCoroutine(StartWave());
    }

    IEnumerator StartWave()
    {
        foreach (var wave in waves)
        {
            Debug.Log("StartWave " + wave);
            yield return StartCoroutine(SpawnEnemy(wave));
        }

        Debug.Log("Spawner FINISHED ");
    }

    IEnumerator SpawnEnemy(WaveConfiguration wave)
    {
        foreach (var spawn in wave.Spawns)
        {
            for(int i=0; i<spawn.amount; i++)
            {
                var point = spawnPoints[Random.Range(0, spawnPoints.Count)];
                Debug.Log("SpawnEnemy " + spawn.enemy + " no " + point);
                Instantiate(spawn.enemy, point.position, point.rotation);
                yield return new WaitForSeconds(spawn.timePerEnemy);
            }
            yield return new WaitForSeconds(wave.TimePerSpawm);
        }
    }
}
