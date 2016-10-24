using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
// This class is responsable for tracking all inputs recieves from the keyboard/mouse and xbox controller 
// and send them to the desired class for handle the data
public class InputManager : PersistentSingleton<InputManager> {

	//Reference for the player
	private static Player player;
	// Use this for initialization
	void Start () {
		player = GameManager.Instance.Player;
	}
	
	// Update is called once per frame
	void Update () {
		if(player==null)
			return;
		player.MoveInput = new Vector3(CrossPlatformInputManager.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
	}
}
