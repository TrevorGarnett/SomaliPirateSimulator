using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class GridManager : MonoBehaviour
{
    [SerializeField] private int _width, _height;
    [SerializeField] private Tile _tilePrefab;
    [SerializeField] private Transform _cam;

    private Dictionary<Vector2, Tile> _tiles;

    void Start()
    {
        generateGrid();
    }

    void generateGrid()
    {
        _tiles = new Dictionary<Vector2, Tile>();
        _tilePrefab.transform.localScale = new Vector3((float)1/_width * 17.77405f, (float)1/_height * 9);
        
        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                var spawnedTile = Instantiate(_tilePrefab, new Vector3((float)x / _width * 17.77405f, (float)y / _height * 9), Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";

                spawnedTile.Init((x+y)%2==0);

                _tiles[new Vector2(x, y)] = spawnedTile;
            }
        }
        
        _cam.transform.position = new Vector3(8.86592f, 4.955f,-10);
    }

    public Tile GetTileAtPosition(Vector2 pos)
    {
        if (_tiles.TryGetValue(pos, out var tile)) 
            return tile;
        return null;
    }
}
