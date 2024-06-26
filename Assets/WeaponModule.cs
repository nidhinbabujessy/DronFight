using Cinemachine;
using UnityEngine;

public class WeaponModule : MonoBehaviour
{
    public GameObject projectile;
    public Transform firePoint;
    public float fireForce = 10f;

  
   
    public void Shoot()
    {

        GameObject bullet = ObjectPool.instance.GetPooledObject();
        if (bullet != null)
        {
            bullet.transform.position = firePoint.position;
            bullet.transform.rotation = firePoint.rotation;
            bullet.SetActive(true);

            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero; // Reset velocity to avoid carrying over from previous use
                rb.angularVelocity = Vector3.zero; // Reset angular velocity
                rb.AddForce(firePoint.forward * fireForce, ForceMode.Impulse);
            }
        }


    }
}
