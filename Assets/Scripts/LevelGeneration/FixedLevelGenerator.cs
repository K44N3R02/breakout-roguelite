using System.Collections.Generic;
using UnityEngine;

public class FixedLevelGenerator : MonoBehaviour, ILevelGenerator
{
    private int rows;
    private int columns;

    private float xSpacing;
    private float ySpacing;
    private GameObject[,] objectGrid;
    private bool[,] blockMap = { { false, true, true, false, true, false, true, true },
                                 { false, true, true, false, true, false, true, true },
                                 { false, true, true, false, true, false, true, true },
                                 { false, true, true, false, true, false, true, true },
                                 { false, true, true, false, true, false, true, true },
                                 { false, true, true, false, true, false, true, true },
                                 { false, true, true, false, true, false, true, true },
                                 { false, true, true, false, true, false, true, true } };

    private void Awake()
    {
        rows = 8;
        columns = 8;
        objectGrid = new GameObject[rows, columns];
    }

    public int GenerateLevel(List<GameObject> tiles, int levelCount, Health.Death onDeath)
    {
        GameObject blockPrefab = tiles[0];

        Vector3 spriteSize = blockPrefab.GetComponent<SpriteRenderer>().bounds.size;
        xSpacing = spriteSize.x;
        ySpacing = spriteSize.y;

        int tileCount = 0;

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                if (!blockMap[row, col])
                {
                    continue;
                }

                float xPos = transform.position.x + (col + 0.5f) * xSpacing;
                float yPos = transform.position.y - (row + 0.5f) * ySpacing;

                Vector3 spawnPosition = new(xPos, yPos, 0f);
                GameObject newObject = Instantiate(blockPrefab, spawnPosition, Quaternion.identity);

                newObject.name = $"GridObject ({row}, {col})";

                newObject.transform.SetParent(transform);
                newObject.GetComponent<Health>().OnDeath += onDeath;

                objectGrid[row, col] = newObject;

                tileCount++;
            }
        }

        return tileCount;
    }
}
