using UnityEngine;
using System.Collections;

//This class will handle the reference to the core of the game like the Player, AI and more... 
public class GameManager : PersistentSingleton<GameManager> {

	public Player _player;
	void Awake() {
		
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public Player Player {
		get {
			return _player;
		}
		set {
			_player = value;
		}
	}
}
