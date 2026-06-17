using UnityEngine;

public class OrbitCameraController : MonoBehaviour
{
    public Transform target;

    public float orbitSpeed = 100f;
    public float zoomSpeed = 5f;
    public float minDistance = 1f;
    public float maxDistance = 15f;

    private Camera cam;

    void Start()
    {
        cam = GetComponentInChildren<Camera>();
    }

    void Update()
    {
        Orbit();
        Zoom();
    }

    void Orbit()
    {
        if (Input.GetMouseButton(1))
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            transform.RotateAround(
                target.position,
                Vector3.up,
                mouseX * orbitSpeed * Time.deltaTime
            );

            transform.RotateAround(
                target.position,
                transform.right,
                -mouseY * orbitSpeed * Time.deltaTime
            );
        }
    }

    void Zoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (scroll != 0)
        {
            Vector3 direction =
                (cam.transform.localPosition).normalized;

            float currentDistance =
                cam.transform.localPosition.magnitude;

            currentDistance -= scroll * zoomSpeed;

            currentDistance =
                Mathf.Clamp(
                    currentDistance,
                    minDistance,
                    maxDistance
                );

            cam.transform.localPosition =
                direction * currentDistance;

            Debug.Log(currentDistance);
        }
    }
}