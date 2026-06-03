using UnityEngine;

public class LightingEvaluator : MonoBehaviour
{
    public Transform lightTransform;
    public Transform subjectTransform;

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

        Debug.Log(
            "Current Angle: " +
            angle.ToString("F1")
        );
    }
}