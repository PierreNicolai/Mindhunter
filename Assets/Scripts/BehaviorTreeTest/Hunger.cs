using System.Collections;
using UnityEngine;
using BehaviorTreeLibrary;

public class Hunger : Sequence {

	public int  hunger= 0;
	private Dwarf m_dwarf;
	private GameManagerBT _gameManager;
	private Vector3 target;
	private Food _targetFood;

	public Hunger (Dwarf m_dwarf, GameManagerBT _gameManager)
	{
		this.m_dwarf = m_dwarf;
		this._gameManager = _gameManager;


		Add<Behavior>().Update = IncreaseHunger ;
		Add<Condition>().CanRun  = IsHungry;
		Add<Behavior>().Update = LocateFood;

		var selector =  Add<Selector>();
		var sequence =  selector.Add<Sequence>();
		sequence.Add<Condition>().CanRun = NearFood;
		sequence.Add<Behavior>().Update = () => {			
			Debug.Log("Eating");
			hunger = 0;
			_targetFood = null;
			GameObject.Destroy(m_dwarf.Target);
			m_dwarf.Target = m_dwarf.gameObject;
			m_dwarf.ResetTarget();
			return Status.BhSuccess;
		};
	}
	public Status IncreaseHunger()
	{
		hunger++;
//		Debug.Log(hunger);
		return Status.BhSuccess;
	}

	bool NearFood ()
	{
		
		if((m_dwarf.transform.position - target).magnitude <= 0.5f)
		{
			Debug.Log("NearFood");
			return true;
		}
		return false;
	}

	bool IsHungry ()
	{
		return hunger > 100;
	}

	public Status LocateFood()
	{
		if(_targetFood == null)
		{
			Food food = _gameManager.Find<Food>(m_dwarf.transform.position);
			if(food == null)
			{
				return Status.BhFailure;
			}
			target = food.transform.position;
			_targetFood = food;
			m_dwarf.Target = food.gameObject;
			m_dwarf.ResetTarget();
		}
		return Status.BhSuccess;
	}
}
