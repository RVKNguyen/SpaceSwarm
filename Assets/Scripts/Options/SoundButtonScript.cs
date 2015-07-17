using UnityEngine;
using System.Collections;

public class SoundButtonScript : MonoBehaviour {
    public AudioSource audioSource;
    public AudioClip soundOnOffClip;

    void OnTriggerEnter(Collider other)
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = soundOnOffClip;
        audioSource.Play();


        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
