using UnityEngine;
using System.Collections.Generic;

public class CollectSpawn : MonoBehaviour
{
    public GameObject[] collectibles;
    public float spawnChance = 0.1f;
    public float rowHeight = 1f;   
    public int rowWidth = 11;
    public float tileSize = 1f;

    private int lastSpawnedRow = -1;
    private List<GameObject> activeObjects = new List<GameObject>();

    public void SpawnRow(int rowIndex)
    {
        for (int x = 1; x < rowWidth - 1; x++) // skip edges
        {
            if (Random.value < spawnChance)
            {
                Vector3 pos = new Vector3(x + 0.5f, rowIndex * tileSize + 0.5f, 0);
                GameObject prefab = collectibles[Random.Range(0, collectibles.Length)];
                GameObject obj = Instantiate(prefab, pos, Quaternion.identity);
                activeObjects.Add(obj);
            }
        }
        lastSpawnedRow = rowIndex;
    }

    public void DespawnBelowRow(int minRow)
    {
        // remove all objects below camera (with some buffer)

        // activeObjects.RemoveAll(obj =>
        // {
        //     if (obj == null) return true;
        //     if (obj.transform.position.y < minRow * tileSize)
        //     {
        //         Destroy(obj);
        //         return true;
        //     }
        //     return false;
        // });

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
