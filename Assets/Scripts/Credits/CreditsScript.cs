using UnityEngine;
using System.Collections;

public class CreditsScript : MonoBehaviour {

	public void btnMenuPressed()
	{
		Debug.Log("Menu Button Pressed");
		Application.LoadLevel(0);
	}

}
