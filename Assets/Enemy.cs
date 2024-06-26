using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string bulletTag = "Bullet"; // Tag of the bullet GameObject

    private ScoreManager scoreManager;

    void Start()
    {
        scoreManager = GameObject.FindObjectOfType<ScoreManager>(); // Find ScoreManager
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(bulletTag))
        {
            Destroy(gameObject); // Destroy the enemy
            scoreManager.EnemyDestroyed(); // Notify ScoreManager
        }
    }
}
