using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class IObstaculo : MonoBehaviour {

	abstract public void Initialize ();
	abstract public void BeAffectedBy (EffectArea specialPower);
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
