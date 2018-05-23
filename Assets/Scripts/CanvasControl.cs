using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CanvasControl : MonoBehaviour {

	GameObject crunchy;
	CrunchyControl crunchyControl;
	public Text coinsText;

	// Use this for initialization
	void Start () {
		crunchy = GameObject.Find ("Crunchy");
		crunchyControl = crunchy.GetComponent<CrunchyControl> ();
	}
	
	// Update is called once per frame
	void Update () {
		coinsText.text = (crunchyControl.coins).ToString("Coins: 0");
	}
}
