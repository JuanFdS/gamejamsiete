using System.Linq;

using UnityEngine;

public class Pentagram : MonoBehaviour
{
    public Transform target;

    public GameObject line;

    public float lineOffsetX;
    public float lineOffsetY;

    public float movementOffset;

    void Start()
    {
        foreach (var movementLine in GlobalConfig.Instance.colorsToLines.Where(x => x.line.z == 0))
        {
            Instantiate(line, new Vector3(lineOffsetX, movementLine.line.y + lineOffsetY, 0.5f), Quaternion.identity).transform.SetParent(transform);
        }
    }
    
    public void FixedUpdate()
    {
		transform.position = new Vector3(target.position.x, movementOffset, transform.position.z);
    }
}
