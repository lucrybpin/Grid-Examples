using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager2D : MonoBehaviour
{
    [SerializeField] private int width, height;
    [SerializeField] private Tile2D tilePrefab;

    [SerializeField] private Transform camera;

    private Dictionary<Vector2, Tile2D> tiles = new Dictionary<Vector2, Tile2D>();


    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Tile2D spawnedTile = Instantiate(tilePrefab, new Vector3(x, y), Quaternion.identity);
                spawnedTile.gameObject.name = $"Tile {x} {y}";

                bool isOffset = (x % 2 == 0 && y % 2 == 0) || (x % 2 != 0 && y % 2 != 0);
                spawnedTile.Create(isOffset);

                tiles[new Vector2(x, y)] = spawnedTile;
            }
        }

        Debug.Log(GetTileAtPosition(new Vector3(1, 0)), GetTileAtPosition(new Vector3(1, 0)).gameObject);

        camera.transform.position = new Vector3(((float)width / 2) - 0.5f, ((float)height / 2) - 0.5f, -8.4f);
    }

    public Tile2D GetTileAtPosition(Vector2 pos)
    {
        if (tiles.TryGetValue(pos, out Tile2D tile))
        {
            return tile;
        }
        return null;
    }
}
