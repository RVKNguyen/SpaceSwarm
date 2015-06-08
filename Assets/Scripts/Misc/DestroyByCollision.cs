using UnityEngine;
using System.Collections;

public class DestroyByCollision : MonoBehaviour
{
	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;
	private GameController gameController;

	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("EventSystem");
        //Debug.Log(gameControllerObject);
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameController>();
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
            Debug.Log("AUA!");
			//Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
			//gameController.GameOver();
		}
		
        gameController.UpdateScore(scoreValue);
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