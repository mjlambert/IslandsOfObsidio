using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class EnemyUnitManager : MonoBehaviour
{
    public GameObject enemyUnitPrefab;

    public GameObject spawnPoint;

    public List<GameObject> waypoints;

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
    /// Spawn an enemy unit at the enemy unit spawn point
    /// </summary>
    public void SpawnEnemyUnit()
    {
        Instantiate(enemyUnitPrefab, spawnPoint.transform.position, Quaternion.identity);
    }

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
