using UnityEngine;
using System.Collections;

public class TPSCamera : MonoBehaviour
{
	//Pivot of the character
	public Transform pivot;

	//Distance between the character and the camera
	[Range (5, 10)]
	public float distance = 5.0f;
	// x, y postion of camera
	public float x = 0f;
	public float y = 0f;
	//Turn speed of the camera
	public float turnSpeedX = 10f;
	public float turnSpeedY = 5f;

	private float currentDistance = 0f;

	public float maxAngle = 90f;
	// Use this for initialization
	private void Start ()
	{
		x = transform.eulerAngles.x;
		y = transform.eulerAngles.y;
	}
	
	// Update is called once per frame
	void LateUpdate ()
	{
		x += Input.GetAxis ("Right Stick X Axis") * turnSpeedX;
		y += Input.GetAxis ("Right Stick Y Axis") * turnSpeedY;

		y = Mathf.Clamp(y, -maxAngle/2, maxAngle);
		Quaternion rotation = Quaternion.Euler (y, x, 0f);

		Vector3 negDistance = new Vector3 (0.0f, 0.0f, -distance);
//cameras postion
		Vector3 position = rotation * negDistance + pivot.position;
//rotation and position of our camera to different variables
		transform.rotation = rotation;
		transform.position = position;

		RaycastHit hit;
//if camera detects something behind or under it move camera to hitpoint so it doesn't go throught wall/floor
		Debug.DrawRay(pivot.position, (transform.position - pivot.position), Color.red);
		if (Physics.Raycast (pivot.position, (transform.position - pivot.position).normalized, out hit, (distance <= 0 ? -distance : distance))) {
			transform.position = hit.point;
		}
	}
}
