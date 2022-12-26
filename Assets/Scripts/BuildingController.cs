using UnityEngine;
using System.Collections;

public class BuildingController : MonoBehaviour
{
    public GameObject buildingPrefab; // Prefab for the building to be placed
    public float buildTime; // Time it takes to construct the building

    // Reference to the player's resource controller
    private ResourceController resourceController;

    public static Building[] buildings; // Array of buildings belonging to the player

    // Function to reset the buildings
    public static void ResetBuildings()
    {
        // Clear the buildings array
        buildings = new Building[0];
    }

    // Function to set the buildings
    public static void SetBuildings(Building[] buildings)
    {
        BuildingController.buildings = buildings;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Get a reference to the ResourceController script
        resourceController = GetComponent<ResourceController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player is trying to place a building
        if (Input.GetMouseButtonDown(0))
        {
            // Get the position of the mouse cursor
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Check if the player has enough resources to place the building
            if (resourceController.HasEnoughResources(buildingPrefab.GetComponent<Building>().cost))
            {
                // Place the building at the mouse position
                PlaceBuilding(mousePos);
            }
        }
    }

    // Function to place a building at a given position
    void PlaceBuilding(Vector2 position)
    {
        // Create a new building at the given position
        GameObject building = Instantiate(buildingPrefab, position, Quaternion.identity);

        // Deduct the cost of the building from the player's resources
        resourceController.DeductResources(building.GetComponent<Building>().cost);

        // Set the building's construction status to "in progress"
        building.GetComponent<Building>().SetConstructionStatus(true);

        // Start the construction timer
        StartCoroutine(ConstructBuilding(building));
    }

    // Coroutine to handle the construction of a building
    IEnumerator ConstructBuilding(GameObject building)
    {
        // Wait for the specified amount of time
        yield return new WaitForSeconds(buildTime);

        // Set the building's construction status to "complete"
        building.GetComponent<Building>().SetConstructionStatus(false);
    }
}
