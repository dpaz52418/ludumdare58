using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections;

public class TilemapBackground : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase leftEdgeTile;
    public TileBase rightEdgeTile;
    public TileBase middleTile;
    public int rowWidth = 11;
    public int startX = -6; // note starting shifted 6 units on x-axis


    // tracks generated rows
    private int highestRowGenerated = 0;
    private int lowestRowGenerated = 0;


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

                tilemap.SetTile(new Vector3Int(x + startX, rowIndex, 0), tileToPlace);
                // Vector3 worldPos = new Vector3(x + 0.5f, rowIndex + 0.5f, 0);
                // Vector3Int cellPos = tilemap.WorldToCell(worldPos);
                // tilemap.SetTile(cellPos, tileToPlace);

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

    public void DeleteRowsBelow(int minRow)
    {
        for (int y = lowestRowGenerated; y < minRow; y++)
        {
            for (int x = 0; x < rowWidth; x++)
            {
                tilemap.SetTile(new Vector3Int(x + startX, y, 0), null);
                // Vector3 worldPos = new Vector3(x + 0.5f, y + 0.5f, 0);
                // Vector3Int cellPos = tilemap.WorldToCell(worldPos);
                // tilemap.SetTile(cellPos, null);
            }
        }
        lowestRowGenerated = minRow;
    }

}
