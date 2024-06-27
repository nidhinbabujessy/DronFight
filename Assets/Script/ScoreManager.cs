using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public GameObject[] enemies;  // Array to store enemy GameObjects
    private int enemiesRemaining; // Count of remaining enemies
    private int score = 0;        // Current score

    public TextMeshProUGUI scoreText; // Reference to the TMP Text component
    public GameObject win;

   
    
    void Start()
    {
        enemiesRemaining = enemies.Length;
        UpdateScoreText();
       
    }

    public void EnemyDestroyed()
    {
        enemiesRemaining--;
        score += 100;
        UpdateScoreText();

        if (enemiesRemaining <= 0)
        {
           
            win.SetActive(true);
            Debug.Log("You win!");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            
        }
    } 

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text =  score.ToString();
        }
    }
}
