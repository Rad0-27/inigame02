using UnityEngine;

public class ExposureCalculator : MonoBehaviour
{
    public LightRig lightRig;
    public CameraSettings cameraSettings;

    public Transform lightTransform;
    public Transform subjectTransform;

    [HideInInspector]
    public float exposureValue;

    void Update()
    {
        CalculateExposure();
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
        Debug.Log(exposureValue);
    }
}