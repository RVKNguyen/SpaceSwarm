using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public float Speed = 1F;
	public float WeaponLockTime = 4F;

	private GameObject Head;

	// Use this for initialization
	void Start () {
		Head = GameObject.Find ("Head");
		currentlyLockedObject = null;
	}

	private GameObject currentlyLockedObject;
	private float      lockTime;
	
	// Update is called once per frame
	void Update () {
		
		Cardboard.SDK.UpdateState();
		var rot = Cardboard.SDK.HeadPose.Orientation;
		
		float x = 2F * Mathf.Clamp (rot.y, -0.6F, 0.6F) / 0.6F;
		float y = 2F * Mathf.Clamp(rot.x, -0.6F, 0.6F) / 0.6F;

		gameObject.transform.position = new Vector3(x, y, gameObject.transform.position.z + Speed * Time.deltaTime);

		RaycastHit hit = new RaycastHit();
		Ray ray = new Ray();
		ray.origin = gameObject.transform.position;
		ray.direction = new Vector3(0F, 0F, 1F);

		if (Physics.Raycast (ray, out hit, 1000.0f)) {
			if (currentlyLockedObject != null) {
				if (currentlyLockedObject != hit.collider.gameObject) {
					lockTime = 0F;
				} else {
					lockTime += Time.deltaTime;
				}
			} else {
				lockTime = 0F;
			}
			currentlyLockedObject = hit.collider.gameObject;
		} else {
			currentlyLockedObject = null;
		}

		if (Input.GetMouseButtonDown (0)) {
			if (currentlyLockedObject != null) {
				currentlyLockedObject.GetComponent<EffectsController>().Add<DamageEffect>();
				
				currentlyLockedObject.GetComponent<ShipController>().DieEvent += () => {
					DestroyObject(currentlyLockedObject);
				};

			}
		}

		if (lockTime > WeaponLockTime) {
			// TODO: fire
		}
	}
}
