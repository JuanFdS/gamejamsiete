using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class HUD : MonoBehaviour
{
    public Text counter;

    public Pulpito player;

	public Sprite[] powerUpBars;

	public Image imageContainer;

    void Start()
    {
    }

	void Update ()
	{
		counter.text = GlobalConfig.Instance.Points().ToString("0.00");

		var mappedValue = this.CustomMapValue (player.coolDown, 0f, 100f, 0f, 5f);

		var intValue = (int)mappedValue;

		imageContainer.sprite = powerUpBars [intValue];

	    if (Input.GetKeyDown(KeyCode.K))
	    {
	        SceneManager.LoadScene(2);
	    }
    }

	float CustomMapValue(float s, float a1, float a2, float b1, float b2)
	{
		return b1 + (s-a1)*(b2-b1)/(a2-a1);
	}
}
