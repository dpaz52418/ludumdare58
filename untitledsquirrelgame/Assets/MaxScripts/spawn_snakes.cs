using UnityEngine;

public class spawn_snakes : MonoBehaviour
{

    public GameObject snake_prefab; // assign in Inspector

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector3 spawnPos = new Vector3(2f, 3f, 0f);
        Quaternion spawnRot = Quaternion.identity; // no rotation
        GameObject clone = Instantiate(snake_prefab, spawnPos, spawnRot);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
