using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class Generator : MonoBehaviour {

	const float MetersToGenerateNextObstacle = 5;

	public Pulpito player;

	public float nextObstacleInMeters;

	public List<IObstaculo> obstaculos;

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
		var linea = GetNextLine();
		var instanciaObstaculo = Instantiate(obstaculo, GetNextPosition(), Quaternion.identity);
		instanciaObstaculo.GetComponent<IObstaculo> ().Initialize (linea);
		Destroy(instanciaObstaculo, lifeTime);
	}

	Vector3 GetNextPosition(){
		var xPosition = PlayerPosition().x + xOffset;
		return new Vector3(xPosition, 0, 0);
	}

	GlobalConfig.ColorsToLines GetNextLine(){
		return GlobalConfig.Instance.RandomColorToLine ();
	}

	GameObject GetNextObstacle(){
		var obstaculo = obstaculos.ToList () [Random.Range (0, obstaculos.Count)];
		return obstaculo.gameObject;
	}
}
