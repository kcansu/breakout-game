using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public Block[] blockPrefabs;

    public Vector2Int size;
    public Vector2 offset;

    public float topOffset = -1f;

    private void Awake()
    {
        Camera cam = Camera.main;
        Vector2 screenTopCenter = cam.ViewportToWorldPoint(new Vector2(0.5f, 1f)); //top center of screen

        float totalWidth = (size.x - 1) * offset.x;
        float totalHeight = (size.y - 1) * offset.y;

        float startX = screenTopCenter.x - totalWidth / 2f;
        float startY = screenTopCenter.y + topOffset;

        for (int x = 0; x < size.x; x++)
        {
            for (int y = 0; y < size.y; y++)
            {
                Block randomBlock = blockPrefabs[Random.Range(0, blockPrefabs.Length)];

                if (randomBlock.prefab == null)
                {
                    Debug.LogWarning($"{randomBlock.name} prefab is missing");
                    continue;
                }

                GameObject newBlock = Instantiate(randomBlock.prefab, transform);

                float posX = startX + x * offset.x;
                float posY = startY - y * offset.y; 
                newBlock.transform.position = new Vector2(posX, posY);
            }
        }
    }
}


