using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour {




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
