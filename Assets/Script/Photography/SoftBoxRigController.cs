using UnityEngine;

public class SoftboxRigController : MonoBehaviour
{
    [Header("Rig Parts")]
    public Transform pole;
    public Transform top;
    public Transform lighting;

    [Header("Height")]
    public float heightSpeed = 1f;
    public float minHeight = 0f;
    public float maxHeight = 1f;

    [Header("Rotation")]
    public float panSpeed = 50f;
    public float tiltSpeed = 50f;

    private Vector3 poleStartScale;
    private Vector3 topStartPos;

    private float currentHeight;

    void Start()
    {
        poleStartScale = pole.localScale;
        topStartPos = top.localPosition;
    }

    void Update()
    {
        HandleHeight();
        HandleRotation();
    }

    void HandleHeight()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            currentHeight +=
                heightSpeed *
                Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.E))
        {
            currentHeight -=
                heightSpeed *
                Time.deltaTime;
        }

        currentHeight =
            Mathf.Clamp(
                currentHeight,
                minHeight,
                maxHeight
            );

        Vector3 newScale =
            poleStartScale;

        newScale.y =
            poleStartScale.y +
            currentHeight;

        pole.localScale =
            newScale;

        Vector3 newPos =
            topStartPos;

        newPos.y =
            topStartPos.y +
            currentHeight;

        top.localPosition =
            newPos;
    }

    void HandleRotation()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            lighting.Rotate(
                0,
                -panSpeed * Time.deltaTime,
                0,
                Space.Self
            );
        }

        if (Input.GetKey(KeyCode.X))
        {
            lighting.Rotate(
                0,
                panSpeed * Time.deltaTime,
                0,
                Space.Self
            );
        }

        if (Input.GetKey(KeyCode.R))
        {
            lighting.Rotate(
                -tiltSpeed * Time.deltaTime,
                0,
                0,
                Space.Self
            );
        }

        if (Input.GetKey(KeyCode.F))
        {
            lighting.Rotate(
                tiltSpeed * Time.deltaTime,
                0,
                0,
                Space.Self
            );
        }
    }
}