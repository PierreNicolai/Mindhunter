using UnityEngine;
using System.Collections;
using System.Linq;
using BehaviorTreeLibrary;
using System.Collections.Generic;

public class Patrol : Sequence {

    private Enemy enemy;
    private FieldOfView fieldOfView;

    public Patrol(Enemy _enemy, FieldOfView _fieldOfView) {
        enemy = _enemy;
        fieldOfView = _fieldOfView;

        Add<Behavior>().Update = FollowPath;

        var selector = Add<Selector>();
                       	                      	       
	var sequenceDetect = selector.Add<Sequence>();
	sequenceDetect.Add<Condition>().CanRun = IsTargetInSight;
	sequenceDetect.Add<Behavior>().Update  = Detecting;

	var sequenceSpoted  = selector.Add<Sequence>();
	sequenceSpoted.Add<Condition>().CanRun = IsSpoted;
	sequenceSpoted.Add<Behavior>().Update = MoveToTarget;

		        
    } 

    Status FollowPath() {
    //    Debug.Log("FollowPath");
        return Status.BhSuccess;
    }

    bool IsSpoted() {
    //	Debug.Log("IsSpoted");
//    	if(enemy.spoted)
//    		Debug.LogError("erere");
        return enemy.spoted;
    }

    Status Detecting() {    
    //    Debug.Log("Detecting");
//        enemy.startingDetection = true;
	enemy.LaunchDetection();
        return Status.BhSuccess;
    }

    bool IsTargetInSight() {
//        Debug.Log("target in sight");
	//Debug.Log("target in sight ? "+fieldOfView != null  && fieldOfView.visibleTargets != null  &&  fieldOfView.visibleTargets.Count > 0);
        return fieldOfView != null  && fieldOfView.visibleTargets != null  &&  fieldOfView.visibleTargets.Count > 0 && !enemy.spoted;       
    }

    Status MoveToTarget() {
    	//Debug.Log("MoveToTarget");
        enemy.followingPath = false;
        enemy.SetTarget(Player.Instance.transform.position);
        return Status.BhSuccess;
    }
}
