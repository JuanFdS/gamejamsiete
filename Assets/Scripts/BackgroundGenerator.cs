using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundGenerator : MonoBehaviour
{
    public Transform camera;

    public float offsetX;

    public float startX;
    public float endX;

    [Serializable]
    public struct ElementsSpeed
    {
        public List<Transform> images;

        public float speed;
    }

    public List<ElementsSpeed> elements;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(offsetX + camera.position.x, camera.position.y, transform.position.z);
        MoveElements();
    }

    private void MoveElements()
    {
        elements.ForEach(element => element.images.ForEach(img =>
            {
                if (img.position.x < endX + camera.position.x)
                {
                    Debug.Log("ENTRO");
                    img.position = new Vector3(img.position.x + startX, img.position.y, img.position.z);

                }

                img.position -= Vector3.right * element.speed * Time.deltaTime;
            }));
        //transform.position += sum;
        //img.position = new Vector3(img.position.x + element.speed * Time.deltaTime, img.position.y, img.position.z)));
    }
}
