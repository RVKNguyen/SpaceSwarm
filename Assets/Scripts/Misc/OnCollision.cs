using UnityEngine;
using System.Collections;

public class OnCollision : MonoBehaviour
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
        if (other.tag == "Boundary" || other.tag == "Enemy" || other.tag == "Button")
		{
			return;
		}

		if (explosion != null)
		{
            Instantiate(explosion, transform.position, transform.rotation);
		}

		if (other.tag == "Player")
		{

            gameController.UpdateLife(Random.Range(-90, -80));
            if (gameController.GetLife() < 0)
            {
                Destroy(other.gameObject);
                gameController.GameOver();
            }
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
		}
		
        if (other.tag == "Shot")
        {
            if (this.tag == "Enemy")
            {
                if (GetComponent<EnemyController>() != null)
                {
                    EnemyController x = GetComponent<EnemyController>();
                    x.updateLife(1);
                    Debug.Log("Enemy hitted! Life: " + x.getLife());

                    if (x.getLife() > 0)
                    {
                        return;
                    }
                    else
                    {
                        Debug.Log("Enemy Down!");
                    }
                }
            }
            Destroy(gameObject);
            Destroy(other.gameObject);
            gameController.UpdateScore(scoreValue);
        }
        
	}

    void OnDestroy()
    {
        if(transform.parent != null){
            MainMenuScript script = transform.parent.gameObject.GetComponent<MainMenuScript>();
            
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
                    Application.LoadLevel(1);
                    break;
                default:
                    Debug.Log("Nichts passiert!");
                    break;
            }
        }
    }
}