using UnityEngine;

public class CameraScroller : MonoBehaviour
{
    public float scrollSpeed = 1f;
    public TilemapBackground background;  
    public CollectSpawn spawner;  // collectibles spawner
    public float rowHeight = 1f;   
    public int rowsAhead = 10;  // how many rows to keep generated ahead
    public int rowsBelow = 5;   // how many rows to keep below camera
    public int buffer = 2;
    public int minRow; 

    private int lastRowGenerated = 0;


    void Start()
    {
        // generate initial rows
        background.GenerateRowsUpTo(rowsAhead);
        lastRowGenerated = rowsAhead;
    }

    void Update()
    {
        // camera moves upward
        transform.position += Vector3.up * scrollSpeed * Time.deltaTime;

        // row the camera has reached
        int currentRow = Mathf.FloorToInt(transform.position.y / rowHeight);  // in case rowHeight != 1

        // if camera moved into a new row, generate more above
        if (currentRow + rowsAhead > lastRowGenerated)
        {
            background.GenerateRowsUpTo(currentRow + rowsAhead);
            spawner.SpawnRowsUpTo(currentRow + rowsAhead);
            lastRowGenerated = currentRow + rowsAhead;
        }

        // deletes rows below camera
        minRow = (currentRow - rowsBelow) - buffer;
        background.DeleteRowsBelow(minRow);  // buffer of 2 rows
        spawner.DespawnBelowCollectibles(minRow); // clean up interactives
    }
}
