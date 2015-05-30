using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void StartButtonPressed()
    {
        Debug.Log("Start Button Pressed");
    }

    public void OptionButtonPressed()
    {
        Debug.Log("Option Button Pressed");
    }

    public void ExitButtonPressed()
    {
        Debug.Log("Exit Button Pressed");
    }
}
