using UnityEngine;
using UnityEngine.UI;

public class ResourceController : MonoBehaviour
{
    public int startingGold; // Starting amount of gold for the player
    public int startingWood; // Starting amount of wood for the player

    private int currentGold; // Current amount of gold for the player
    private int currentWood; // Current amount of wood for the player

    // Function to reset the resources
    public void ResetResources()
    {
        currentGold = 0;
        currentWood = 0;
    }

    // Function to set the resources
    public void SetResources(int gold, int wood)
    {
        currentGold = gold;
        currentWood = wood;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Set the player's starting resource levels
        currentGold = startingGold;
        currentWood = startingWood;
    }

    // Update is called once per frame
    void Update()
    {
        // Update the resource display on the UI
        UpdateResourceDisplay();
    }

    // Function to check if the player has enough resources to perform a certain action
    public bool HasEnoughResources(int cost)
    {
        // Check if the player has enough gold and wood to afford the cost
        return currentGold >= cost && currentWood >= cost;
    }

    // Function to add resources to the player's resource pool
    public void AddResources(int amount)
    {
        currentGold += amount;
        currentWood += amount;
    }

    // Function to deduct resources from the player's resource pool
    public void DeductResources(int amount)
    {
        currentGold -= amount;
        currentWood -= amount;
    }

    // Function to update the resource display on the UI
    void UpdateResourceDisplay()
    {
        // Update the text elements on the UI to show the current resource levels
        GameObject.Find("Gold Text").GetComponent<Text>().text = "Gold: " + currentGold;
        GameObject.Find("Wood Text").GetComponent<Text>().text = "Wood: " + currentWood;
    }
}
