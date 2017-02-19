using UnityEngine;
using System.Collections;

public class EnemyUnit : MonoBehaviour
{

    private UnityEngine.AI.NavMeshAgent navMeshAgent;


    /// <summary>
    /// Set destination on the nav mesh agent
    /// </summary>
    /// <param name="target">Location of destination.</param>
    public void SetDestination(Vector3 target)
    {
        navMeshAgent.SetDestination(target);
    }

    // Use this for initialization
    void Start ()
    {
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        SetDestination(new Vector3(-2.5f, 0f, 0f));
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
