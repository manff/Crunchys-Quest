using UnityEngine;
using System.Collections;

public class EnemyCollideWall : MonoBehaviour {

	GameObject enemy;
	EnemyControl enemyControl;

	// Use this for initialization
	void Start () {

		enemy = GameObject.Find ("Tad");
		enemyControl = enemy.GetComponent<EnemyControl> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.collider.gameObject.layer == LayerMask.NameToLayer ("Ground")) {
			enemyControl.collisions = true;
			Debug.Log ("Collisions" + enemyControl.collisions);
		} 
	}
}
