using UnityEngine;

public class SceneRotator : MonoBehaviour
{
    public float rotationSpeed = 1f;
    public float rotationSensitivity = 0.5f;

    private Vector3 lastMousePosition;

    void Update()
    {
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
        else
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);
        }
    }
}
