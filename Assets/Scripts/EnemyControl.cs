using UnityEngine;
using System.Collections;

public class EnemyControl : MonoBehaviour {

	public GameObject enemyTop;
	EnemyDefeat enemyDead;

	private Collider2D enemyCollider;

	public float speed = 10;
	private float deathHop = 5;
	private Animator myAnim;
	public bool collisions = false;

	public EnemyDefeat dead;

	// Use this for initialization
	void Start () {
		enemyDead = enemyTop.GetComponent<EnemyDefeat> ();

		myAnim = GetComponent<Animator> ();

		enemyCollider = GetComponent<Collider2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!enemyDead.dead) {
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

		if (enemyDead.dead) {
			enemyCollider.enabled = false;
			transform.position += Vector3.up * deathHop * Time.deltaTime;
			//Debug.Log ("dead" + dead);
		}
	}
}
