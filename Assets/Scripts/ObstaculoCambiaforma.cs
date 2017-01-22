using UnityEngine;

public class ObstaculoCambiaforma : ObstaculoEstatico
{
    private int goingBig = 1;
    
    void Update()
    {
        var changeSize = goingBig * new Vector3(Random.Range(0f, 20f), Random.Range(0f,20f), 0) * Time.deltaTime;
        transform.localScale += changeSize;
        if (transform.localScale.x > 5f || transform.localScale.x < 1f || transform.localScale.y > 5f || transform.localScale.y < 1f)
        {
            goingBig *= -1;
        }
    }
}
