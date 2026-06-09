using UnityEngine;

public class SelectableObject : MonoBehaviour
{
    public GameObject selectionIndicator;

    void Update()
    {
        bool selected =
            SelectionManager.SelectedObject ==
            gameObject;

        if (selectionIndicator != null)
        {
            selectionIndicator.SetActive(
                selected
            );
        }
    }
}