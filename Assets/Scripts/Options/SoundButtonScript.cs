using UnityEngine;
using System.Collections;

public class SoundButtonScript : MonoBehaviour {
    public static bool soundOn;
    public AudioSource audioSource;
    public AudioClip soundOnOffClip;
    public Transform tick;
    Transform trans;
    GameObject clone;

    // Use this for initialization
    void Start()
    {
        soundOn = true;
        trans = Instantiate(tick, new Vector3(1.8F, 3.12F, 7.98F), Quaternion.identity) as Transform;
        clone = trans.gameObject;
    }

    void OnTriggerEnter(Collider other)
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = soundOnOffClip;
        if (soundOn)
        {
            audioSource.Play();
            Destroy(clone, 0.0F);
            Destroy(clone, 0.0F);
        }
        else
        {
            trans = Instantiate(tick, new Vector3(1.8F, 3.12F, 7.98F), Quaternion.identity) as Transform;
            clone = trans.gameObject;
        }
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
