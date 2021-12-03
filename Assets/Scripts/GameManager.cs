using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    public int score;
    public int playerHealth;
    private static float m_hBounds = 45.0f;
    private static float m_vBounds = 15.0f; 
    // ENCAPSULATION
    public static float hBounds { get { return m_hBounds; } }
    public static float vBounds { get { return m_vBounds; } }
    [SerializeField] private TextMeshProUGUI m_scoreText;
    [SerializeField] private List<GameObject> m_enemyList = new List<GameObject>();
    public List<GameObject> enemyList { 
        get { return m_enemyList; } 
    }
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI playerHealthText;
    public GameObject gameOverScreen;
    public GameObject player;
    public ParticleSystem playerDeath;
    public ParticleSystem playerDamage;
    public bool isGameOver;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = 100;
        InvokeRepeating("SpawnRandomEnemy", 1, 2);
    }

    public void AddScore(int addPoints)
    {
        score += addPoints;
        scoreText.text = "Score: " + score;
    }

    public void PlayerDamage(int damage)
    {
        playerHealth -= damage;
        playerHealthText.text = "Health: " + playerHealth;

        if(playerHealth == 0)
        {
            GameOver();
        }
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

    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void GameOver()
    {
        isGameOver = true;
        gameOverScreen.SetActive(true);
        playerDeath.Play();
        player.SetActive(false);
        CancelInvoke();
    }
}
