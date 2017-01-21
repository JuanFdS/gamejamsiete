using System;

using UnityEngine;

public class Pulpito : MonoBehaviour
{

    public float horizontalSpeed;
    public float verticalSpeed;

    public float coolDown = 100;
    public float timeToRecharge = 0.5f;

    private Vector3 lastPosition;
    private Vector3 nextPosition;

    private float stepTime;
    private bool stepping;

    private float timeOfFirstKey = 0;
    public float maxTimeToPressKeys = 0.05f;
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

    private int lastLine = 2;

    public void Start()
    {
        goingColor = actualColor;
    }

    public void MoveVertically()
    {
		Step ();
		lastPosition = transform.position;
		stepTime = 0;

		MoveVerticallyBasedOnInput ();
    }

    public void MoveVerticallyBasedOnInput()
    {
        var estoEsReCabeza = 0;

        if (Input.GetButtonDown("Red"))
            red = true;
        if (Input.GetButtonDown("Blue"))
            blue = true;
        if (Input.GetButtonDown("Yellow"))
            yellow = true;

        if (red || blue || yellow)
        {
            if (timeOfFirstKey == 0)
            {
                timeOfFirstKey = Time.time;
            }
            else if (timeOfFirstKey + maxTimeToPressKeys <= Time.time)
            {
                if (red)
                    estoEsReCabeza += 1;
                if (blue)
                    estoEsReCabeza += 2;
                if (yellow)
                    estoEsReCabeza += 4;

                if (coolDown == 0)
                {
                    estoEsReCabeza = lastLine;
                }
                else if (estoEsReCabeza != 5 && estoEsReCabeza != 7)
                {
                    lastLine = estoEsReCabeza;
                }

            goinglLine = colorToLines.line;
            goingColor = colorToLines.realColor;

			nextPosition = new Vector3 (lastPosition.x, goinglLine.y, goinglLine.z);

                nextPosition = new Vector3(lastPosition.x, line.y, line.z);

                stepping = true;

                red = false;
                blue = false;
                yellow = false;
                timeOfFirstKey = 0;
            }
        }

        if (coolDown == 0)
        {
            var colorToLines = GlobalConfig.Instance.Line(lastLine);
            var line = colorToLines.line;

            goingColor = colorToLines.realColor;

            nextPosition = new Vector3(lastPosition.x, line.y, line.z);

            stepping = true;
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
        
		var ypos = Mathf.Sin((goinglLine.y / 2 + 8) * Time.time) / 2.5f;
        var pitch = Mathf.Lerp(previousPitch, converToTone(goinglLine.y), 0.05f);
        audio.pitch = pitch;
	    previousPitch = pitch;
        transform.position += new Vector3 (0, ypos, 0);
	}

    public void Update()
    {
        var coolSpeed = 25;

        if (nextPosition.z != 0)
        {
            coolDown -= Time.deltaTime * coolSpeed;
            coolDown = Mathf.Max(0, coolDown);
            timeToRecharge = 1.5f;
        }
        else if (timeToRecharge < 0)
        {
            coolDown += Time.deltaTime * coolSpeed;
            coolDown = Mathf.Min(coolDown, 100);
        }
        else
        {
            timeToRecharge -= Time.deltaTime;
        }
    }

    void OnTriggerEnter(Collider collisioner)
    {
        switch (collisioner.gameObject.tag)
        {
            case "Obstacle":
                {
                    Debug.Log("Colisionó");
                    break;
                }
        }
    }

  public void Step(){
		stepTime += Mathf.Clamp01(verticalSpeed * Time.deltaTime);
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
        return Mathf.Pow(2, positionY / 12.0f);
    }
}
