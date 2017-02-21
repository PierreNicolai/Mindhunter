using UnityEngine;
using System.Collections;
using BehaviorTreeLibrary;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{    
    
    public List<AudioClip> clips;
    private AudioSource audioSource;
    public Animator animator;

    public List<Transform> path;

//    [HideInInspector]
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

    bool screaming;
    bool running;
    bool detecting;
    bool idling;

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
        if(Input.GetKey(KeyCode.A)) {
            ResumeEnemy();
        }

        if(Input.GetKey(KeyCode.Z) ){
            StopEnemy();
        }
        UpdateAnimator();
    }

    public void ResumeEnemy() {
        followingPath = true;
        navAgent.Resume();
        running = true;
        idling = false;
        StartCoroutine(FollowPath());
    }

    public void StopEnemy() {
        StopCoroutine(FollowPath());
        followingPath = false;
        navAgent.Stop();
        running = false;
        idling = true;
    }
    public void SetTarget(Vector3 postion)
    {
        if (navAgent != null)
            navAgent.SetDestination(postion);
    }

    void UpdateAnimator() {
        animator.SetBool("run", running);
        animator.SetBool("scream", screaming);
        animator.SetBool("detection", detecting);
        animator.SetBool("idle", idling);
    }

    // Simple follow path
    IEnumerator FollowPath()
    {
        Vector3 currentWaypoint = path[0].position;
        while (true)
        {                          
            if(!followingPath)
                break;
                           
//            Debug.Log("FollowPath1"+Time.deltaTime);      
//            Debug.Log("Distance"+Vector3.Distance(transform.position, currentWaypoint));        
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
