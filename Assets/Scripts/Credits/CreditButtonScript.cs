using UnityEngine;
using System.Collections;

public class CreditButtonScript : MonoBehaviour {

	public GameObject explosion;
	public AudioClip explosion_asteroid;
	public AudioSource audioSource;
	
	
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
				CreditsScript script = transform.parent.gameObject.GetComponent<CreditsScript> ();
				switch (this.name) {
					case "btnMenuExplode":
						script.btnMenuPressed ();
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
