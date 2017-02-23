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
        return Status.BhSuccess;
    }

    bool IsSpoted() {   
        return enemy.spoted;
    }

    Status Detecting() {    
	enemy.LaunchDetection();
        return Status.BhSuccess;
    }

    bool IsTargetInSight() {
        return fieldOfView != null  && fieldOfView.visibleTargets != null  &&  fieldOfView.visibleTargets.Count > 0 && !enemy.spoted;       
    }

    Status MoveToTarget() {
        enemy.followingPath = false;
        enemy.SetTarget(Player.Instance.transform.position);
        return Status.BhSuccess;
    }
}
