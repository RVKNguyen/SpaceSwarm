using UnityEngine;
using System.Collections;

public class PowerUpController : MonoBehaviour {

    public float speed;
    public string type;
    public AudioClip clip;
    public AudioSource audioSource;

    private GameController gameController;


	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;

        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("EventSystem");
        //Debug.Log(gameControllerObject);
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary" || other.tag == "Enemy" || other.tag == "Button")
        {
            return;
        }

        if (other.tag == "Player")
        {
            switch (type)
            {
                case "addLife":
                    //Debug.Log("PowerUp Collected: " + type);
                    gameController.UpdateLife(30);
                    break;
                case "addPoints":
                    //Debug.Log("PowerUp Collected: " + type);
                    gameController.UpdateScore(50);
                    break;
                default:
                    Debug.Log("PowerUp Fail!");
                    break;
            }
            Debug.Log("Power Up");

            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = clip;
            audioSource.Play();
            Destroy(gameObject);
        }
        
    }
}
