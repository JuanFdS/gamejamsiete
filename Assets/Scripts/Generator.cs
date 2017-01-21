using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Random = System.Random;

[Serializable]
public class ObstacleGenerator
{
    public IObstaculo obstaculo;

    public int spawnPercetange;
}


public class Generator : MonoBehaviour
{
    [Serializable]
    public struct Difficulty
    {
        public float difficultyIncreaser;

        public float metersPerObstacle;

        public float minMetersPerObstacle;
    }

    public Difficulty difficulty;

    public Pulpito player;

    public List<ObstacleGenerator> obstaculos;

    private int totalWeight;

    public int minY;

    public int maxY;

    public int offsetX;

    public int lifeTime;

    private float distanceTravelled;

    void Start()
    {
        obstaculos = obstaculos.OrderByDescending(x => x.spawnPercetange).ToList();
        totalWeight = obstaculos.Sum(x => x.spawnPercetange);
    }

    void Update()
    {
        distanceTravelled += player.DistanceTraveledInFrame();
        Debug.Log(distanceTravelled);
        if (distanceTravelled > difficulty.metersPerObstacle)
        {
            SpawnObstacle();
            difficulty.metersPerObstacle = difficulty.metersPerObstacle < difficulty.minMetersPerObstacle
                ? difficulty.minMetersPerObstacle
                : difficulty.metersPerObstacle - difficulty.difficultyIncreaser;
            distanceTravelled = 0;
        }
    }

    private void SpawnObstacle()
    {
        var obstacle = Instantiate(GetNextObstacle(), GetNextPosition(), Quaternion.identity);
        obstacle.GetComponent<IObstaculo>().Initialize(GetNextLine());
        Destroy(obstacle, lifeTime);
    }

    private Vector3 GetNextPosition()
    {
        var xPosition = player.transform.position.x + offsetX;
        return new Vector3(xPosition, 0, 0);
    }

    private GlobalConfig.ColorsToLines GetNextLine()
    {
        return GlobalConfig.Instance.RandomColorToNon3DLine();
    }

    private GameObject GetNextObstacle()
    {
        var rnd = new Random().Next(0, totalWeight);
        foreach (var item in obstaculos)
        {
            if (rnd < item.spawnPercetange)
                return item.obstaculo.gameObject;
            rnd -= item.spawnPercetange;
        }
        return obstaculos.Last().obstaculo.gameObject;
    }
}
