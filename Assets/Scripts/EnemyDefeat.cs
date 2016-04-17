using UnityEngine;
using System.Collections;

public class EnemyDefeat : MonoBehaviour {

	private Animator deathAnim;

	// Use this for initialization
	void Start () {
		
		deathAnim = GetComponentInParent<Animator> ();

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
		} 
	}
}
