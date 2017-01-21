using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour {

	const float MetersToGenerateNextObstacle = 5;

	public Pulpito player;

	public float nextObstacleInMeters;

	public List<GameObject> obstaculos;

	public int minY;

	public int maxY;

	public int xOffset;

	public int lifeTime;

	Vector3 PlayerPosition(){
			return player.transform.position;
	}

	void Start () {

	}

	void Update () {
		nextObstacleInMeters -= player.DistanceTraveledInFrame();
		if(nextObstacleInMeters <= 0){
			SpawnObstacle();
			ResetNextObstacleInMeters();
		}
	}

	void ResetNextObstacleInMeters(){
		nextObstacleInMeters = MetersToGenerateNextObstacle;
	}

	void SpawnObstacle(){
		var obstaculo = GetNextObstacle();
		var posicion = GetNextPosition();
		var instanciaObstaculo = Instantiate(obstaculo, posicion, Quaternion.identity);
		Destroy(instanciaObstaculo, lifeTime);
	}

	Vector3 GetNextPosition(){
		var xPosition = PlayerPosition().x + xOffset;
		var yPosition = GlobalConfig.Instance.RandomLine().y;
		return new Vector3(xPosition, yPosition, 0);
	}

	GameObject GetNextObstacle(){
		return obstaculos[0];
	}
}
