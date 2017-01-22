using UnityEngine;
using UnityEngine.UI;

public class GameOverScore : MonoBehaviour
{
    public Text score; 
    
	void Start ()
	{
		score.text = GlobalConfig.Instance.Points().ToString("0.00");
    }
}
