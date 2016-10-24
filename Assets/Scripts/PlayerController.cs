using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {

	// Use this for initialization
	private Vector3 velocity;
	private Rigidbody _rigidbody;

	private void Awake() {
		_rigidbody = GetComponent<Rigidbody>();
	}
	private void Start () {
		
	}
	
	public void Move(Vector3 _velocity) {
		
		velocity = _velocity;
	}

//	public void LookAt(Vector3 lookPoint) {
//		Vector3 heightCorrectedPoint = new Vector3 (lookPoint.x, transform.position.y, lookPoint.z);
//		transform.LookAt (heightCorrectedPoint);
//	}

	public void FixedUpdate() {
		_rigidbody.MovePosition (_rigidbody.position + velocity * Time.fixedDeltaTime);
	}
}
