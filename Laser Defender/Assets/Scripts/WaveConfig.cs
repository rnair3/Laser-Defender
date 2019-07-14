using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName ="Enemy Wave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject path;

    [SerializeField] float timeBetweenSpawns = 0.5f;
    [SerializeField] float spawnFactor = 0.3f;
    [SerializeField] int numberOfEnemies = 5;
    [SerializeField] float moveSpeed = 2f;

    public GameObject GetEnemy() {    return enemy;  }

    public List<Transform> GetWaypoints()
    {
        var waveWayPoints = new List<Transform>();

        foreach(Transform child in path.transform)
        {
            waveWayPoints.Add(child);
        }

        return waveWayPoints;
    }
   

    public float GetTimeBetweenSpawns() { return timeBetweenSpawns; }

    public float GetSpawnFactor() { return spawnFactor; }

    public int GetNumberOfEnemies() { return numberOfEnemies; }

    public float GetMoveSpeed() { return moveSpeed; }
}
