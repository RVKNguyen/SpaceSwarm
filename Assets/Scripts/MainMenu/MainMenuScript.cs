using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour {

    public void btnStartPressed()
    {
        Debug.Log("Start Button Pressed");
        StartCoroutine(WaitForSeconds(2000));
        Application.LoadLevel(1);
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

    IEnumerator WaitForSeconds(float time)
    {
        Debug.Log("BEFORE");
        yield return new WaitForSeconds(time);
        Debug.Log("AFTER");
    }
}
