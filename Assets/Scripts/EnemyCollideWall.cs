using UnityEngine;
using System.Collections;

public class EnemyCollideWall : MonoBehaviour {

	GameObject enemy;
	EnemyControl enemyControl;
	GameObject enemyTop;
	EnemyDefeat enemyDefeat;

	private Collider2D enemyCollider;

	// Use this for initialization
	void Start () {

		enemy = GameObject.Find ("Tad");
		enemyControl = enemy.GetComponent<EnemyControl> ();
		enemyTop = GameObject.Find ("tadTop");
		enemyDefeat = enemyTop.GetComponent<EnemyDefeat> ();

		enemyCollider = GetComponent<Collider2D> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (enemyDefeat.dead) {
			enemyCollider.enabled = false;
		}

	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.collider.gameObject.layer == LayerMask.NameToLayer ("Ground") && !enemyDefeat.dead) {
			enemyControl.collisions = true;
			Debug.Log ("Collisions" + enemyControl.collisions);
		} 
	}
}
