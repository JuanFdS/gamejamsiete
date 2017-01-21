using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target;

    public float offsetX;

	void Update ()
    {
		transform.position = new Vector3(target.position.x + offsetX, transform.position.y, transform.position.z);
	}
}
