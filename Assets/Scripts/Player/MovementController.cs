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
        selectionTime = 2;
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
                //Debug.Log("BUTTON!");
                selectionTime -= Time.deltaTime;
                //Debug.Log(selectionTime);
                if (selectionTime <= 0)
                {
                    Shoot();
                }
            }
            else
            {
                selectionTime = 2;
            }
        }
    }
    void Shoot()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Debug.Log(shotSpawn_middle.rotation);
            var angle =  Quaternion.Euler (new Vector3(0, 0, 0.5F )); 
            Instantiate(shot, shotSpawn_middle.position, shotSpawn_middle.rotation);
            GetComponent<AudioSource>().Play();
        }
    }
}
