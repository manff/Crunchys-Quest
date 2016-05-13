using UnityEngine;
using System.Collections;

public class EnemyDefeat : MonoBehaviour {

	private Animator deathAnim;
	private Collider2D enemyTopCollider;
	private Collider2D enemyCollider;
	private Collider2D enemySideLeftColliders;
	private Collider2D enemySideRightColliders;

	// Use this for initialization
	void Start () {
		
		deathAnim = GetComponentInParent<Animator> ();
		enemyTopCollider = GetComponent<Collider2D> ();
		enemyCollider = GetComponentInParent<Collider2D> ();
		enemySideLeftColliders = GetComponentInChildren<Collider2D> ();
		enemySideRightColliders = GetComponentInChildren<Collider2D> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		if (deathAnim.GetBool ("smashed") == true) {
			deathAnim.SetBool ("dead", true);
			deathAnim.SetBool ("smashed", false);
		}


	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.collider.gameObject.layer == LayerMask.NameToLayer ("Player")) {
			deathAnim.SetBool ("smashed", true);
			Debug.Log ("smashed" + deathAnim.GetBool ("smashed"));
			enemyCollider.enabled = false;
		} 
	}
}
