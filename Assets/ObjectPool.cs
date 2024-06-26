using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;
    private List<GameObject> pooledObjects = new List<GameObject>();
    [SerializeField] private GameObject bullet;
    [SerializeField] private int initialAmount = 20;
    [SerializeField] private TMP_Text bulletCountText;

    void Awake()
    {
        // Ensure there is only one instance of the ObjectPool
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Initialize the pool with the initial amount of bullets
        for (int i = 0; i < initialAmount; i++)
        {
            AddBulletToPool();
        }

        // Update the bullet count UI at the start
        UpdateBulletCountUI();
    }

    // Method to get an inactive bullet from the pool
    public GameObject GetPooledObject()
    {
        foreach (GameObject obj in pooledObjects)
        {
            if (!obj.activeInHierarchy)
            {
                UpdateBulletCountUI();
                return obj;
            }
        }

        // If no inactive bullet is found, add a new one to the pool and return it
        GameObject newBullet = AddBulletToPool();
        UpdateBulletCountUI();
        return newBullet;
    }

    // Method to add a new bullet to the pool
    private GameObject AddBulletToPool()
    {
        GameObject obj = Instantiate(bullet);
        obj.SetActive(false);
        pooledObjects.Add(obj);
        return obj;
    }

    // Method to update the bullet count UI
    private void UpdateBulletCountUI()
    {
        int activeBulletCount = 0;
        foreach (GameObject obj in pooledObjects)
        {
            if (obj.activeInHierarchy)
            {
                activeBulletCount++;
            }
        }
        bulletCountText.text = activeBulletCount + "/" + pooledObjects.Count;
    }
}
