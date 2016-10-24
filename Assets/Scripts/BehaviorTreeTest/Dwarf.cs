using System.Collections;
using UnityEngine;
using BehaviorTreeLibrary;
using System.Collections.Generic;

public class Dwarf : MonoBehaviour
{
	public GameManagerBT manager;
	private NavMeshAgent nav;
	public float speed = 12f;
	public List<Behavior> behaviors = new List<Behavior>();

	private GameObject target;

	public GameObject Target {
		get {
			return target;
		}
		set {
			target = value;
		}
	}

	public void Start()
	{
		target = gameObject;
		nav = GetComponent<NavMeshAgent>();
		behaviors.Add(new Hunger(this, manager));
//		ResetTarget();
	}

	public void Update()
	{
		foreach (var behavior in behaviors) {
			behavior.Tick();
		}


	}

	public void ResetTarget()
	{			
		if(target == null)
			return;
		Debug.Log(target.name);
		nav.SetDestination(target.transform.position);
	}

}

