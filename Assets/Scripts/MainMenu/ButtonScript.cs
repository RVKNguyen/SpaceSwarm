using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {

    public GameObject explosion;
    public AudioClip explosion_asteroid;
    public AudioSource audioSource;


	void OnTriggerEnter (Collider other)
	{
        if (other.gameObject.tag == "Shot")
        {
            
            Debug.Log(explosion);
            if (explosion != null)
            {
                audioSource.clip = explosion_asteroid;
                audioSource.Play();
                Debug.Log("Sounds should have been played.");

                //explosion.GetComponent<Animation>().Play();
                Instantiate(explosion, transform.position, transform.rotation);
            }

            if (this.name == "Btn_GameOver(Clone)")
            {
                Application.LoadLevel(1);
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
                    case "btnStartExplode":
                        //Debug.Log("Start pressed");
                        script.btnStartPressed();
                        break;
                    case "btnOptionsExplode":
                        //Debug.Log("Settings pressed");
                        script.btnSettingsPressed();
                        break;
                    case "btnExitExplode":
                        //Debug.Log("Exit pressed");
                        script.btnExitPressed();
                        break;

                    default:
                        Debug.Log("Nothing");
                        break;
                }
            }

            Destroy(other.gameObject);
            Destroy(gameObject);
        }


        
	}
}
