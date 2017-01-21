using UnityEngine;

public class Pulpito : MonoBehaviour
{
    public float horizontalSpeed;
    public float verticalSpeed;

    public int currentLine = 3;

    private Vector3 lastPosition;
    private Vector3 nextPosition;

    private float stepTime;
    private bool stepping;

    public void MoveVertically()
    {
        if (stepping)
        {
            stepTime = Mathf.Clamp01(stepTime + verticalSpeed * Time.deltaTime);
            transform.position = Vector3.Lerp(lastPosition, nextPosition, stepTime);

            if (stepTime >= 1)
            {
                stepping = false;
            }

            return;
        }

        lastPosition = transform.position;
        stepTime = 0;

        if (Input.GetButton("Red"))
        {
            if (transform.position.y <= GlobalConfig.Instance.lines[6])
            {
                return;
            }

            currentLine++;
            nextPosition = new Vector3(lastPosition.x, GlobalConfig.Instance.lines[currentLine], 0);
            stepping = true;
        }

        if (Input.GetButton("Blue"))
        {
            if (transform.position.y >= GlobalConfig.Instance.lines[0])
            {
                return;
            }

            currentLine--;
            nextPosition = new Vector3(lastPosition.x, GlobalConfig.Instance.lines[currentLine], 0);
            stepping = true;
        }
    }

    public void MoveHorizontally()
    {
        transform.position += Vector3.right * horizontalSpeed * Time.deltaTime;
        lastPosition += Vector3.right * horizontalSpeed * Time.deltaTime;
        nextPosition += Vector3.right * horizontalSpeed * Time.deltaTime;
    }

    public void Move()
    {
        MoveVertically();
        MoveHorizontally();
    }

    public void Update()
    {
        Move();
    }

  void OnTriggerEnter2D(Collider2D collisioner){
    switch(collisioner.gameObject.tag){
      case "Obstacle": {
        Debug.Log("Colisionó");
        break;
      }
    }
  }

  public float DistanceTraveledInFrame(){
    return horizontalSpeed * Time.deltaTime;
  }
}
