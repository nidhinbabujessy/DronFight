using UnityEngine;
using TMPro;

public class DroneFuelManager : MonoBehaviour
{
    public float maxFuel = 300f; // 5 minutes in seconds
    private float currentFuel;
    public TMP_Text fuelText; // Assign the UI Text component in the Inspector
    public GameObject fail;
    void Start()
    {
        currentFuel = maxFuel;
        UpdateFuelUI();
    }

    void Update()
    {
        if (currentFuel > 0)
        {
            // Decrease fuel over time
            currentFuel -= Time.deltaTime;
            UpdateFuelUI();

            // Check if the fuel has run out
            if (currentFuel <= 0)
            {
                currentFuel = 0;
                // Here you can add any logic you want when the drone runs out of fuel
                fail.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }

    void UpdateFuelUI()
    { 
        // Calculate the remaining fuel percentage
        float fuelPercentage = (currentFuel / maxFuel) * 100f;
        // Update the UI Text with the remaining fuel percentage
        fuelText.text =  Mathf.CeilToInt(fuelPercentage) + "%";
    }
}
