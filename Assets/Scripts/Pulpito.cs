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

	private float timeOfFirstKey=0;
	bool red = false;
	bool blue = false;
	bool yellow = false;
    public void MoveVertically()
    {
		if (stepping) {
			Step ();
		}
		if(!stepping){
			
			lastPosition = transform.position;
			stepTime = 0;

			MoveVerticallyBasedOnInput ();
		}
    }

    public void MoveVerticallyBasedOnInput(){
		var estoEsReCabeza = 0;

		red = Input.GetButtonDown ("Red");
		blue = Input.GetButtonDown ("Blue");
		yellow = Input.GetButtonDown ("Yellow");
		if (Input.GetButtonDown("Red")){ red = true; estoEsReCabeza += 1; };
		if (Input.GetButtonDown("Blue")){ blue= true; estoEsReCabeza += 2; };
		if (Input.GetButtonDown("Yellow")){ yellow = true; estoEsReCabeza += 4; };
	  
		if (estoEsReCabeza != 0) {
			var line = GlobalConfig.Instance.Line (estoEsReCabeza);
				
			nextPosition = new Vector3 (lastPosition.x, line.y, line.z);

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
