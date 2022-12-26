using UnityEngine;
using System.Collections;

public class UnitController : MonoBehaviour
{
    public GameObject unitPrefab; // Prefab for the unit to be recruited
    public float trainingTime; // Time it takes to train the unit

    // Reference to the player's resource controller
    private ResourceController resourceController;

    public static Unit[] units; // Array of units belonging to the player
    public static Unit[] enemyUnits; // Array of units belonging to the enemy

    // Function to reset the units
    public static void ResetUnits()
    {
        // Clear the units and enemy units arrays
        units = new Unit[0];
        enemyUnits = new Unit[0];
    }

    // Function to set the units
    public static void SetUnits(Unit[] units)
    {
        UnitController.units = units;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Get a reference to the ResourceController script
        resourceController = transform.parent.GetComponentInChildren<ResourceController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player is trying to recruit a unit
        if (Input.GetKeyDown(KeyCode.R))
        {
            // Check if the player has enough resources to recruit the unit
            if (resourceController.HasEnoughResources(unitPrefab.GetComponent<Unit>().cost))
            {
                // Recruit a new unit
                RecruitUnit();
            }
        }
    }

    // Function to recruit a new unit
    void RecruitUnit()
    {
        // Create a new unit
        GameObject unit = Instantiate(unitPrefab, transform.position, Quaternion.identity);

        // Deduct the cost of the unit from the player's resources
        resourceController.DeductResources(unit.GetComponent<Unit>().cost);

        // Set the unit's training status to "in progress"
        unit.GetComponent<Unit>().SetTrainingStatus(true);

        // Start the training timer
        StartCoroutine(TrainUnit(unit));
    }

    // Coroutine to handle the training of a unit
    IEnumerator TrainUnit(GameObject unit)
    {
        // Wait for the specified amount of time
        yield return new WaitForSeconds(trainingTime);

        // Set the unit's training status to "complete"
        unit.GetComponent<Unit>().SetTrainingStatus(false);

        // Increase the unit's level
        unit.GetComponent<Unit>().level++;

        // Update the unit's stats and abilities based on its new level
        unit.GetComponent<Unit>().UpdateStats();
    }
}
