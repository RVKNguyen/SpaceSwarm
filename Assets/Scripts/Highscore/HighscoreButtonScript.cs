using UnityEngine;
using System.Collections;

public class HighscoreButtonScript : MonoBehaviour {
	public GameObject explosion;
	public AudioClip explosion_asteroid;
	public AudioSource audioSource;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	
	
	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Shot") {
			
			Debug.Log (explosion);
			if (explosion != null) {
				audioSource.clip = explosion_asteroid;
				audioSource.Play ();
				Debug.Log ("Sounds should have been played.");
				
				//explosion.GetComponent<Animation>().Play();
				Instantiate (explosion, transform.position, transform.rotation);
			}
			
			if (transform.parent != null) {
				HighscoreScript script = transform.parent.gameObject.GetComponent<HighscoreScript> ();
				
				switch (this.name) {
				case "btnMenuExplode":
					script.btnMenuPressed ();
					break;
				case "btnExitExplode":
					//Debug.Log("Exit pressed");
					script.btnExitPressed ();
					break;
				case "btnRestartExplode":
					script.btnRestartPressed ();
					break;
				default:
					Debug.Log ("Nothing");
					break;
				}
			}
			
			Destroy (other.gameObject);
			Destroy (gameObject);
		}
	}
}
