using UnityEngine;
using System.Collections;

public class EnemyControl : MonoBehaviour {

	GameObject enemyTop;
	EnemyDefeat enemyDefeat;

	private Collider2D enemyCollider;

	public float speed = 10;
	private float deathHop = 5;
	private Animator myAnim;
	public bool collisions = false;

	// Use this for initialization
	void Start () {
		myAnim = GetComponent<Animator> ();

		enemyTop = GameObject.Find ("tadTop");
		enemyDefeat = enemyTop.GetComponent<EnemyDefeat> ();

		enemyCollider = GetComponent<Collider2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!enemyDefeat.dead) {
			if (myAnim.GetBool ("right") == false) {
				transform.position += Vector3.left * speed * Time.deltaTime;
			}
			if (myAnim.GetBool ("right") == true) {
				transform.position += Vector3.right * speed * Time.deltaTime;
			}
			if (collisions) {
				myAnim.SetBool ("right", !myAnim.GetBool ("right"));
				collisions = false;
			}
		}

		if (enemyDefeat.dead) {
			enemyCollider.enabled = false;
			transform.position += Vector3.up * deathHop * Time.deltaTime;
		}
	}
}
