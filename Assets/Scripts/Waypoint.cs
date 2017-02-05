using UnityEngine;
using System.Collections;

public class Waypoint : MonoBehaviour {



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
                enemyUnit.OnWaypointEnter(gameObject.transform.position);
            }
        }

    }
    
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
