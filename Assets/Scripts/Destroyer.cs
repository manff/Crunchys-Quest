using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour {
	
	public GameObject player;
	public GameObject playerDead;
	CrunchyControl CrunchyDead;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		CrunchyDead = playerDead.GetComponent<CrunchyControl> ();
	}

	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (player.transform.position.x, transform.position.y, transform.position.z);
	}

	void OnTriggerEnter2D(Collider2D trigger) {
		if (trigger.gameObject.layer == LayerMask.NameToLayer ("Player")) {
			CrunchyDead.dead = true;
		}
	}
}
