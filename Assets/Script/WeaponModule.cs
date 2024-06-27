using Cinemachine;
using UnityEngine;

public class WeaponModule : MonoBehaviour
{
    public GameObject projectile;
    public Transform firePoint;
    public float fireForce = 10f;

    public bool shoot = true;
   
    public void Shoot()
    {

        GameObject bullet = ObjectPool.instance.GetPooledObject();
        if (bullet != null && shoot==true)
        {
            bullet.transform.position = firePoint.position;
            bullet.transform.rotation = firePoint.rotation;
            bullet.SetActive(true);

            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero; 
                rb.angularVelocity = Vector3.zero; 
                rb.AddForce(firePoint.forward * fireForce, ForceMode.Impulse);
            }
        }


    }
}
