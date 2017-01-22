using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewWall : ObstaculoEstatico
{
    public float posY;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	    transform.position = new Vector3(transform.position.x, posY, transform.position.z);
	}
}
