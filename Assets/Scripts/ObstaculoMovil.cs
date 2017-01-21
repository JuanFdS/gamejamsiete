using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaculoMovil : Obstaculo {

	public float initialYPosition;
	private float timeAlive;

	private float YPosition(){
		return (Mathf.Sin (timeAlive * 3) - 0.5f) * 3;
	}

	// Use this for initialization
	void Start () {
		timeAlive = 0;
		initialYPosition = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		timeAlive += Time.deltaTime;
		transform.position = new Vector3 (transform.position.x, initialYPosition + YPosition (), transform.position.z);
	}
}
