using UnityEngine;

public class FifthObjectController : MonoBehaviour
{
    private bool objectsPlaced = false;
    private float movementSpeed = 1.0f; // Adjust this value to control the speed of movement

    // Update is called once per frame
    void Update()
    {
        // Check if all four objects are placed
        if (!objectsPlaced)
        {
            if (CheckObjectsPlacement())
            {
                objectsPlaced = true;
                StartMovement();
            }
        }

        // Move the object in the y-axis if objects are placed
        if (objectsPlaced)
        {
            MoveObject();
        }
    }

    bool CheckObjectsPlacement()
    {
        // Implement your logic here to check if all four objects are placed in their determined places
        // Return true if all objects are placed, otherwise return false
        // You can use GameObject.Find or tags to identify the objects and check their positions
        // For example:
        GameObject object1 = GameObject.Find("Statue_Cat (3)");
        GameObject object2 = GameObject.Find("Statue_Cat (4)");
        GameObject object3 = GameObject.Find("Statue_Cat (5)");
        GameObject object4 = GameObject.Find("Statue_Cat (6)");

        // Check if all objects are in their determined places
        bool allPlaced = object1 != null && object2 != null && object3 != null && object4 != null;

        return allPlaced;
    }

    void StartMovement()
    {
        // You can add any additional code here that should execute when all four objects are placed
        Debug.Log("All objects placed! Starting movement...");
    }

    void MoveObject()
    {
        // Move the object in the y-axis
        transform.Translate(Vector3.down * movementSpeed * Time.deltaTime);
    }
}
