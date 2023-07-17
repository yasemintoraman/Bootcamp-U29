using UnityEngine;

public class DragDrop : MonoBehaviour
{
    private Vector3 offset;
    public string destinationTag = "Area";
    private Vector3 initialPosition;
    private bool isDragging = false;

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void OnMouseDown()
    {
        if (!isDragging)
        {
            isDragging = true;
            Vector3 mousePosition = MouseWorldPosition();
            offset = transform.position - mousePosition;
            transform.GetComponent<Collider>().enabled = false;
        }
    }

    private void OnMouseDrag()
    {
        if (isDragging)
        {
            transform.position = MouseWorldPosition() + offset;
        }
    }

    private void OnMouseUp()
    {
        if (isDragging)
        {
            isDragging = false;
            var rayOrigin = Camera.main.transform.position;
            var rayDirection = MouseWorldPosition() - Camera.main.transform.position;
            RaycastHit hitInfo;
            if (Physics.Raycast(rayOrigin, rayDirection, out hitInfo))
            {
                if (hitInfo.transform.tag == destinationTag)
                {
                    Vector3 newPosition = hitInfo.transform.position;
                    newPosition.y = initialPosition.y;
                    transform.position = newPosition;
                }
                else
                {
                    // If the raycast hits an object but not the destination object, reset the position to the initial position
                    transform.position = initialPosition;
                }
            }
            else
            {
                // If the raycast doesn't hit any object, reset the position to the initial position
                transform.position = initialPosition;
            }
            transform.GetComponent<Collider>().enabled = true;
        }
    }

    private Vector3 MouseWorldPosition()
    {
        var mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mouseScreenPos);
    }
}