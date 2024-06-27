using UnityEngine;
using TMPro;

public class DroneFuelManager : MonoBehaviour
{
    public float maxFuel = 300f; 
    private float currentFuel;
    public TMP_Text fuelText; 
   

    private WeaponModule weaponModule;
    void Start()
    {
        currentFuel = maxFuel;
        UpdateFuelUI();
        weaponModule = GetComponent<WeaponModule>();
    }

    void Update()
    {
        if (currentFuel > 0)
        {
           
            currentFuel -= Time.deltaTime;
            UpdateFuelUI();

           
            if (currentFuel <= 0)
            {
               
                currentFuel = 0;
               
               
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }

    void UpdateFuelUI()
    { 
        
        float fuelPercentage = (currentFuel / maxFuel) * 100f;
        
        fuelText.text =  Mathf.CeilToInt(fuelPercentage) + "%";
    }
}
