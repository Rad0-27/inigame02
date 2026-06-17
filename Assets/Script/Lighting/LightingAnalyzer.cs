using TMPro;
using UnityEngine;

public class LightingAnalyzer : MonoBehaviour
{
    [Header("References")]

    public LightingEquipment[] lights;

    public CameraSettings cameraSettings;

    public Transform subject;

    [Header("UI")]

    public TMP_Text distanceText;

    public TMP_Text angleText;

    public TMP_Text exposureText;

    [Header("Current Values")]

    public float currentDistance;

    public float currentAngle;

    public float exposureLux;

    public float exposureEV;

    [Header("Target")]

    public float targetLux = 1200f;

    public float targetDistance = 1.5f;

    public float distanceTolerance = 0.3f;

    public float targetAngle = 45f;

    public float angleTolerance = 10f;

    public float exposureTolerance = 0.3f;

    public bool IsDistanceCorrect;

    public bool IsAngleCorrect;

    public bool IsExposureCorrect;

    public float CurrentDistance => currentDistance;

    public float CurrentAngle => currentAngle;

    public float CurrentExposure => exposureEV;

    public LevelData currentLevel;

    void Update()
    {
        if (lights == null || lights.Length == 0)
            return;

        CalculateDistance();

        CalculateAngle();

        CalculateExposure();

        Evaluate();

        UpdateUI();
    }

    void CalculateDistance()
    {
        currentDistance =
            Vector3.Distance(
                lights[0].lighting.position,
                subject.position
            );
    }

    void CalculateAngle()
    {
        Vector3 direction =
            lights[0].lighting.position -
            subject.position;

        direction.y = 0f;

        currentAngle =
            Mathf.Abs(
                Vector3.SignedAngle(
                    Vector3.forward,
                    direction,
                    Vector3.up
                )
            );
    }

    void CalculateExposure()
    {
        float totalLux = 0f;

        foreach (LightingEquipment light in lights)
        {
            float distance =
                Vector3.Distance(
                    light.lighting.position,
                    subject.position
                );

            distance = Mathf.Max(distance, 0.1f);

            float lux =
                1000f /
                (distance * distance);

            totalLux += lux;
        }

        exposureLux = totalLux;

        float aperture =
            cameraSettings.Aperture;

        float shutter =
            1f /
            cameraSettings.ShutterSpeed;

        float iso =
            cameraSettings.ISO;

        exposureEV =
            Mathf.Log(
                (aperture * aperture) /
                shutter,
                2
            )
            -
            Mathf.Log(
                iso / 100f,
                2
            );
    }

    void Evaluate()
    {
        IsDistanceCorrect =
            Mathf.Abs(
                currentDistance -
                currentLevel.targetDistance)
            <=
            currentLevel.distanceTolerance;

        IsAngleCorrect =
            Mathf.Abs(
                currentAngle -
                currentLevel.targetAngle)
            <=
            currentLevel.angleTolerance;

        float exposureError =
            Mathf.Abs(
                exposureLux -
                targetLux
            ) / targetLux;

        IsExposureCorrect =
            Mathf.Abs(
                exposureEV -
                currentLevel.targetEV)
            <=
            currentLevel.evTolerance;
    }

    void UpdateUI()
    {
        if (distanceText != null)
            distanceText.text =
                "Distance : "
                + currentDistance.ToString("F2")
                + " m";

        if (angleText != null)
            angleText.text =
                "Angle : "
                + currentAngle.ToString("F1")
                + "°";

        if (exposureText != null)
            exposureText.text =
                "Lux : "
                + exposureLux.ToString("F0");
    }
}