using UnityEngine;

[CreateAssetMenu(
    fileName = "NewLevelData",
    menuName = "Lighting Simulator/Level Data")]
public class LevelData : ScriptableObject
{
    [Header("Level Info")]
    public string levelName;

    [Header("Reference")]
    public Sprite referenceImage;

    [Header("Target Values")]
    public float targetDistance = 1.5f;
    public float targetAngle = 45f;
    public float targetEV = 10f;

    [Header("Tolerance")]
    public float distanceTolerance = 0.3f;
    public float angleTolerance = 10f;
    public float evTolerance = 0.5f;

    [Header("Scoring")]
    public float passScore = 80f;
}