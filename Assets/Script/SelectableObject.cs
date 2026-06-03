using UnityEngine;

public class SelectableObject : MonoBehaviour
{
    public Transform rootTransform;

    Renderer rend;

    Color originalColor;

    void Start()
    {
        rend = GetComponentInChildren<Renderer>();

        if (rend != null)
        {
            originalColor =
                rend.material.color;
        }
    }

    void Update()
    {
        if (SelectionManager.SelectedObject ==
            gameObject)
        {
            if (rend != null)
                rend.material.color = Color.yellow;
        }
        else
        {
            if (rend != null)
                rend.material.color = originalColor;
        }
    }
}