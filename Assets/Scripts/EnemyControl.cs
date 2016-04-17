using UnityEngine;
using System.Collections;

public class EnemyControl : MonoBehaviour {

	public float speed = 10;
	private Animator myAnim;
	public bool collisions = false;

	// Use this for initialization
	void Start () {
		myAnim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
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
}
