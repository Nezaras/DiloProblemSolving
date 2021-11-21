using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject Circle;
    public GameObject coin;
    private Dictionary<string, GameObject> keyValuePairs = new Dictionary<string, GameObject>();
    public Transform Canvas;
    public float spawnInterval = .2f;
    private int totalSpawnedcoin = 0;

    private void Start()
    {
        InvokeRepeating("CoinPooling", spawnInterval, spawnInterval);
    }

    private void CoinPooling()
    {
        for (int i = 0; i < keyValuePairs.Count; i++)
        {
            if (keyValuePairs.ContainsKey($"coin {i}"))
            {
                GameObject objToSpawn = keyValuePairs[$"coin {i}"].gameObject;

                if (!objToSpawn.activeSelf)
                {
                    Vector2 point = GetOutsideCircleRadiusPoint();

                    objToSpawn.transform.localPosition = new Vector3(point.x, point.y);
                    objToSpawn.SetActive(true);

                    return;
                }
            }
        }

        InstantiateCoin();
    }

    private void InstantiateCoin()
    {
        GameObject spawnedcoin = Instantiate(coin, Canvas);
        spawnedcoin.name = $"coin {totalSpawnedcoin}";
        totalSpawnedcoin++;
        keyValuePairs.Add(spawnedcoin.name, spawnedcoin);

        RectTransform coinRectTransform = spawnedcoin.GetComponent<RectTransform>();

        Vector2 point = GetOutsideCircleRadiusPoint();

        int randomcoinSizeX = Random.Range(10, 25);
        int randomcoinSizeY = Random.Range(10, 25);

        Vector2 randomedPosition = new Vector2(point.x, point.y);
        Vector2 randomedSize = new Vector2(randomcoinSizeX, randomcoinSizeY);

        coinRectTransform.localPosition = randomedPosition;
        coinRectTransform.sizeDelta = randomedSize;
    }

    private Vector2 GetOutsideCircleRadiusPoint()
    {
        float areaSize = 70;
        float offset = 120;

        float ratio = areaSize / offset;
        float radius = Mathf.Sqrt(Random.Range(ratio * ratio, 1f)) * offset;

        Vector2 circlePosition = new Vector2(Circle.transform.position.x, Circle.transform.position.y);
        Vector3 point = (circlePosition + Random.insideUnitCircle.normalized) * radius;

        if (point.x > 120)
        {
            point.x = Random.Range(-offset, areaSize);
            point.y = Random.Range(-120, 120);
        }
        else if (point.x < -120)
        {
            point.x = Random.Range(-areaSize, offset);
            point.y = Random.Range(-120, 120);
        }

        if (point.y > 120)
        {
            point.x = Random.Range(-120, 120);
            point.y = Random.Range(-offset, areaSize);
        }
        else if (point.y < -120)
        {
            point.x = Random.Range(-120, 120);
            point.y = Random.Range(-areaSize, offset);
        }

        return point;
    }
}
