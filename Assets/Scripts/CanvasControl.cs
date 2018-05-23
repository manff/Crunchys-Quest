using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasControl : MonoBehaviour {

	GameObject crunchy;
	CrunchyControl crunchyControl;
	public Text coinsText;

	public GameObject PausePanel;
	public bool paused;

	// Use this for initialization
	void Start () {
		crunchy = GameObject.Find ("Crunchy");
		crunchyControl = crunchy.GetComponent<CrunchyControl> ();

		PausePanel.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		coinsText.text = (crunchyControl.coins).ToString("Coins: 0");

		if (paused) {
			PausePanel.SetActive (true);
			Time.timeScale = 0;
		} else {
			PausePanel.SetActive (false);
			Time.timeScale = 1;
		}
	}

	public void PauseMenuOn () {
		paused = true;
	}

	public void PauseMenuOff () {
		paused = false;
	}

	public void LevelSelect () {
		SceneManager.LoadScene ("LevelSelect");
	}

	public void MainMenu () {
		SceneManager.LoadScene ("Title");
	}
}
