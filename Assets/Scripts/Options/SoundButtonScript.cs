using UnityEngine;
using System.Collections;

public class SoundButtonScript : MonoBehaviour {
    public static bool soundOn;
    public GameObject explosion;
    public AudioSource audioSource;
    public AudioClip soundOnOffClip;
    public Transform tick;
    Transform trans;
    GameObject clone;

    // Use this for initialization
    void Start()
    {
        soundOn = true;
        AudioListener.volume = 1;
    }

    void OnTriggerEnter(Collider other)
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = soundOnOffClip;
        if (soundOn)
        {
            audioSource.Play();
            Destroy(clone, 0.0F);
            Debug.Log("soundOn is true");
            soundOn = false;
            AudioListener.volume = 1 - AudioListener.volume;
        }
        else
        {
            trans = Instantiate(tick, new Vector3(2.3F, 3.12F, 7.98F), Quaternion.identity) as Transform;
            clone = trans.gameObject;
            Debug.Log("soundOn is false");
            soundOn = true;
            AudioListener.volume = 1;
        }

        if (gameObject.name == "btn_Sound")
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
