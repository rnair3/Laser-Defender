using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] bool loop = false;
    int startingIndex = 0;
    

    // Start is called before the first frame update
    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        }
        while (loop);
    }

    private IEnumerator SpawnAllWaves()
    {
        for(int i = startingIndex; i < waveConfigs.Count; i++)
        {
            var currentWave = waveConfigs[i];
            yield return StartCoroutine(SpawnAllEnemiesUsingWaves(currentWave));
        }
    }

    private IEnumerator SpawnAllEnemiesUsingWaves(WaveConfig currentWave)
    {
        for(int i = 0; i < currentWave.GetNumberOfEnemies(); i++)
        {
            var newEnemy = Instantiate(currentWave.GetEnemy(), currentWave.GetWaypoints()[0].transform.position, Quaternion.identity);
            newEnemy.GetComponent<EnemyPath>().SetWaveConfig(currentWave);
            yield return new WaitForSeconds(currentWave.GetTimeBetweenSpawns());
        }        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
