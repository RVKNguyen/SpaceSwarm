﻿using UnityEngine;
using System.Collections;

public class SoundButtonScript : MonoBehaviour {
    public GameObject explosion;
    public static bool soundOn = true;
    public AudioSource audioSource;
    public AudioClip soundOnOffClip;
    public Transform tick;
    Transform trans;
    GameObject clone;

    // Use this for initialization
    void Start()
    {
        soundOn = true;
        //clone = (Instantiate(tick, new Vector3(1.8F, 3.12F, 7.98F), Quaternion.identity) as Transform).gameObject;
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
        }
        else
        {
            trans = Instantiate(tick, new Vector3(1.8F, 3.12F, 7.98F), Quaternion.identity) as Transform;
            clone = trans.gameObject;
            Debug.Log("soundOn is false");
            soundOn = true;
        }

        if (gameObject.name == "btn_Sound")
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
