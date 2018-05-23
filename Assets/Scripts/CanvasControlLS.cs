using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasControlLS : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OneOne() {
		SceneManager.LoadScene ("Level1-1");
	}

	public void OneTwo() {
		SceneManager.LoadScene ("Level1-2");
	}

	public void OneTen() {
		SceneManager.LoadScene ("Level1-10");
	}

}
