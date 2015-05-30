using UnityEngine;
using System.Collections;

public class DestroyByCollision : MonoBehaviour
{
	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;
	private Done_GameController gameController;

	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <Done_GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Boundary" || other.tag == "Enemy")
		{
			return;
		}

		if (explosion != null)
		{
			Instantiate(explosion, transform.position, transform.rotation);
		}

		if (other.tag == "Player")
		{
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
			gameController.GameOver();
		}
		
        //gameController.AddScore(scoreValue);
		Destroy (other.gameObject);
		Destroy (gameObject);
	}

    void OnDestroy()
    {
        if(transform.parent != null){
            MainMenuScript script = transform.parent.gameObject.GetComponent<MainMenuScript>();
            
            //Debug.Log(this.name);
            switch (this.name) 
            {
                case "btn_Start":
                    script.btnStartPressed();
                    break;
                case "btn_Settings":
                    script.btnSettingsPressed();
                    break;
                case "btn_Exit": 
                    script.btnExitPressed();
                    break;
                default:
                    Debug.Log("Nichts passiert!");
                    break;
            }
        }
    }
}