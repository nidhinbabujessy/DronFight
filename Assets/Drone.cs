using System;
using UnityEngine;

public class Drone : MonoBehaviour
{
    private FlightPropulsion propulsion;
    private Steering steering;
    private WeaponModule weapon;

    void Start()
    {
        propulsion = GetComponent<FlightPropulsion>();
        steering = GetComponent<Steering>();
        weapon = GetComponent<WeaponModule>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update() 
    {

        steering.steer();
        propulsion.Hover();

        if (Input.GetButtonDown("Fire1"))
        {
            weapon.Shoot();
        }



        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Unlock and show the cursor when Escape is pressed
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
   
}
