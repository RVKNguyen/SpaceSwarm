using UnityEngine;
using System.Collections;

public class HighscoreScript : MonoBehaviour {
	public GUIText scoreText;
	public GUIText highScoreText;

	public void Start ()
	{
		scoreText.text = "Last Score: " + GameController.score;
		//highScoreText = "Highscore: " + PlayerPrefs.GetInt("0HScore");
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
