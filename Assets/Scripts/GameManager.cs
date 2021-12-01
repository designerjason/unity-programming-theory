using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private static float m_hBounds = 45.0f;
    private static float m_vBounds = 15.0f; 
    public static float hBounds { get { return m_hBounds; } }
    public static float vBounds { get { return m_vBounds; } }
    [SerializeField] private TextMeshProUGUI m_scoreText;
    [SerializeField] private List<GameObject> m_enemyList = new List<GameObject>();
    public List<GameObject> enemyList { 
        get { return m_enemyList; } 
    }
    public TextMeshProUGUI scoreText {
        get { return m_scoreText; }
        set { m_scoreText = scoreText; }
    }

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy(enemyList[2]);
        InvokeRepeating("SpawnRandomEnemy", 1, 2);
    }

    // randomise the spawned enemy
    public void SpawnRandomEnemy()
    {
        int randomEnemy = Random.Range(0, enemyList.Count);
        SpawnEnemy(enemyList[randomEnemy]);
    }

    // spawn an enemy
    public static void SpawnEnemy(GameObject enemyType)
    {
        Vector3 spawnPos;
        float range = (enemyType.name == "Plane"? vBounds : hBounds);
        float randomRange = Random.Range(-range, range);

        if(enemyType.name == "Plane")
        {
            spawnPos = new Vector3(60f, 10, randomRange);
        } else {
            spawnPos = new Vector3(randomRange, 0, -35f);    
        }
        
        Instantiate(enemyType, spawnPos, enemyType.transform.rotation);
    }
}
