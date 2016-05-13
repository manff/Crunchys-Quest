using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CrunchyControl : MonoBehaviour {

	private Rigidbody2D myRigidBody;
	private Animator myAnim;
	public float speed = 10;
	public float bunnyJumpForce = 500f;
	private int jumpsLeft = 1;
	private float prevJumpTime = 0;
	private float jumpTime;
	private bool jumped = false;
	public int coins = 0;

	public bool left = false;
	public bool right = false;
	public bool jump = false;

	// Use this for initialization
	void Start () {
		myRigidBody = GetComponent<Rigidbody2D> ();
		myAnim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.UpArrow) && jumpsLeft > 0 || jump && jumpsLeft > 0) {
			jumpsLeft = 0;
			myRigidBody.AddForce (transform.up * bunnyJumpForce);
			prevJumpTime = Time.fixedTime;
			jumped = true;
		}
		if (Input.GetKey(KeyCode.RightArrow) || right) {
			left = false;
			myAnim.SetBool ("Right", true);
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
		if(Input.GetKey(KeyCode.LeftArrow) || left) {
			right = false;
			myAnim.SetBool("Right", false);
			transform.position += Vector3.left * speed * Time.deltaTime;
		}
		Debug.Log ("Jump Time" + jumpTime);
		Debug.Log ("Prev Jump Time" + prevJumpTime);
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.collider.gameObject.layer == LayerMask.NameToLayer ("Enemy")) {
			//Application.LoadLevel (Application.loadedLevel);
			Application.LoadLevel ("Title");
		} else if (collision.collider.gameObject.layer == LayerMask.NameToLayer ("Ground")) {
			if (jumped) {
				jumpTime = Time.fixedTime;
				jumped = false;
			}

			if (jumpTime - prevJumpTime > 1) {
				jumpsLeft = 1;
			}
		}

		if (collision.collider.gameObject.layer == LayerMask.NameToLayer ("Enemy Top")) {
			jumpsLeft = 0;
			myRigidBody.AddForce (transform.up * bunnyJumpForce);
			jumpTime = Time.time;
		}
	}

	void OnTriggerEnter2D(Collider2D trigger) {
		if (trigger.gameObject.layer == LayerMask.NameToLayer ("Coin")) {
			coins += 1;
			//Debug.Log ("Coins" + coins);
			Destroy (trigger.gameObject);
		}
	}

	public void Right() {
		right = true;
	}
	public void Left() {
		left = true;
	}

	public void RightStop() {
		right = false;
	}
	public void LeftStop() {
		left = false;
	}
	public void Jump() {
		jump = true;
	}
	public void JumpStop() {
		jump = false;
	}
}