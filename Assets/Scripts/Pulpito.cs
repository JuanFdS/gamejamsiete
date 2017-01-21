using UnityEngine;

public class Pulpito : MonoBehaviour
{
    public float speed;

	void Update ()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;

        if (Input.GetButton("Red"))
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }

        if (Input.GetButton("Blue"))
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
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
}
