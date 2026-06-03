using UnityEngine;

public class MoveSelectedObject : MonoBehaviour
{

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            MoveObject();
        }
    }

    void MoveObject()
    {
        if (SelectionManager.SelectedObject == null)
            return;

        Ray ray =
            Camera.main.ScreenPointToRay(
                Input.mousePosition
            );

        if (Physics.Raycast(
            ray,
            out RaycastHit hit))
        {
            if (
                hit.collider.gameObject.layer ==
                LayerMask.NameToLayer("Floor")
            )
            {
                Vector3 newPosition = hit.point;

                newPosition.y = 2f;

                SelectionManager.SelectedObject
                    .transform.position =
                    newPosition;
            }
        }
    }
}