using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class Spawner : MonoBehaviour {

    public GameObject Player;

    public static Spawner Instance { get; private set; }

    void Awake()
    {
        Instance = this;
    }

	// Use this for initialization
	void Start ()
    {
        GameObject player = Instantiate(Player, transform.position, Quaternion.identity);
        player.transform.localRotation = transform.rotation;
	}
}
