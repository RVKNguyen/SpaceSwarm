using UnityEngine;
using System.Collections;

public class RestartButtonScript : MonoBehaviour {
    public AudioSource audioSource;
    public AudioClip restartClip;

    void OnTriggerEnter(Collider other)
    {
        audioSource = gameObject.AddComponent<AudioSource>();
		audioSource.clip = restartClip;
		audioSource.Play();
		Debug.Log("Sounds should have been played." + restartClip + "Audio: " + audioSource);
        Debug.Log("<<<<<<<<<<<<<<<<<< End of Audio");


        if (other.gameObject.tag == "Shot" && this.name == "Btn_Restart(Clone)")
        {
            Application.LoadLevel(4);
        }

        Destroy(other.gameObject);
        Destroy(gameObject);
    }

}
