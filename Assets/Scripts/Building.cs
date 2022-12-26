using UnityEngine;

[System.Serializable]
public class Building : MonoBehaviour
{
    public int defense; // Defense value of the building
    public int cost; // Cost of the building

    public bool isUnderConstruction; // Whether the building is currently being constructed

    // Constructor to create a new building
    public Building(int defense, int cost)
    {
        this.defense = defense;
        this.cost = cost;
        this.isUnderConstruction = false;
    }

    // Function to set the construction status of the building
    public void SetConstructionStatus(bool isUnderConstruction)
    {
        this.isUnderConstruction = isUnderConstruction;
    }
}
