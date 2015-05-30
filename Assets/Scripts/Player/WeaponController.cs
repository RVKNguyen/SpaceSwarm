using UnityEngine;
using System.Collections;

public class ShotScript : MonoBehaviour {

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;

    private float nextFire;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            GetComponent<AudioSource>().Play();
        }
	}
}
