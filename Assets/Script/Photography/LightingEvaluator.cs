using TMPro;
using UnityEngine;

public class LightingEvaluator : MonoBehaviour
{
    public Transform lightTransform;
    public Transform subjectTransform;

    public TMP_Text AngleT;

    void Update()
    {
        Vector3 direction =
            lightTransform.position -
            subjectTransform.position;

        direction.y = 0f;

        float angle =
            Vector3.SignedAngle(
                Vector3.forward,
                direction,
                Vector3.up
            );

        AngleT.text =
            "Current Angle: " +
            angle.ToString("F1");
        /*
        Debug.Log(
            "Current Angle: " +
            angle.ToString("F1")
        );
        */
    }
}