using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class EnemyUnitManager : MonoBehaviour
{
    /// <summary>
    /// Location enemy units will spawn.
    /// </summary>
    public GameObject spawnPoint;

    /// <summary>
    /// Path enemy units will follow.
    /// </summary>
    public List<GameObject> waypoints;

    /// <summary>
    /// Period of time between waves.
    /// </summary>
    public float waveDelay;

    /// <summary>
    /// Enemy Waves to run.
    /// </summary>
    public EnemyWave[] enemyWaves;

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(SpawnWaves());
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    /// <summary>
    /// Called when an enemy unit has hit a waypoint
    /// </summary>
    /// <param name="waypoint">Waypoint that was hit.</param>
    /// <param name="enemyUnit">Enemy Unit that hit the waypoint.</param>
    public void WaypointHit(GameObject waypoint, EnemyUnit enemyUnit)
    {
        // Find index of waypoint that was hit
        int waypointIndex = waypoints.FindIndex(wp => wp.GetInstanceID() == waypoint.GetInstanceID());

        // Get index of next waypoint
        int nextIndex = waypointIndex + 1;
        if (nextIndex >= waypoints.Count)
        {
            nextIndex = 0;
        }

        // Tell enemy unit to go to next waypoint
        GameObject nextWayPoint = waypoints.ElementAt(nextIndex);
        enemyUnit.SetDestination(nextWayPoint.transform.position);
    }

    /// <summary>
    /// Spawn Enemy Waves
    /// </summary>
    /// <returns></returns>
    private IEnumerator SpawnWaves()
    {
        for (int waveIndex = 0; waveIndex < enemyWaves.Length; waveIndex++)
        {
            yield return new WaitForSeconds(waveDelay);

            EnemyWave currentWave = enemyWaves[waveIndex];

            for (int enemiesSpawned = 0; enemiesSpawned < currentWave.enemiesToSpawn; enemiesSpawned++)
            {
                Instantiate(currentWave.enemyUnit, spawnPoint.transform.position, Quaternion.identity);
                yield return new WaitForSeconds(currentWave.spawnRate);
            }
        }
    }
}

[System.Serializable]
public class EnemyWave
{
    /// <summary>
    /// Enemy unit to spawn in this wave.
    /// </summary>
    public GameObject enemyUnit;

    /// <summary>
    /// Number of enemies to spawn in this wave.
    /// </summary>
    public int enemiesToSpawn;

    /// <summary>
    /// Period of time between spawning enemies in this wave.
    /// </summary>
    public float spawnRate;

    /// <summary>
    /// Time limit to complete this wave. (before the next wave starts)
    /// </summary>
    public float timeLimit;
}
