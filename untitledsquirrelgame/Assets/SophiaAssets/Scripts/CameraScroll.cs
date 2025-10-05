// using UnityEngine;

// public class CameraScroller : MonoBehaviour
// {
//     public float scrollSpeed = 1f;
//     public Vector2 direction = Vector2.up;

//     void Update()
//     {
//         // moves camera continuously in the chosen direction (up)
//         transform.position += (Vector3)(direction.normalized * scrollSpeed * Time.deltaTime);
//     }
// }

using UnityEngine;

public class CameraScroller : MonoBehaviour
{
    public float scrollSpeed = 1f;

    public TilemapBackground background;  
    public float rowHeight = 1f;   
    public int rowsAhead = 10;  // how many rows to keep generated ahead
    public int rowsBelow = 5;   // how many rows to keep below camera
    private int lastRowGenerated = 0;
    public int buffer = 2;


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
            lastRowGenerated = currentRow + rowsAhead;
        }

        // deletes rows below camera
        background.DeleteRowsBelow((currentRow - rowsBelow) - buffer);  // buffer of 2 rows
        //spawner.DespawnBelowRow((currentRow - rowsBelow) - buffer); // clean up interactives
    }
}
