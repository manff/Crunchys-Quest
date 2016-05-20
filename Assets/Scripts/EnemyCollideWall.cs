using UnityEngine;
using System.Collections;

public class EnemyCollideWall : MonoBehaviour {

	public GameObject enemyTop;
	EnemyDefeat enemyDead;

	public GameObject enemy;
	EnemyControl enemyControl;

	public EnemyDefeat dead;

	private Collider2D enemyCollider;

	// Use this for initialization
	void Start () {
		enemyDead = enemyTop.GetComponent<EnemyDefeat> ();

		enemyControl = enemy.GetComponent<EnemyControl> ();

		enemyCollider = GetComponent<Collider2D> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (enemyDead.dead) {
			enemyCollider.enabled = false;
			//Debug.Log ("dead2" + dead);
		}
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.collider.gameObject.layer == LayerMask.NameToLayer ("Ground") && !enemyDead.dead) {
			enemyControl.collisions = true;
			Debug.Log ("Collisions" + enemyControl.collisions);
		} 
		if (collision.collider.gameObject.layer == LayerMask.NameToLayer ("Enemy") && !enemyDead.dead) {
			enemyControl.collisions = true;
			Debug.Log ("Collisions" + enemyControl.collisions);
		}
	}
}
