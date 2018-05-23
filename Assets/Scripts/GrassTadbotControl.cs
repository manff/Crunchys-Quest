using UnityEngine;
using System.Collections;

public class GrassTadbotControl : MonoBehaviour {

	private Animator myAnim;

	int randomNum;
	float timerBetweenJump = 0;
	float timeBetweenJump = 300;

	// Use this for initialization
	void Start () {
		myAnim = GetComponentInChildren<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		randomNum = Random.Range (1, 3);
		timerBetweenJump += 1;

		Debug.Log ("timerBetweenJump" + timerBetweenJump);
		Debug.Log ("randomNum" + randomNum);

		if (randomNum == 1 && timerBetweenJump >= 300) {
			myAnim.SetTrigger ("Jump");
			myAnim.SetTrigger ("Idle");
			timerBetweenJump = 0;
		} else if (randomNum == 2 && timerBetweenJump >= 500) {
			Debug.Log ("working");
			timerBetweenJump = 0;
		}
	}
}
