using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public float Speed = 1F;

	private GameObject Head;

	// Use this for initialization
	void Start () {
		int i = 0;

		for (float z = 0F; z <= 20F; z += 2F) {
			var obj = Object.Instantiate(GameObject.Find ("Cube"));
			obj.transform.position += new Vector3(0F, 0F, z);
			obj.name = "Karl " + i.ToString(); 

				i++;
		}

		Head = GameObject.Find ("Head");
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 newPosition = gameObject.transform.position + Head.transform.forward * Speed * Time.deltaTime;

		if (IsInsideLevel (newPosition)) {
			gameObject.transform.position = newPosition;
		}

		RaycastHit myhit = new RaycastHit();
		Ray myray = new Ray();
		myray.origin = gameObject.transform.position;
		myray.direction = Head.transform.forward;

		if (Physics.Raycast(myray, out myhit, 1000.0f))
			Debug.Log(myhit.collider.name);
	}

	bool IsInsideLevel(Vector3 newPos) {
		if (Mathf.Abs (newPos.x) > 10F) {
			return false;
		}

		if (Mathf.Abs (newPos.y) > 10F) {
			return false;
		}

		return true;
	}
}
