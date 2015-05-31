using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour {

    public float speed;
    public float tilt;
    public float boundaryMinX;
    public float boundaryMaxX;
    public float boundaryMinY;
    public float boundaryMaxY;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;

    private float nextFire;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Movement();
        Aiming();
	}

    void Movement()
    {
        float moveHorizontal = transform.FindChild("Head").transform.forward.x;
        float moveVertical = transform.FindChild("Head").transform.forward.y;

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);
        GetComponent<Rigidbody>().velocity = movement * speed;

        GetComponent<Rigidbody>().position = new Vector3
        (
            Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundaryMinX, boundaryMaxX),
            Mathf.Clamp(GetComponent<Rigidbody>().position.y, boundaryMinY, boundaryMaxY),
            0.0f
        );

        GetComponent<Rigidbody>().rotation = Quaternion.Euler(0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
    }

    void Aiming()
    {
        RaycastHit hit;
        Camera camera = GetComponent<Camera>();
        var cameraCenter = camera.ScreenToWorldPoint(new Vector3(Screen.width / 2f, Screen.height / 2f, camera.nearClipPlane));

        if (Physics.Raycast(cameraCenter, this.transform.forward, out hit, 10000))
        {
            var obj = hit.transform.gameObject;
            if (obj.tag == "Enemy")
            {
                //Debug.Log("Shoot!");
                Shoot();
            }
        }
    }
    void Shoot()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            GetComponent<AudioSource>().Play();
        }
    }
}
