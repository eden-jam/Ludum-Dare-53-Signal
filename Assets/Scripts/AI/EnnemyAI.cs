using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnnemyAI : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent agent;
    public Transform[] waypoints;
    int waypointIndex;
    Vector3 target;
    bool followPlayer = false;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        UpdateDestination(waypoints[waypointIndex].position);
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, target) < 1)
        {
            if(followPlayer == false)
            {
                IterateWaypointIndex();
                UpdateDestination(waypoints[waypointIndex].position);
            }
            else
            {
                followPlayer = false;
                UpdateDestination(waypoints[waypointIndex].position);
            }
            Debug.Log(target);
        }
    }

    void UpdateDestination(Vector3 newTarget)
    {
        target = newTarget;
        agent.SetDestination(target);
    }

    void IterateWaypointIndex()
    {
        waypointIndex++;
        if(waypointIndex == waypoints.Length)
        {
            waypointIndex = 0;
        }
    }

    public void IsScanned(Vector3 position)
    {
        position.y = 0;
        UpdateDestination(position);
        followPlayer = true;
    }
}
