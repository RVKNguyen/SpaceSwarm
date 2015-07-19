using UnityEngine;
using System.Collections;

public class GameOverButtonScript : MonoBehaviour {
    public AudioSource audioSource;
    public AudioClip gameOverClip;

    void OnTriggerEnter(Collider other)
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = gameOverClip;
        audioSource.Play();
        Debug.Log("Sounds should have been played." + gameOverClip + "Audio: " + audioSource);
        Debug.Log("<<<<<<<<<<<<<<<<<< End of Audio");


        if (other.gameObject.tag == "Shot" && this.name == "Btn_Restart(Clone)")
        {
            Application.LoadLevel(1);
        }

        Destroy(other.gameObject);
        Destroy(gameObject);
    }

}
