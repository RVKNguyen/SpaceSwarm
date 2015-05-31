using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour {

    public float speed;
    public float tilt;
    public float boundaryMinX;
    public float boundaryMaxX;
    public float boundaryMinY;
    public float boundaryMaxY;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Debug.Log(transform.FindChild("Head").transform.forward);

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
}
