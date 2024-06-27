using UnityEngine;

public class Steering : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 100f;
    public float mouseSensitivity = 2f;

    private float rotationX = 0f;
    private float rotationY = 0f;

   public void steer()
    {
        // Movement controls
        Vector3 moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            moveDirection += transform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDirection -= transform.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveDirection -= transform.right;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDirection += transform.right;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            moveDirection += transform.up;
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            moveDirection -= transform.up;
        }

        transform.Translate(moveDirection.normalized * moveSpeed * Time.deltaTime, Space.World);

        // Mouse rotation controls
        rotationX += Input.GetAxis("Mouse X") * mouseSensitivity;
        rotationY -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        rotationY = Mathf.Clamp(rotationY, -90f, 90f);

        transform.localRotation = Quaternion.Euler(rotationY, rotationX, 0);
    }
}
