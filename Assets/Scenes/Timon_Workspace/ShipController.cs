using UnityEngine;
using System.Collections;

public delegate void Action();

public class ShipController : MonoBehaviour {

	public float Life;
	public float MaxLife;
	public event Action DieEvent;

	public void Damage(float dmg) {

		Life -= dmg;

		if (Life < 0F) {
			if (DieEvent != null) {
				DieEvent();
			}
		}

	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
