using UnityEngine;

public class LightingEquipment : MonoBehaviour
{
    [Header("Rig Parts")]
    public Transform pole;
    public Transform top;
    public Transform lighting;

    [Header("Movement")]
    public float moveSpeed = 2f;

    [Header("Height")]
    public float heightSpeed = 1f;
    public float minHeight = 0f;
    public float maxHeight = 1f;

    [Header("Rotation")]
    public float panSpeed = 50f;
    public float tiltSpeed = 50f;

    public float currentHeight;

    [Header("Pole")]
    public float poleScaleMultiplier = 70f;

    [Header("Lighting")]

    public LightRole role;

    public float lumenOutput = 5000f;

    public enum LightRole
    {
        Key,
        Fill,
        Back,
        Rim,
        Hair,
        Background
    }

    Vector3 poleStartScale;
    Vector3 topStartPos;

    void Start()
    {
        poleStartScale = pole.localScale;
        topStartPos = top.localPosition;
    }

    void Update()
    {
        if (
            SelectionManager.SelectedObject
            != gameObject
        )
        {
            return;
        }

        HandleMovement();
        HandleHeight();
        HandleRotation();
    }

    void HandleMovement()
    {
        Vector3 move = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
            move += Vector3.forward;

        if (Input.GetKey(KeyCode.S))
            move += Vector3.back;

        if (Input.GetKey(KeyCode.A))
            move += Vector3.left;

        if (Input.GetKey(KeyCode.D))
            move += Vector3.right;

        transform.position +=
            move *
            moveSpeed *
            Time.deltaTime;
    }

    void HandleHeight()
    {
        if (Input.GetKey(KeyCode.Q))
            currentHeight +=
                heightSpeed *
                Time.deltaTime;

        if (Input.GetKey(KeyCode.E))
            currentHeight -=
                heightSpeed *
                Time.deltaTime;

        currentHeight =
            Mathf.Clamp(
                currentHeight,
                minHeight,
                maxHeight
            );

        Vector3 scale =
            poleStartScale;

        scale.z =
            poleStartScale.z +
            (currentHeight * poleScaleMultiplier);

        pole.localScale =
            scale;

        Vector3 pos =
            topStartPos;

        pos.y =
            topStartPos.y +
            currentHeight;

        top.localPosition =
            pos;
    }

    void HandleRotation()
    {
        // Pan (Z Axis)

        if (Input.GetKey(KeyCode.Z))
        {
            top.Rotate(
                0,
                0,
                -panSpeed *
                Time.deltaTime,
                Space.Self
            );
        }

        if (Input.GetKey(KeyCode.X))
        {
            top.Rotate(
                0,
                0,
                panSpeed *
                Time.deltaTime,
                Space.Self
            );
        }

        // Tilt (Y Axis)

        if (Input.GetKey(KeyCode.F))
        {
            lighting.Rotate(
                0,
                -tiltSpeed *
                Time.deltaTime,
                0,
                Space.Self
            );
        }

        if (Input.GetKey(KeyCode.R))
        {
            lighting.Rotate(
                0,
                tiltSpeed *
                Time.deltaTime,
                0,
                Space.Self
            );
        }
    }
}