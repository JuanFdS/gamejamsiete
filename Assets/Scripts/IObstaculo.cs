using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class IObstaculo : MonoBehaviour {

	virtual public void Initialize (GlobalConfig.ColorsToLines colorsToLines){
		transform.position = new Vector3 (transform.position.x, colorsToLines.line.y, 0);
	}
		
	abstract public void BeAffectedBy (EffectArea specialPower);
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
