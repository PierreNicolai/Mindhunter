using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject Player;

	// Use this for initialization
	void Start ()
    {
        GameObject player = Instantiate(Player, transform.position, Quaternion.identity);
        player.transform.localRotation = transform.rotation;
	}
}
