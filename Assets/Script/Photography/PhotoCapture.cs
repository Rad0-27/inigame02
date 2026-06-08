using UnityEngine;

public class PhotoCapture : MonoBehaviour
{
    int photoIndex = 0;

    public EvaluationManager evaluationManager;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakePhoto();
        }
    }

    void TakePhoto()
    {
        string fileName =
            "Photo_" +
            photoIndex +
            ".png";

        ScreenCapture.CaptureScreenshot(fileName);

        Debug.Log(
            "Photo Captured: " +
            fileName
        );
        evaluationManager.EvaluatePhoto();
        photoIndex++;
    }
}