using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaxLayer : MonoBehaviour
{
    public Transform[] elements;

    public float endX;

    public float size;

    private int firstLayerIndex;

    void Update()
    {
        var element = elements[firstLayerIndex];

        if (element.position.x - element.parent.parent.position.x < endX)
        {
            var nextIndex = (firstLayerIndex + 1) % elements.Length;
            element.position = new Vector3(elements[nextIndex].position.x + size, element.position.y, element.position.z);

            firstLayerIndex = nextIndex;
        }
    }
}
