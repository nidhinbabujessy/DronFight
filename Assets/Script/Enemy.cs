using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string bulletTag = "Bullet";

    private ScoreManager scoreManager;

    void Start()
    {
        scoreManager = GameObject.FindObjectOfType<ScoreManager>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(bulletTag))
        {
            Destroy(gameObject); 
            scoreManager.EnemyDestroyed();
        }
    }
}
