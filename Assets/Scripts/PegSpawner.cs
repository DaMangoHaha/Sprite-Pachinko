using UnityEngine;

public class PegSpawner : MonoBehaviour
{
    public GameObject pegPrefab;
    public int rows = 5;
    public int columns = 8;
    public float spacing = 1f;

    void Start()
    {
        
        float gridWidth = columns * spacing;
        float gridHeight = rows * spacing;

        
        Vector3 spawnPosition = new Vector3(-gridWidth / 2 + spacing / 2, gridHeight / 2 - spacing / 2, 0);

        
        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < columns; x++)
            {
                float offset = (y % 2 == 0) ? 0 : spacing / 2;
                Vector3 pos = spawnPosition + new Vector3(x * spacing + offset, -y * spacing, 0);
                Instantiate(pegPrefab, pos, Quaternion.identity, transform);
            }
        }
    }
}
