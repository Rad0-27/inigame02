using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ExposureCalculator : MonoBehaviour
{
    public LightRig lightRig;
    public CameraSettings cameraSettings;

    public Transform lightTransform;
    public Transform subjectTransform;

    public float targetExposure = 1200f;

    public TMP_Text ExText;

    [HideInInspector]
    public float exposureValue;

    [HideInInspector]
    public float exposureEV;

    void Update()
    {
        CalculateExposure();
        ExText.text =
            "EV : " +
            exposureEV.ToString("F2");
    }

    void CalculateExposure()
    {
        float distance =
            Vector3.Distance(
                lightTransform.position,
                subjectTransform.position
            );

        distance =
            Mathf.Max(distance, 0.1f);

        float lightContribution =
            lightRig.lumenOutput /
            (distance * distance);

        float cameraContribution =
            cameraSettings.ISO /
            100f;

        cameraContribution *=
            (5.6f / cameraSettings.Aperture);

        cameraContribution *=
            (125f / cameraSettings.ShutterSpeed);

        exposureValue =
            lightContribution *
            cameraContribution;
        //Debug.Log(exposureValue);

        exposureEV =
            Mathf.Log(
        exposureValue /
        targetExposure,
        2f
        );
    }
}