using TMPro;
using UnityEngine;

public class LightingEvaluator : MonoBehaviour
{
    public Transform lightTransform;
    public Transform subjectTransform;

    public TMP_Text AngleT;

    public float currentAngle;

    void Update()
    {
        Vector3 direction =
            lightTransform.position -
            subjectTransform.position;

        direction.y = 0f;

        currentAngle =
            Mathf.Abs(
                Vector3.SignedAngle(
                    Vector3.forward,
                    direction,
                    Vector3.up
                )
            );

        AngleT.text =
            "Angle: " +
            currentAngle.ToString("F1");
        /*
        Debug.Log(
            "Current Angle: " +
            angle.ToString("F1")
        );
        */
    }
}