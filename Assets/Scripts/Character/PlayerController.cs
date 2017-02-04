using UnityEngine;
using MindHunter.Managers;

public class PlayerController : PersistentSingleton<PlayerController>
{
	public float speed;
	Vector3 velocity;
	Rigidbody rgdb;
	public bool isGrounded;
	public float groundCheckDistance;
	public float jumpPower;

	// Use this for initialization
	void Start () {
		isGrounded = false;
		rgdb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		velocity = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")).normalized * speed;	
		CheckGroundStatus();
		if(Input.GetButtonDown("Jump") && isGrounded) {
			rgdb.velocity = new Vector3(rgdb.velocity.x, jumpPower, rgdb.velocity.z);
		}

	}

	void FixedUpdate() {
		rgdb.MovePosition(transform.position + velocity  * Time.fixedDeltaTime);
	}

	void CheckGroundStatus()
		{
			RaycastHit hitInfo;
			// 0.1f is a small offset to start the ray from inside the character
			// it is also good to note that the transform position in the sample assets is at the base of the character
			if (Physics.Raycast(transform.position + (Vector3.up * 0.1f), Vector3.down, out hitInfo, groundCheckDistance))
			{
				isGrounded = true;
			}
			else
			{
				isGrounded = false;
			}
		}

}
