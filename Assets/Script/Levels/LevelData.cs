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
    public float targetAngle;
    public float targetExposure;

    [Header("Scoring")]
    public float passScore = 80f;
}