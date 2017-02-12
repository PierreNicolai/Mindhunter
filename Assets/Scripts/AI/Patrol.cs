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
        selector.Add<Behavior>().Update = MoveToTarget;
    } 

    Status FollowPath() {
//        Debug.Log("FollowPath");
        return Status.BhSuccess;
    }
    
    bool IsTargetInSight() {
//        return fieldOfView != null  && fieldOfView.visibleTargets != null  &&  fieldOfView.visibleTargets.Count > 0;
        return enemy.targetOnSight;
    }

    Status MoveToTarget() {
        Debug.Log("MoveToTarget");
        return Status.BhSuccess;
    }        


}
