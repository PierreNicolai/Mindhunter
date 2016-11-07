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
        Add<Behavior>().Update = MoveAround;
        Add<Condition>().CanRun = IsTargetInSight;
        Add<Behavior>().Update = MoveToTarget;
    } 

    Status MoveAround() {
        return Status.BhSuccess;
    }
    
    bool IsTargetInSight() {        
        return fieldOfView != null  && fieldOfView.visibleTargets != null  &&  fieldOfView.visibleTargets.Count > 0;
    }

    Status MoveToTarget() {
        enemy.followingPath = false;
        return Status.BhSuccess;
    }        
}
