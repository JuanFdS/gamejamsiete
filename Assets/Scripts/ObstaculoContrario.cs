using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaculoContrario : IObstaculo
{
    private float initialYPosition;
    private float timeAlive;

    override public void BeAffectedBy(EffectArea specialPower)
    {
        Destroy(this.gameObject);
    }

    private float YPosition()
    {
        return (Mathf.Sin(timeAlive * 9)) / 2;
    }

    private float XPosition()
    {
        return transform.position.x - Time.deltaTime * 5;
    }
    
    void Start()
    {
        timeAlive = 0;
        initialYPosition = transform.position.y;
    }

    void Update()
    {
        timeAlive += Time.deltaTime;
        transform.position = new Vector3(XPosition(), initialYPosition + YPosition(), transform.position.z);
    }
}
