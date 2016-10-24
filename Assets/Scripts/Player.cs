using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float moveSpeed = 5;
	// Move input from the player
	private Vector3 moveInput;
	//The player controller
	private PlayerController _controller;
	//Main camera of the game
	private Camera _camera;

	// Use this for initialization
	void Start () {
		_controller = GetComponent<PlayerController>();
		_camera = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 moveVelocity = moveInput.normalized * moveSpeed;
		_controller.Move(moveVelocity);
	}

	public Vector3 MoveInput {
		get {
			return moveInput;
		}
		set {
			moveInput = value;
		}
	}
}
