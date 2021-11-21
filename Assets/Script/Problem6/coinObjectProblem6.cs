using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinObjectProblem6 : MonoBehaviour
{
    public GameObject Coin;

    public int coinMax = 5;
    public int coinMin = 1;

    public int coinCurrentMax;

    public Transform xPoint;
    public Transform yPoint;
    public float offset = 0f;

    private float _xRadius;
    private float _yRadius;

    private void Awake()
    {
        _xRadius = xPoint.position.x;
        _yRadius = yPoint.position.y;
    }

    // Start is called before the first frame update
    private void Start()
    {
        coinCurrentMax = Random.Range(coinMin, coinMax);
        for (int i = 0; i < coinCurrentMax; i++)
            SpawnPickup(_xRadius, _yRadius);
    }

    private void SpawnPickup(float x, float y)
    {
        Instantiate(Coin, RandomSpawnPosition(x, y), Quaternion.identity);
    }

    private Vector2 RandomSpawnPosition(float x, float y)
    {
        return new Vector2(Random.Range(-x - offset, x + offset), Random.Range(-y - offset, y + offset));
    }
}
