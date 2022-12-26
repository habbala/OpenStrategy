using UnityEngine;

[System.Serializable]
public class Unit : MonoBehaviour
{
    public int attack; // Attack value of the unit
    public int defense; // Defense value of the unit
    public int level; // Level of the unit
    public int cost; // Cost of the unit
    public bool isTraining; // Whether the unit is currently being trained
    public bool isReadyToAttack; // Whether the unit is ready to attack
    public int attackRange; // Attack range of the unit

    // Constructor to create a new unit
    public Unit(int attack, int defense, int level, int attackRange)
    {
        this.attack = attack;
        this.defense = defense;
        this.level = level;
        this.isTraining = false;
        this.attackRange = attackRange;
        this.isReadyToAttack = false;
    }

    // Function to update the unit's stats and abilities based on its level
    public void UpdateStats()
    {
        // Increase the unit's attack and defense by 10% for each level
        attack += (int)(attack * 0.1f);
        defense += (int)(defense * 0.1f);
    }

    // Function to set the training status of the unit
    public void SetTrainingStatus(bool isTraining)
    {
        this.isTraining = isTraining;
    }
}
