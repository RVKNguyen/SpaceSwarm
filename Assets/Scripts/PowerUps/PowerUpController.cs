using UnityEngine;
using System.Collections;

public class PowerUpController : MonoBehaviour {

    public float speed;
    public string type;

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary" || other.tag == "Enemy" || other.tag == "Button")
        {
            return;
        }

        if (other.tag == "Player")
        {
            Debug.Log("PowerUp Collected: " + type);




            Destroy(gameObject);
        }
        
    }
}
