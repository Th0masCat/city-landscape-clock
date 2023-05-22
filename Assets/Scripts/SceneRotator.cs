using UnityEngine;

public class SceneRotator : MonoBehaviour
{
    public float rotationSpeed = 1f;
    public float rotationSensitivity = 0.5f;

    private Vector3 lastMousePosition;

    void Update()
    {
        // Rotate the scene based on the mouse movement
        if (Input.GetMouseButtonDown(0))
        {
            lastMousePosition = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition - lastMousePosition;
            float rotationY = -delta.x * rotationSpeed * rotationSensitivity;

            transform.Rotate(Vector3.up, rotationY, Space.World);

            lastMousePosition = Input.mousePosition;
        }
        // Normal Rotation
        else
        {
            transform.Rotate(Vector3.up, 2 * Time.deltaTime, Space.World);
        }
    }
}
