using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private EnemyUnitManager enemyUnitManager;

    // Use this for initialization
    void Start ()
    {
        enemyUnitManager = GetComponentInParent<EnemyUnitManager>();
        if (enemyUnitManager == null)
        {
            Debug.LogError("Enemy Unit Manager could not be found.");
        }

        enemyUnitManager.SpawnEnemyUnit();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
