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
	public float maxTimeToPressKeys=0.05f;
	bool red = false;
	bool blue = false;
	bool yellow = false;
	float lastYExtraPos = 0;
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

		if(Input.GetButtonDown ("Red")) red = true;
		if(Input.GetButtonDown ("Blue")) blue = true;
		if(Input.GetButtonDown ("Yellow")) yellow = true;

		if (timeOfFirstKey == 0) {
			if(red || blue || yellow)
				timeOfFirstKey = Time.time;
		}
		else if (timeOfFirstKey + maxTimeToPressKeys <= Time.time) {
			if (red)
				estoEsReCabeza += 1;
			if (blue)
				estoEsReCabeza += 2;
			if (yellow)
				estoEsReCabeza += 4;

			var line = GlobalConfig.Instance.Line (estoEsReCabeza);

			nextPosition = new Vector3 (lastPosition.x, line.y, line.z);

			stepping = true;

			red = false;
			yellow = false;
			blue = false;
			timeOfFirstKey = 0;
			estoEsReCabeza = 0;
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

	public void FixedUpdate(){
		Move();
		if (!stepping) {
			var ypos = Mathf.Sin (3 * Time.time) / 1.5f;
			transform.position += new Vector3 (0, ypos - lastYExtraPos, 0);
			lastYExtraPos = ypos;
		}
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
    stepTime += Mathf.Clamp01(verticalSpeed * Time.deltaTime);
		transform.position = Vector3.Lerp(lastPosition, nextPosition, stepTime);

    stepping = stepTime < 1;
		if (!stepping) {
			Debug.Log ("Llegue");
		}
  }
}
