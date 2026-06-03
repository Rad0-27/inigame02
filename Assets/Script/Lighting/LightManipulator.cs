using UnityEngine;

public class LightManipulator : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 2f;

    [Header("Rotation")]
    public float rotationSpeed = 60f;

    void Update()
    {
        MoveLight();
        RotateLight();
        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("W Ditekan");
        }
        //transform.position += Vector3.right * Time.deltaTime;
    }

    void MoveLight()
    {
        Vector3 moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
            moveDirection += Vector3.forward;

        if (Input.GetKey(KeyCode.S))
            moveDirection += Vector3.back;

        if (Input.GetKey(KeyCode.A))
            moveDirection += Vector3.left;

        if (Input.GetKey(KeyCode.D))
            moveDirection += Vector3.right;

        if (Input.GetKey(KeyCode.Q))
            moveDirection += Vector3.up;

        if (Input.GetKey(KeyCode.E))
            moveDirection += Vector3.down;

        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    void RotateLight()
    {
        float pitch = 0f;
        float yaw = 0f;

        if (Input.GetKey(KeyCode.UpArrow))
            pitch -= 1f;

        if (Input.GetKey(KeyCode.DownArrow))
            pitch += 1f;

        if (Input.GetKey(KeyCode.LeftArrow))
            yaw -= 1f;

        if (Input.GetKey(KeyCode.RightArrow))
            yaw += 1f;

        transform.Rotate(
            pitch * rotationSpeed * Time.deltaTime,
            yaw * rotationSpeed * Time.deltaTime,
            0f,
            Space.Self
        );
    }
}