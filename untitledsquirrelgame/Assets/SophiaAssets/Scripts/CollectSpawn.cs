using UnityEngine;
using System.Collections.Generic;

public class CollectSpawn : MonoBehaviour
{
    [SerializeField] private GameObject[] collectibles;  // NOTE: Assign last 2 in list as rare collectibles (3 acorns + hole)
    public float spawnChance = 0.025f;
    public float rarespawnChance = 0.01f;

    public float rowHeight = 1f;   
    public int rowWidth = 11;
    public float tileSize = 1f;
    public int startX = -6; // note starting shifted 6 units on x-axis

    private int lastSpawnedRow = -1;
    private List<GameObject> activeObjects = new List<GameObject>();

    public void SpawnRowCollectibles(int rowIndex)
    {
        for (int x = 1; x < rowWidth - 1; x++) // skip edges
        {
            if (Random.value < rarespawnChance)
            {
                Vector3 pos = new Vector3(x + startX + 0.5f, rowIndex + 0.5f, 0); // * tileSize, 0);
                GameObject prefab = collectibles[Random.Range(collectibles.Length - 2, collectibles.Length)];
                GameObject obj = Instantiate(prefab, pos, Quaternion.identity);
                activeObjects.Add(obj);
            }

            else if (Random.value < spawnChance)
            {
                Vector3 pos = new Vector3(x + startX + 0.5f, rowIndex + 0.5f, 0); // * tileSize, 0);
                GameObject prefab = collectibles[Random.Range(0, collectibles.Length - 2)];
                GameObject obj = Instantiate(prefab, pos, Quaternion.identity);
                activeObjects.Add(obj);
            }
        }
        lastSpawnedRow = rowIndex;
    }

    public void SpawnRowsUpTo(int targetRow)
    {
        for (int row = lastSpawnedRow + 1; row <= targetRow; row++)
        {
            SpawnRowCollectibles(row);
        }
    }

    public void DespawnBelowCollectibles(int minRow)
    {
        // remove all objects below camera (with some buffer)
        float minY = minRow * rowHeight;  // this is incase set rowHeight is != 1

        for (int i = activeObjects.Count - 1; i >= 0; i--)
        {
            GameObject obj = activeObjects[i];
            if (obj == null || obj.transform.position.y < minY)
            {
                if (obj != null)
                    Destroy(obj);

                activeObjects.RemoveAt(i);
            }
        }
    }

}
