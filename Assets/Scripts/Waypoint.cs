using UnityEngine;
using System.Collections;

public class Waypoint : MonoBehaviour
{
    public GameObject gameManager;

    private EnemyUnitManager enemyUnitManager;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyUnit")
        {
            EnemyUnit enemyUnit = other.GetComponentInParent<EnemyUnit>();
            if (enemyUnit == null)
            {
                Debug.LogError(string.Format("No EnemyUnit script found on object[{0}]", other.name));
            }
            else
            {
                enemyUnitManager.WaypointHit(gameObject, enemyUnit);
            }
        }
    }
    
    // Use this for initialization
	void Start ()
    {
        enemyUnitManager = gameManager.GetComponent<EnemyUnitManager>();
        if (enemyUnitManager == null)
        {
            Debug.LogError("No EnemyUnitManager script found on the Game Manager");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawIcon(transform.position, "waypoint.png");
    }
}
