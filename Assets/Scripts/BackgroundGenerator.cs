using System;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundGenerator : MonoBehaviour
{
    public Transform target;
    
    [Serializable]
    public struct LayerSpeed
    {
        public ParalaxLayer layer;

        public float speed;
    }

    public List<LayerSpeed> layers;
    
    void FixedUpdate()
    {
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
        MoveLayers();
    }

    private void MoveLayers()
    {
        layers.ForEach(MoveLayer);
    }

    private void MoveLayer(LayerSpeed layer)
    {
        layer.layer.transform.position -= Vector3.right * layer.speed * Time.deltaTime;
    }
}
