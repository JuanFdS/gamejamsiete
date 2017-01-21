using UnityEngine;

public class GlobalConfig : MonoBehaviour
{
    public static GlobalConfig Instance;

    public float[] lines;

	void Start ()
    {
	    if (Instance != null)
	    {
	        Destroy(gameObject);
	    }

	    Instance = this;
    }
}
