using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private Vector2 boundaries;
    [SerializeField] private GameObject[] obstacles;
    [SerializeField] private float spawnRate;
    private float _timer;
    [HideInInspector] public bool canSpawn;

    private void Update()
    {
        if(canSpawn)
            if (_timer > 0)
                _timer -= Time.deltaTime;
            else SpawnObj();
    }

    void SpawnObj()
    {
        _timer = spawnRate;
        var pos = transform.position;
        pos.x = UnityEngine.Random.Range(boundaries.x, boundaries.y);
        transform.position = pos;
        int i = UnityEngine.Random.Range(0, obstacles.Length - 1);
        Instantiate(obstacles[i],transform.position,quaternion.identity,transform.parent);
    }
}
