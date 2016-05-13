using UnityEngine;
using System.Collections;

public class EnemyDefeat : MonoBehaviour {

	private Animator deathAnim;
	private Collider2D enemyCollider;
	public bool dead = false;

	// Use this for initialization
	void Start () {
		
		deathAnim = GetComponentInParent<Animator> ();
		enemyCollider = GetComponent<Collider2D> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		if (deathAnim.GetBool ("smashed") == true) {
			deathAnim.SetBool ("dead", true);
			deathAnim.SetBool ("smashed", false);
		}

		if (dead) {
			enemyCollider.enabled = false;
		}

	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.collider.gameObject.layer == LayerMask.NameToLayer ("Player") && !dead) {
			deathAnim.SetBool ("smashed", true);
			Debug.Log ("smashed" + deathAnim.GetBool ("smashed"));
			dead = true;
		} 
	}
}
