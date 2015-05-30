using UnityEngine;
using System.Collections;

public class rotate_z : MonoBehaviour {
    
    public float speed;
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.right * speed * Time.deltaTime);
	}
}
