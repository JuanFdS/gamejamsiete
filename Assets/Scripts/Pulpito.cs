using System;

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

	public Material trailMaterial;

	private Color goingColor;
	public Color actualColor;

    private Line goinglLine;
    private float previousPitch;
    private AudioSource audio;

    public void Start(){
		goingColor = actualColor;
        goinglLine = GlobalConfig.Instance.Line(1).line;
        previousPitch = converToTone(goinglLine.y);
        audio = GetComponent<AudioSource>();
    }

    public void MoveVertically()
    {
		Step ();
		lastPosition = transform.position;
		stepTime = 0;

		MoveVerticallyBasedOnInput ();
    }

    public void MoveVerticallyBasedOnInput(){
		var estoEsReCabeza = 0;

		if(Input.GetButton ("Red")) red = true;
		if(Input.GetButton ("Blue")) blue = true;
		if(Input.GetButton ("Yellow")) yellow = true;

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

			var colorToLines = GlobalConfig.Instance.Line (estoEsReCabeza);

            goinglLine = colorToLines.line;
            goingColor = colorToLines.realColor;

			nextPosition = new Vector3 (lastPosition.x, goinglLine.y, goinglLine.z);

			stepping = true;

			red = false;
			yellow = false;
			blue = false;
			timeOfFirstKey = 0;
		}
	  
    }

    public void MoveHorizontally()
    {
        var sum = Vector3.right * horizontalSpeed * Time.deltaTime;
        transform.position += sum;
        lastPosition += sum;
        nextPosition += sum;
    }

    public void Move()
    {
        MoveVertically();
        MoveHorizontally();
    }

	public void FixedUpdate(){
		Move();
        
		var ypos = Mathf.Sin((goinglLine.y / 2 + 8) * Time.time) / 1.5f;

        var pitch = Mathf.Lerp(previousPitch, converToTone(goinglLine.y), 0.05f);
        audio.pitch = pitch;
	    previousPitch = pitch;
        transform.position += new Vector3 (0, ypos, 0);
	}

  void OnTriggerEnter(Collider collisioner){
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
    stepTime += verticalSpeed * Time.deltaTime;
		transform.position = Vector3.Lerp (lastPosition, nextPosition, stepTime); //Mathf.SmoothStep(0.2f, 0.8f, stepTime));
		var color = Color.Lerp(actualColor, goingColor,  stepTime);
		trailMaterial.color = color;
		actualColor = color;
    stepping = stepTime < 1;
		if (!stepping) {
			Debug.Log ("Llegue");
		}
  	}

    private float converToTone(float positionY)
    {
        return Mathf.Pow(2, positionY/12.0f);
    }
}
