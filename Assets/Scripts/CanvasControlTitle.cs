using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CanvasControlTitle : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LevelSelect() {
		SceneManager.LoadScene ("LevelSelect");
	}
}
