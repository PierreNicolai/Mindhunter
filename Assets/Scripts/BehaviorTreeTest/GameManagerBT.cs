using System.Collections;
using UnityEngine;
using BehaviorTreeLibrary;

public class GameManagerBT : MonoBehaviour 
{
	public T Find<T>(Vector3 position) where T : MonoBehaviour
	{
		float minDistance = float.MaxValue;

		T retObj = null;
		foreach (T  item in FindObjectsOfType(typeof(T))) {
			float dist = (item.gameObject.transform.position -  position).magnitude;
			if(dist < minDistance)
			{
				minDistance = dist;
				retObj = item;
			}
		}
		return retObj;
	}
}

