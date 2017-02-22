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
        var selector = Add<Sequence>();
        selector.Add<Condition>().CanRun = IsTargetInSight;
        selector.Add<Behavior>().Update  = Detecting;
        selector.Add<Condition>().CanRun = IsSpoted;
        selector.Add<Behavior>().Update = MoveToTarget;
    } 

    Status FollowPath() {
//        Debug.Log("FollowPath");
        return Status.BhSuccess;
    }

    bool IsSpoted() {
        return enemy.spoted;
    }

    Status Detecting() {    
        enemy.startingDetection = true;
        return Status.BhSuccess;
    }

    bool IsTargetInSight() {
        Debug.Log("target in sight");
        return fieldOfView != null  && fieldOfView.visibleTargets != null  &&  fieldOfView.visibleTargets.Count == 1;       
    }

    Status MoveToTarget() {
        enemy.followingPath = false;
        enemy.SetTarget(fieldOfView.visibleTargets[0].position);
        return Status.BhSuccess;
    }
}
