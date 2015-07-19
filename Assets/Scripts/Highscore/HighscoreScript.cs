using UnityEngine;
using System.Collections;

public class HighscoreScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void btnRestartPressed()
	{
		Debug.Log("Restart Button Pressed");
		Application.LoadLevel(1);
	}
	internal void btnMenuPressed()
	{
		Debug.Log("Menu Button Pressed");
		Application.LoadLevel(0);
	}
	
	public void btnExitPressed()
	{
		Debug.Log("Exit Button Pressed");
		Application.Quit();
	}
}
