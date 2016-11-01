using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{

	// Use this for initialization
	Vector3 velocity;
	Rigidbody _rigidbody;

	void Awake ()
	{
		_rigidbody = GetComponent<Rigidbody> ();
	}

	void Start ()
	{
		
	}

	public void Move (Vector3 _velocity)
	{
		
		velocity = _velocity;
	}

	public void FixedUpdate ()
	{
		_rigidbody.MovePosition (_rigidbody.position + velocity * Time.fixedDeltaTime);
	}
}
