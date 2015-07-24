using UnityEngine;
using System.Collections;

public class SoundButtonScript : MonoBehaviour
{
    public bool sound;
    public GameObject explosion;
    public AudioSource audioSource;
    public AudioClip soundOnOffClip;
    public Transform tick;
    Transform trans;
    GameObject clone;

    // Use this for initialization
    void Start()
    {
		if (MainMenuScript.soundOn)
		{
			AudioListener.volume = 1;
		}
	}


    void OnTriggerEnter(Collider other)
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = soundOnOffClip;

		if (MainMenuScript.soundOn == false)
        {
			Destroy(clone, 0.0F);
			Debug.Log("soundOn is true");
			audioSource.Play();
			MainMenuScript.soundOn = true;
			AudioListener.volume = 1;
        }
        else
        {
			trans = Instantiate(tick, new Vector3(2.3F, 3.12F, 7.98F), Quaternion.identity) as Transform;
			clone = trans.gameObject;
			MainMenuScript.soundOn = false;
			Debug.Log("soundOn is false");
			AudioListener.volume = 1 - AudioListener.volume;
        }

        if (gameObject.name == "btn_Sound")
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
