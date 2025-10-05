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
        int currentRow = Mathf.FloorToInt(transform.position.y / rowHeight);

        // if camera moved into a new row, generate more above
        if (currentRow + rowsAhead > lastRowGenerated)
        {
            background.GenerateRowsUpTo(currentRow + rowsAhead);
            lastRowGenerated = currentRow + rowsAhead;
        }
    }
}
