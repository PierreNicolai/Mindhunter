using UnityEngine;
using System.Collections;
using BehaviorTreeLibrary;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{
    // Debug purposes to delete
    public bool targetOnSight;
    public List<Transform> path;

    [HideInInspector]
    public bool followingPath;
    [HideInInspector]
    public List<Behavior> behaviors = new List<Behavior>();
    //Handle vision
    FieldOfView fieldOfView;
    //Nav agent
    UnityEngine.AI.NavMeshAgent navAgent;
    //distance offset
    float distanceOffset = 0.2f;
    int targetIndex;

    void Start()
    {
        followingPath = true;
        targetIndex = 0;       
        fieldOfView = GetComponent<FieldOfView>();
        navAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        StartCoroutine(FollowPath());
        behaviors.Add(new Patrol(this, fieldOfView));
    }

    void Update()
    {  
        foreach (var behavior in behaviors)
        {
            behavior.Tick();
        }           	
    }

    public void SetTarget(Vector3 postion)
    {
        if (navAgent != null)
            navAgent.SetDestination(postion);
    }

    // Simple follow path
    IEnumerator FollowPath()
    {
        Vector3 currentWaypoint = path[0].position;
        while (true)
        {
            
            if(!followingPath)
                break;
//            Debug.Log("FollowPath" + currentWaypoint);      
            Debug.Log("Distance"+Vector3.Distance(transform.position, currentWaypoint));        
            if (Vector3.Distance(transform.position, currentWaypoint) < distanceOffset)
            {
                targetIndex++;
                if (targetIndex >= path.Count)
                {
                    path.Reverse();
                    targetIndex = 0;
                }
                currentWaypoint = path[targetIndex].position;
            }
            navAgent.SetDestination(currentWaypoint);
            yield return null;    
        }

    }       
}
