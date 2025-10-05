using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapBackground : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase leftEdgeTile;
    public TileBase rightEdgeTile;
    public TileBase middleTile;
    public int rowWidth = 11;

    // Tracks how far background has been generated
    private int highestRowGenerated = 0;

    public void GenerateRow(int rowIndex)
    {
        for (int x = 0; x < rowWidth; x++)
            {
                TileBase tileToPlace;
                if (x == 0)
                    tileToPlace = leftEdgeTile;          // left border
                else if (x == rowWidth - 1)
                    tileToPlace = rightEdgeTile;         // right border
                else
                    tileToPlace = middleTile;            // same tile in the middle

                tilemap.SetTile(new Vector3Int(x - 6, rowIndex, 0), tileToPlace);
            }
        highestRowGenerated = Mathf.Max(highestRowGenerated, rowIndex);
    }

    public void GenerateRowsUpTo(int targetRow)
    {
        for (int i = highestRowGenerated + 1; i <= targetRow; i++)
        {
            GenerateRow(i);
        }
    }
}
