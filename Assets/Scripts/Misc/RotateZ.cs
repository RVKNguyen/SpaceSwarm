using UnityEngine;
using System.Collections;

public class RotateZ : MonoBehaviour {
    
    public float speed;
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.right * speed * Time.deltaTime);
	}
}
