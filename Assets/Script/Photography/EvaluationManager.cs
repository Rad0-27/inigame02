using TMPro;
using UnityEngine;

public class EvaluationManager : MonoBehaviour
{
    [Header("References")]
    public LightingEvaluator lightingEvaluator;
    public ExposureCalculator exposureCalculator;
    public LevelManager levelManager;

    [Header("UI")]
    public TMP_Text resultText;

    public GameObject resultPanelW;
    public GameObject resultPanelL;

    public void EvaluatePhoto()
    {
        LevelData level =
            levelManager.currentLevel;

        float directionScore =
            CalculateDirectionScore(
                lightingEvaluator.currentAngle,
                level.targetAngle
            );

        float exposureScore =
            CalculateExposureScore(
                exposureCalculator.exposureEV,
                level.targetEV
            );

        float finalScore =
            (directionScore + exposureScore) * 0.5f;

        string result =
            finalScore >= level.passScore
            ? "PASS"
            : "FAIL";

        if (result == "PASS")
        {
            resultPanelW.SetActive(true);
        }
        else
        {
            resultPanelL.SetActive(true);
        }

        resultText.text =
            "Direction : " + directionScore.ToString("F0") +
            "\nExposure : " + exposureScore.ToString("F0") +
            "\nFinal : " + finalScore.ToString("F0") +
            "\n" +
            result;
    }

    float CalculateDirectionScore(
        float current,
        float target)
    {
        float difference =
            Mathf.Abs(current - target);

        float score =
            Mathf.Clamp(
                100f - (difference * 2f),
                0f,
                100f
            );

        return score;
    }

    float CalculateExposureScore(
        float currentEV,
        float targetEV)
    {
        float difference =
            Mathf.Abs(currentEV - targetEV);

        float score =
            Mathf.Clamp(
                100f - (difference * 50f),
                0f,
                100f
            );

        return score;
    }
}