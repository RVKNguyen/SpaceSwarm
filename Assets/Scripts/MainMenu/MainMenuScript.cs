using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour {
	public static bool soundOn;

	void Awake ()
	{
		soundOn = true;
	}


    public void btnStartPressed()
    {
        Debug.Log("Start Button Pressed");
        Application.LoadLevel(1);
    }

    public void btnSettingsPressed()
    {
        Debug.Log("Settings Button Pressed");
        Application.LoadLevel(2);
    }

	public void btnHighscorePressed ()
	{
		Debug.Log("Highscore Button Pressed");
		Application.LoadLevel(4);	}

    public void btnExitPressed()
    {
        Debug.Log("Exit Button Pressed");
        Application.Quit();
    }

    public void btnRestart()
    {
        Debug.Log("Restart Button Pressed");
        Application.LoadLevel(1);
    }


}
