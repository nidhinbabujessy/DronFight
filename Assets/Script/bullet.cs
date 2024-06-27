using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 24f;
    [SerializeField] private Rigidbody rb;

    private void OnEnable()
    {
        
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.AddForce(transform.forward * speed, ForceMode.Impulse);
        }
       
        StartCoroutine(DisableAfterTime(3f));
    }

    private void OnDisable()
    {
       
        StopAllCoroutines();
    }

    private void OnCollisionEnter(Collision collision)
    {
        gameObject.SetActive(false);
    }

    private IEnumerator DisableAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }
}
