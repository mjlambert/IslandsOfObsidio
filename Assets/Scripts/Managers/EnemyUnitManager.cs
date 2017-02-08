using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class EnemyUnitManager : MonoBehaviour {

    public List<GameObject> waypoints = new List<GameObject>();

    /// <summary>
    /// Called when an enemy unit has hit a waypoint
    /// </summary>
    /// <param name="waypoint">Waypoint that was hit.</param>
    /// <param name="enemyUnit">Enemy Unit that hit the waypoint.</param>
    public void WaypointHit(GameObject waypoint, EnemyUnit enemyUnit)
    {
        // Find index of waypoint that was hit
        int waypointIndex = waypoints.FindIndex(wp => wp.GetInstanceID() == waypoint.GetInstanceID());

        Debug.Log(string.Format("Current waypoint index: {0}", waypointIndex));

        // Get index of next waypoint
        int nextIndex = waypointIndex + 1;
        if (nextIndex >= waypoints.Count)
        {
            nextIndex = 0;
        }

        Debug.Log(string.Format("Next waypoint index: {0}", nextIndex));

        Debug.Log(string.Format("Waypoints count: {0}", waypoints.Count));

        // Tell enemy unit to go to next waypoint
        GameObject nextWayPoint = waypoints.ElementAt(nextIndex);
        enemyUnit.SetDestination(nextWayPoint.transform.position);
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
