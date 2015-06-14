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

            gameController.UpdateLife(Random.Range(-35, -25));
            if (gameController.GetLife() < 0)
            {
                Destroy(other.gameObject);
                gameController.GameOver();
            }
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
		}
		
        if (other.tag == "Shot")
        {
            Destroy(other.gameObject);
        }

        gameController.UpdateScore(scoreValue);
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
                case "btn_GameOver":
                    Debug.Log("NOOOOOOOOOOOO");
                    break;
                default:
                    Debug.Log("Nichts passiert!");
                    break;
            }
        }
    }
}