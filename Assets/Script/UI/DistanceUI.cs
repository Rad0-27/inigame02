using UnityEngine;
using TMPro;

public class DistanceUI : MonoBehaviour
{
    public Transform lightTransform;
    public Transform subjectTransform;

    public TMP_Text distanceText;

    void Update()
    {
        float distance =
            Vector3.Distance(
                lightTransform.position,
                subjectTransform.position
            );

        distanceText.text =
            "Distance to Subject: " +
            distance.ToString("F2") +
            " m";
    }
}