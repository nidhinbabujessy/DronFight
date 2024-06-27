using UnityEngine;

public class FlightPropulsion : MonoBehaviour
{
    public float hoverHeight = 5f;
    public float hoverForce = 10f;
    public float damping = 5f; 

    private Rigidbody rb;

    

    public void Hover()
    {
        rb = GetComponent<Rigidbody>();

        if (rb == null) return;

        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, hoverHeight))
        {
            float proportionalHeight = (hoverHeight - hit.distance) / hoverHeight;
            Vector3 appliedHoverForce = Vector3.up * proportionalHeight * hoverForce;

            // Apply damping to stabilize the hovering effect
            Vector3 dampingForce = -rb.velocity * damping;

            rb.AddForce(appliedHoverForce + dampingForce, ForceMode.Acceleration);

           
        }
        
    }
}
