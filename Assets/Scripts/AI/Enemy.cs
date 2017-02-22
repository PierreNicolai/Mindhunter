using UnityEngine;
using System.Collections;
using BehaviorTreeLibrary;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{

    [Header("Audio clips")]
    [Space(10)]
    public AudioClip detectionAudio;
    public AudioClip screamAudio;
    public AudioClip walkingAudio;

    private AudioSource audioSource;

    public Animator animator;

    [Header("Agent speed")]
    [Space(10)]
    public float runningSpeed;
    public float walkingSpeed;

    [Header("Wavespoints")]
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

    // For the animator
    bool screaming;
    bool running; 
    bool detecting;
    bool idling;
    bool walking;


    public float detectionTime = 2f;
    // Behavior Tree variables
    public bool startingDetection;
    public bool inDection;
    [HideInInspector]
    public bool spoted;
    [HideInInspector]
    public bool targetRangeToScream;

    void Start()
    {
        startingDetection = false;
        inDection = false;
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
        UpdateAnimator();
        if(startingDetection && !inDection) {
            inDection = true;
            StartCoroutine(TryingToSpotPlayer(detectionTime));
        } 
    }

    public void SetTarget(Vector3 postion)
    {        
        if (navAgent != null)
            navAgent.SetDestination(postion);
    }

    void UpdateAnimator()
    {
        animator.SetBool("walk", walking);
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
            if (!followingPath)
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

    public void ResumeAI()
    {
        followingPath = true;
        navAgent.Resume();
        StartCoroutine(FollowPath());
    }

    public void StopAI()
    {
        StopCoroutine(FollowPath());
        navAgent.Stop();
        followingPath = false;
    }

    public void ResetAnimatorParameters() {
        running = idling = walking = screaming = detecting = false;
    }
    
    IEnumerator TryingToSpotPlayer(float time)
    {
        StopAI();
        detecting = true;
        yield return new WaitForSeconds(time);
        
        ResumeAI();
        inDection = false;
    }
             
}
