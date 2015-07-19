using UnityEngine;
using System.Collections;

public class OptionsScript : MonoBehaviour
{
	public void btnCreditsPressed ()
	{
		Debug.Log("Credits Button Pressed");
		Application.LoadLevel(3);
	}
    public void btnStartPressed()
    {
        Debug.Log("Start Button Pressed");
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
