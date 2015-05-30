using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {

    public GameObject explosion;

	void OnTriggerEnter (Collider other)
	{
		if (explosion != null)
		{
			Instantiate(explosion, transform.position, transform.rotation);
		}

        if (transform.parent != null)
        {
            MainMenuScript script = transform.parent.gameObject.GetComponent<MainMenuScript>();

            switch (this.name)
            {
                case "btn_Start":
                    //Debug.Log("Start pressed");
                    script.btnStartPressed();
                    break;
                case "btn_Settings":
                    //Debug.Log("Settings pressed");
                    script.btnSettingsPressed();
                    break;
                case "btn_Exit":
                    //Debug.Log("Exit pressed");
                    script.btnExitPressed();
                    break;
                default:
                    Debug.Log("Nothing");
                    break;
            }
        }

		Destroy (other.gameObject);
		Destroy (gameObject);
	}
}
