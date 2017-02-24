using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTreeLibrary;

public class Stationary : Sequence
{

	private Enemy enemy;
	private FieldOfView fieldOfView;

	public Stationary (Enemy _enemy, FieldOfView _fieldOfView)
	{
		enemy = _enemy;
		fieldOfView = _fieldOfView;
		//eating
		Add<Behavior> ().Update = Eating;

		var selector = Add<Selector> ();
                       	                      	       
		var sequenceDetect = selector.Add<Sequence> ();
		sequenceDetect.Add<Condition> ().CanRun = IsTargetInSight;
		sequenceDetect.Add<Behavior> ().Update = Detecting;

		var sequenceSpoted = selector.Add<Sequence> ();
		sequenceSpoted.Add<Condition> ().CanRun = IsSpoted;
		sequenceSpoted.Add<Behavior> ().Update = MoveToTarget;
	}

	Status Eating ()
	{
		return Status.BhSuccess;
	}

	bool IsSpoted ()
	{   
		return enemy.spoted;
	}

	Status Detecting ()
	{    
		enemy.LaunchDetectionStationary ();
		return Status.BhSuccess;
	}

	bool IsTargetInSight ()
	{
		return fieldOfView != null && fieldOfView.visibleTargets != null && fieldOfView.visibleTargets.Count > 0 && !enemy.spoted;       
	}

	Status MoveToTarget ()
	{
//		enemy.followingPath = false;
		enemy.SetTarget (Player.Instance.transform.position);
		return Status.BhSuccess;
	}
}
