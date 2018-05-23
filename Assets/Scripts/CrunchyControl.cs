using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CrunchyControl : MonoBehaviour {

	private Rigidbody2D myRigidBody;
	private Animator myAnim;

	public GameObject DeathPanel;
	public bool dead = false;

	public float speed = 10;
	public float bunnyJumpForce = 500f;
	public float enemyJumpForce = 350f;
	private int jumpsLeft = 1;
	private float prevJumpTime = 0;
	private float jumpTime;
	private bool jumped = false;
	private bool inAir;
	public int coins = 0;

	//health
	public int health = 3;
	public GameObject health1;
	public GameObject health2;
	public GameObject health3;

	//Powers
	private bool leafPower = false;

	public bool left = false;
	public bool right = false;
	public bool jump = false;

	// Use this for initialization
	void Start () {
		myRigidBody = GetComponent<Rigidbody2D> ();
		myAnim = GetComponent<Animator> ();

		DeathPanel.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.UpArrow) && jumpsLeft > 0 || jump && jumpsLeft > 0) {
			//jumpsLeft = 0;
			myRigidBody.AddForce (transform.up * bunnyJumpForce);

			prevJumpTime = Time.fixedTime;
			//jumped = true;
		}
		if (Input.GetKey(KeyCode.RightArrow) || right) {
			myAnim.SetBool ("Right", true);
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
		if(Input.GetKey(KeyCode.LeftArrow) || left) {
			myAnim.SetBool("Right", false);
			transform.position += Vector3.left * speed * Time.deltaTime;
		}
		//Debug.Log ("Jump Time" + jumpTime);
		//Debug.Log ("Prev Jump Time" + prevJumpTime);

		//Activate death menu
		if (dead) {
			DeathPanel.SetActive (true);
			Time.timeScale = 0;
		} else {
			DeathPanel.SetActive (false);
			Time.timeScale = 1;
		}

		if (leafPower && !myAnim.GetBool ("leafPower")) {
			myAnim.SetTrigger ("changeLeaf");
			myAnim.SetBool ("leafPower", true);
		}

		//Adjust canvas health gage
		if (health == 2) {
			Destroy (health1);
		}
		if (health == 1) {
			Destroy (health2);
		}
		if (health == 0) {
			dead = true;
		}
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.collider.gameObject.layer == LayerMask.NameToLayer ("Enemy")) {
			//SceneManager.LoadScene ("Title");
			//dead = true;
			health -= 1;
		}
		if (collision.collider.gameObject.layer == LayerMask.NameToLayer ("Ground")) {
			if (inAir) {
				jumpTime = Time.fixedTime;
				jumped = false;
			}

			if (jumpTime - prevJumpTime > 1) {
				jumpsLeft = 1;
			}
			inAir = false;
			Debug.Log ("In Air" + inAir);
		}

		if (collision.collider.gameObject.layer == LayerMask.NameToLayer ("Enemy Top")) {
			jumpsLeft = 0;
			myRigidBody.AddForce (transform.up * enemyJumpForce);
			//jumpTime = Time.time;
		}
	}

	void OnCollisionExit2D(Collision2D collision) {
		if (collision.collider.gameObject.layer == LayerMask.NameToLayer ("Ground")) {
			inAir = true;
			jumpsLeft = 0;
			Debug.Log ("In Air" + inAir);
		}
	}
		
	void OnTriggerEnter2D(Collider2D trigger) {
		//Collect coin
		if (trigger.gameObject.layer == LayerMask.NameToLayer ("Coin")) {
			coins += 1;
			//Debug.Log ("Coins" + coins);
			Destroy (trigger.gameObject);
		}

		if (trigger.gameObject.layer == LayerMask.NameToLayer ("Leaf Power")) {
			leafPower = true;
			Destroy (trigger.gameObject);
		}
	}
		


	//Death menu buttons
	public void Retry () {
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
		dead = false;
	}

	public void LevelSelect () {
		SceneManager.LoadScene ("LevelSelect");
	}

	public void MainMenu () {
		SceneManager.LoadScene ("Title");
	}


	//Mobile control buttons
	public void Right() {
		right = true;
		left = false;
	}
	public void Left() {
		left = true;
		right = false;
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