using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera orbitCamera;
    public Camera photoCamera;

    bool photoMode = false;

    void Start()
    {
        orbitCamera.enabled = true;
        photoCamera.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            photoMode = !photoMode;

            orbitCamera.enabled = !photoMode;
            photoCamera.enabled = photoMode;
        }
    }
}