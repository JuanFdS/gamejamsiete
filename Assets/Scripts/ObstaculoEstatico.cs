using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaculoEstatico : IObstaculo {

	override public void Initialize(){
	}

	override public void BeAffectedBy(EffectArea specialPower){
		Destroy (this.gameObject);
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
