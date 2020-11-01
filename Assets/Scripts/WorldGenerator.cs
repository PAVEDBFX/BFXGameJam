using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator : MonoBehaviour
{

    public float mapRadius;
    public float centreSafeRadius;
    public float outerSafeRadius;

    public GameObject[] easyEnemies;
    public GameObject[] mediumEnemies;
    public GameObject[] hardEnemies;

    public float density = 0.5f;

    private float tileEdge;

    // Start is called before the first frame update
    void Start()
    {
        density /= 1000000;

        float totArea = Mathf.PI * (2 * mapRadius * mapRadius - centreSafeRadius * centreSafeRadius - outerSafeRadius * outerSafeRadius);
        int nTiles = Mathf.CeilToInt(totArea * density);
        tileEdge = mapRadius / Mathf.Sqrt(nTiles);

        for (int i = 0; i < nTiles; i++)
        {
            for (int j = 0; j < nTiles; j++)
            {
                Vector3 tileCentre = new Vector3((i - nTiles/2) * tileEdge, 0, (j - nTiles / 2) * tileEdge);
                float tileRadius = Vector3.Magnitude(tileCentre - Vector3.zero);

                // If we are in the area we can place stuff
                if (tileRadius < mapRadius - outerSafeRadius && tileRadius > centreSafeRadius)
                {
                    GameObject enemy;
                    // Inner third (easy enemies)
                    if (tileRadius < mapRadius / 3)
                    {
                        enemy = easyEnemies[Random.Range(0, easyEnemies.Length - 1)];
                    }
                    // middle third
                    else if (tileRadius < 2 * mapRadius / 3)
                    {
                        enemy = mediumEnemies[Random.Range(0, mediumEnemies.Length - 1)];
                    }
                    // outer third
                    else
                    {
                        enemy = hardEnemies[Random.Range(0, hardEnemies.Length - 1)];
                    }

                    // place and rotate randomly inside the tile
                    float enemyRadius = enemy.transform.localScale.x;
                    Vector3 direction = new Vector3(Random.value, 0, Random.value);
                    direction = direction / direction.magnitude;
                    direction = direction * Random.value * (tileEdge - enemyRadius);

                    enemy = Instantiate(enemy, tileCentre + direction, Quaternion.identity);
                    enemy.transform.LookAt(direction);
                }
            }
        }
    }
}
