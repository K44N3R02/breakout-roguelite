using System.Collections.Generic;
using UnityEngine;

using Random = System.Random;
using Math = System.Math;

public class BlockTilemap : MonoBehaviour, ILevelGenerator
{
    enum Symmetry
    {
        NONE,
        VERTICAL,
        FOUR_WAY,
        ROTATIONAL_180,
        ROTATIONAL_90,
    }
    [SerializeField] private Symmetry symmetry = Symmetry.NONE;
    [SerializeField] private float fillPercent = 0.5f;
    [SerializeField] private int randomSeed = 42;

    private readonly int rows = 8;
    private readonly int columns = 8;

    private float xSpacing;
    private float ySpacing;
    private GameObject[,] objectGrid;
    private bool[,] levelMap;
    private Random random;

    private void Awake()
    {
        objectGrid = new GameObject[rows, columns];
        levelMap = new bool[rows, columns];
        random = new(randomSeed);
    }

    public int GenerateLevel(List<GameObject> tiles, int levelCount, Health.Death onDeath)
    {
        GameObject blockPrefab = tiles[0];
        Vector3 spriteSize = blockPrefab.GetComponent<SpriteRenderer>().bounds.size;
        xSpacing = spriteSize.x;
        ySpacing = spriteSize.y;

        GenerateLevelMap();

        int tileCount = 0;

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                if (!levelMap[row, col])
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

    /// <summary>
    /// Generates a boolean map representing where will blocks be placed.
    /// Fills <code>levelMap</code> instead of returning the map.
    /// </summary>
    private void GenerateLevelMap()
    {
        switch (symmetry)
        {
            case Symmetry.NONE:
                Drunkard(columns, rows);
                break;
            case Symmetry.VERTICAL:
                Drunkard(columns / 2, rows);
                ReflectLevelVertically();
                break;
            case Symmetry.FOUR_WAY:
                Drunkard(columns / 2, rows / 2);
                ReflectLevelHorizontally();
                ReflectLevelVertically();
                break;
            case Symmetry.ROTATIONAL_180:
                Drunkard(columns / 2, rows);
                RotateLevel180();
                break;
            case Symmetry.ROTATIONAL_90:
                Drunkard(columns / 2, rows / 2);
                RotateLevel90();
                break;
        }
    }

    private void ReflectLevelVertically()
    {
        for (int i = 0; i < columns / 2; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                levelMap[j, columns - i - 1] = levelMap[j, i];
            }
        }
    }

    private void ReflectLevelHorizontally()
    {
        for (int i = 0; i < columns; i++)
        {
            for (int j = 0; j < rows / 2; j++)
            {
                levelMap[rows - j - 1, i] = levelMap[j, i];
            }
        }
    }

    private void RotateLevel180()
    {
        for (int i = 0; i < columns / 2; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                levelMap[rows - j - 1, columns - i - 1] = levelMap[j, i];
            }
        }
    }

    private void RotateLevel90()
    {
        for (int i = 0; i < columns / 2; i++)
        {
            for (int j = 0; j < rows / 2; j++)
            {
                levelMap[i, rows - j - 1] = levelMap[rows - j - 1, columns - i - 1] = levelMap[columns - i - 1, j]  = levelMap[j, i];
            }
        }
    }

    /// <summary>
    /// Fills <code>levelMap</code> partially using Drunkard's walk until <code>fillPercent</code> is reached.
    /// </summary>
    /// <param name="cols">How many columns to fill</param>
    /// <param name="rows">How many rows to fill</param>
    private void Drunkard(int cols, int rows)
    {
        var (x, y) = (random.Next(cols), random.Next(rows));
        levelMap[y, x] = true;
        int filled = 1;

        while (filled < cols * rows * fillPercent)
        {
            (int, int)[] directions = { (1, 0), (-1, 0), (0, 1), (0, -1) };
            var (dx, dy) = directions[random.Next(4)];
            x = Math.Clamp(x + dx, 0, cols - 1);
            y = Math.Clamp(y + dy, 0, rows - 1);
            if (!levelMap[y, x])
            {
                filled++;
            }
            levelMap[y, x] = true;
        }
    }
}
