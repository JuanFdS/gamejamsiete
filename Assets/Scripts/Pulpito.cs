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
            Step();
        } else {
          lastPosition = transform.position;
          stepTime = 0;

          MoveVerticallyBasedOnInput();
        }
    }

    public void MoveVerticallyBasedOnInput(){
      if (Input.GetButton("Red"))
      {
          nextPosition = new Vector3(lastPosition.x, GlobalConfig.Instance.Line("Red").y, 0);
          stepping = true;
      }

      if (Input.GetButton("Blue"))
      {
          nextPosition = new Vector3(lastPosition.x, GlobalConfig.Instance.Line("Blue").y, 0);
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

  public void Step(){
    stepTime = Mathf.Clamp01(stepTime + verticalSpeed * Time.deltaTime);
    transform.position = Vector3.Lerp(lastPosition, nextPosition, stepTime);

    stepping = stepTime < 1;
  }
}
