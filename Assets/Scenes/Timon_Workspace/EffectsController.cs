using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Effect : MonoBehaviour {
	void Start() {
		shipController = gameObject.GetComponent<ShipController> ();
		CurrentLifeTime = 0F;
			MaxLifeTime = 1F;
	}

	public void Update() {


	}

	protected ShipController shipController;
	public float MaxLifeTime;
	public float CurrentLifeTime;
}

public class DamageEffect : Effect {
	void Update() {
		shipController.Damage (Time.deltaTime * 55F);
	}
}

public class EffectsController : MonoBehaviour {
	public List<Effect> Effects;

	public void Add<T>() where T : Effect {
		Effects.Add(gameObject.AddComponent<T>());
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < Effects.Count;) {
			Effects[i].CurrentLifeTime += Time.deltaTime;

			if (Effects[i].CurrentLifeTime > Effects[i].MaxLifeTime) {
				DestroyObject(Effects[i]);
				Effects.RemoveAt(i);
			} else {
				i++;
			}
		}
	
	}
}
