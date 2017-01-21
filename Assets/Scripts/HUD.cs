using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Text counter;

    public Pulpito player;

    public Image powerUpBar;

    private Vector3 originalPowerUpBarPos;

    void Start()
    {
        originalPowerUpBarPos = powerUpBar.rectTransform.position;
    }

	void Update ()
	{
	    counter.text = GlobalConfig.Instance.Distance.ToString("0.00");

	    powerUpBar.rectTransform.sizeDelta = new Vector2(player.coolDown, powerUpBar.rectTransform.rect.height);
	    powerUpBar.rectTransform.position = new Vector2(originalPowerUpBarPos.x - (100 - player.coolDown), originalPowerUpBarPos.y);

	    if (Input.GetKeyDown(KeyCode.K))
	    {
	        SceneManager.LoadScene(2);
	    }
    }
}
