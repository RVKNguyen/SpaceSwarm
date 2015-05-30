using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void btnStartPressed()
    {
        Debug.Log("Start Button Pressed");

    }

    public void btnSettingsPressed()
    {
        Debug.Log("Settings Button Pressed");
    }

    public void btnExitPressed()
    {
        Debug.Log("Exit Button Pressed");
        Application.Quit();
    }
}
