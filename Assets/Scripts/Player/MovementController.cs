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
    public Transform shotSpawn_middle;
    public Transform shotSpawn_right;
    public float fireRate;

    private float nextFire;
    private float selectionTime;

	// Use this for initialization
	void Start () {
        selectionTime = 1;
	}
	
	// Update is called once per frame
	void Update () {
        Movement();
        Aiming();
        Selecting();
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
        var cameraCenter = camera.ScreenToWorldPoint(new Vector3(Screen.width / 1f, Screen.height / 2f, camera.nearClipPlane));

        //Debug.Log("Forward: " + Camera.main.transform.forward);
        if (Physics.SphereCast(cameraCenter, 0.3F, Camera.main.transform.forward, out hit, 1000))
        {
            //Debug.Log("SphereHit: " + hit.transform.gameObject);
            var obj = hit.transform.gameObject;
            if (obj.tag == "Enemy")
            {
                Shoot();
            }
        }
    }

    void Selecting()
    {
        RaycastHit hit;
        Camera camera = GetComponent<Camera>();
        var cameraCenter = camera.ScreenToWorldPoint(new Vector3(Screen.width / 2f, Screen.height / 2f, camera.nearClipPlane));

        if (Physics.Raycast(cameraCenter, this.transform.forward, out hit, 10000))
        {
            var obj = hit.transform.gameObject;
            if (obj.tag == "Button")
            {
                selectionTime -= Time.deltaTime;
                if (selectionTime <= 0)
                {
                    Shoot();
                    selectionTime = 2;
                }
            }
            else
            {
                selectionTime = 1;
            }
        }
    }
    void Shoot()
    {
        if (Time.time > nextFire)
        {
            //Debug.Log("Shoot!");
            nextFire = Time.time + fireRate;
            //Debug.Log(shotSpawn_middle.rotation);
            var angle =  Quaternion.Euler (new Vector3(0, 0, 0.5F ));
            var spreadX = 0;
            var spreadY = 0;

            if (Application.loadedLevel == 1)
            {
                spreadX = Random.Range(-10, -3);
                spreadY = Random.Range(-3, 3);
            }

            Instantiate(shot, shotSpawn_middle.position, shotSpawn_middle.rotation * Quaternion.Euler(spreadX, spreadY, 0));
            GetComponent<AudioSource>().Play();
        }
    }
}
