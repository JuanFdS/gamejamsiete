using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Text counter;

    public Pulpito player;
    
	void Update ()
	{
	    counter.text = (player.transform.position.x / 25).ToString("0.00");
	}
}
