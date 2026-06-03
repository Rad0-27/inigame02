using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    public static GameObject SelectedObject;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SelectObject();
        }
    }

    void SelectObject()
    {
        Ray ray =
            Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.gameObject.layer ==
                LayerMask.NameToLayer("Selectable"))
            {
                SelectableObject selectable =
    hit.collider.GetComponent<SelectableObject>();

                if (selectable != null)
                {
                    SelectedObject =
                        selectable.rootTransform.gameObject;

                    Debug.Log(
                        "Selected: " +
                        SelectedObject.name
                    );
                }

                Debug.Log(
                    "Selected: " +
                    SelectedObject.name
                );
            }
        }
    }
}