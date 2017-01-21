using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaculoCambiaforma : ObstaculoEstatico {

	private int goingBig = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		var changeSize = goingBig  * new Vector3 (Random.Range(0f,0.2f), Random.Range(0f,0.5f)	, 0);
		transform.localScale += changeSize;
		if (transform.localScale.x > 20f || transform.localScale.x < 5f|| transform.localScale.y > 40f || transform.localScale.y < 5f) {
			goingBig *= -1;
		}
	}

	override public void Initialize(GlobalConfig.ColorsToLines colorsToLines){
		base.Initialize (colorsToLines);
	}
}
