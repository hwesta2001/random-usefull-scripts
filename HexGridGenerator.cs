using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexGridGenerator : MonoBehaviour
{
    [SerializeField] GameObject hexPrefab;
    [SerializeField] int mapWidht = 25;
    [SerializeField] int mapHeight = 12;
    [SerializeField] float tileXOffset = 1.75f;
    [SerializeField] float tileZOffset = 1.525f;
    [SerializeField] float tileHight = 0.875f;

    [SerializeField] List<GameObject> hexes = new();

    //private void Start()
    //{
    //    CreateHexGrid();
    //}


    [ContextMenu("ClearAndCreate")]
    void ClearAndCreate()
    {
        ClearHexes();
        CreateHexGrid();
    }


    [ContextMenu("ClearHexes")]
    void ClearHexes()
    {
        if (transform.childCount > 0)
        {
            hexes.Clear();
            foreach (Transform hex in transform)
            {
                hexes.Add(hex.gameObject);
            }
        }
        foreach (var item in hexes)
        {
            DestroyImmediate(item);
        }
        hexes.Clear();
    }


    void CreateHexGrid()
    {
        hexes.Clear();
        //tileZOffset = 3 * tileXOffset * .5f / Mathf.Sqrt(3);
        for (int x = 0; x < mapWidht; x++)
        {
            for (int z = 0; z < mapHeight; z++)
            {
                GameObject tempGo = Instantiate(hexPrefab);
                tempGo.transform.parent = transform;
                hexes.Add(tempGo);
                if (z % 2 == 0)
                {
                    tempGo.transform.localPosition = new Vector3(x * tileXOffset, 0, z * tileZOffset);
                }
                else
                {
                    tempGo.transform.localPosition = new(x * tileXOffset + tileHight, 0, z * tileZOffset);
                }
            }
        }
    }
}
