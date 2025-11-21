using UnityEngine;

public class BlockTilemap : MonoBehaviour
{
    [SerializeField] private GameObject blockPrefab;
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

    private void Start()
    {
        rows = 8;
        columns = 8;
        Vector3 spriteSize = blockPrefab.GetComponent<SpriteRenderer>().bounds.size;
        xSpacing = spriteSize.x;
        ySpacing = spriteSize.y;
        objectGrid = new GameObject[rows, columns];


        CreateGrid();
    }

    // private void OnDrawGizmos()
    // {
    //     if (objectGrid == null)
    //     {
    //         Vector3 spriteSize = blockPrefab.GetComponent<SpriteRenderer>().bounds.size;
    //         xSpacing = spriteSize.x;
    //         ySpacing = spriteSize.y;
    //         objectGrid = new GameObject[rows, columns];
    //     }
    //     CreateGrid();
    // }

    private void CreateGrid()
    {
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

                objectGrid[row, col] = newObject;
            }
        }
    }
}
