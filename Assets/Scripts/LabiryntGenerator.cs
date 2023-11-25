using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabiryntGenerator : MonoBehaviour
{
    public Texture2D map;
    public ColorPrefabMapping[] mappings;

    public void Generate()
    {
        Clear();
        for(int x=0; x<map.width; x++)
        {
            for(int y=0; y<map.height; y++)
            {
                Color color = map.GetPixel(x, y);
                SpawnSegment(x, y, color);
            }
        }
    }
    void Clear()
    {
        Transform[] children = transform.GetComponentsInChildren<Transform>();

        for(int i=children.Length - 1; i > 0; i--)
        {
            DestroyImmediate(children[i].gameObject);
        }
    }
    public float scale = 10;
    private void SpawnSegment(int x, int y, Color color)
    {
        foreach( var m in mappings )
        {
            if(m.color == color)
            {
                Transform segment = Instantiate(m.prefab, transform).transform;
                Vector3 pos = new Vector3(x, 0, y) * scale;
                segment.localPosition = pos;
            }
        }
    }

    [Serializable]
    public class ColorPrefabMapping
    {
        public Color color;
        public GameObject prefab;
    }
}
