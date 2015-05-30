using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Effect : MonoBehaviour {
	void Start() {
		shipController = gameObject.GetComponent<ShipController> ();
	}

	public void Update() {


	}

	protected ShipController shipController;
	public float MaxLifeTime;
	public float CurrentLifeTime;
}

public class DamageEffect : Effect {


	void Update() {



	}
}

public class EffectsController : MonoBehaviour {
	List<Effect> Effects;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < Effects.Count;) {
			Effects[i].Update();

			Effects[i].CurrentLifeTime += Time.deltaTime;

			if (Effects[i].CurrentLifeTime > Effects[i].MaxLifeTime) {
				Effects.RemoveAt(i);
			} else {
				i++;
			}
		}
	
	}
}
