using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CrunchyControl : MonoBehaviour {

	private Rigidbody2D myRigidBody;
	private Animator myAnim;
	public float speed = 10;
	public float bunnyJumpForce = 500f;
	private int jumpsLeft = 1;
	public int coins = 0;

	// Use this for initialization
	void Start () {
		myRigidBody = GetComponent<Rigidbody2D> ();
		myAnim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.UpArrow) && jumpsLeft > 0) {
			jumpsLeft--;
			myRigidBody.AddForce (transform.up * bunnyJumpForce);
		}
		if (Input.GetKey(KeyCode.RightArrow)) {
			myAnim.SetBool ("Right", true);
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
		if(Input.GetKey(KeyCode.LeftArrow)) {
			myAnim.SetBool("Right", false);
			transform.position += Vector3.left * speed * Time.deltaTime;
		}
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.collider.gameObject.layer == LayerMask.NameToLayer ("Enemy")) {
			Application.LoadLevel (Application.loadedLevel);
		} else if (collision.collider.gameObject.layer == LayerMask.NameToLayer ("Ground")) {
			jumpsLeft = 1;
		}

		if (collision.collider.gameObject.layer == LayerMask.NameToLayer ("Enemy Top")) {
			myRigidBody.AddForce (transform.up * bunnyJumpForce);
		}
	}

	void OnTriggerEnter2D(Collider2D trigger) {
		if (trigger.gameObject.layer == LayerMask.NameToLayer ("Coin")) {
			coins += 1;
			Debug.Log ("Coins" + coins);
			Destroy (trigger.gameObject);
		}
	}
}