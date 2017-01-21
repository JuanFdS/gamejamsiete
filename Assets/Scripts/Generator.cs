using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour {

	public GameObject player;

	int nextObstacleInMeters = 0;

	int lastPlayerXPosition = 0;

	int distancePlayerTraveled(int newPlayerXPosition){
		return newPlayerXPosition - lastPlayerXPosition;
	}



	public List<GameObject> obstaculos;

	Vector3 PlayerPosition(){
			return player.transform.position;
	}

	void Start () {

	}

	void Update () {
		if(PlayerPosition().x >= 10 && flag) {
			flag = false;
			var obstaculo = GetNextObstacle();
			Instantiate(obstaculo, new Vector3(PlayerPosition().x + 10, PlayerPosition().y, PlayerPosition().z), Quaternion.identity);
		}
	}

	GameObject GetNextObstacle(){
		return obstaculos[0];
	}
}
