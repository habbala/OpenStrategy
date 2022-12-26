using UnityEngine;

public class AttackController : MonoBehaviour
{
    // Reference to the player's resource controller
    private ResourceController resourceController;

    // Start is called before the first frame update
    void Start()
    {
        // Get a reference to the ResourceController script
        resourceController = transform.parent.GetComponentInChildren<ResourceController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player is trying to attack an enemy kingdom
        if (Input.GetKeyDown(KeyCode.A))
        {
            // Check if the player has enough resources to attack
            if (resourceController.HasEnoughResources(50))
            {
                // Attack the enemy kingdom
                AttackEnemy();
            }
        }
    }

    // Function to attack an enemy kingdom
    void AttackEnemy()
    {
        // Deduct the cost of the attack from the player's resources
        resourceController.DeductResources(50);

        // Calculate the outcome of the attack
        int attackPower = CalculateAttackPower();
        int enemyDefense = CalculateEnemyDefense();

        // Check if the attack was successful
        if (attackPower > enemyDefense)
        {
            // Attack was successful
            Debug.Log("Attack successful!");

            // Loot some resources from the enemy kingdom
            int lootedResources = Random.Range(100, 200);
            resourceController.AddResources(lootedResources);
        }
        else
        {
            // Attack was not successful
            Debug.Log("Attack failed.");
        }
    }

    // Function to calculate the player's attack power
    int CalculateAttackPower()
    {
        // Calculate the total attack power of the player's units
        int attackPower = 0;
        foreach (GameObject unit in GameObject.FindGameObjectsWithTag("Unit"))
        {
            attackPower += unit.GetComponent<Unit>().attack;
        }
        return attackPower;
    }

    // Function to calculate the enemy's defense
    int CalculateEnemyDefense()
    {
        // Calculate the total defense of the enemy's units and buildings
        int enemyDefense = 0;
        foreach (GameObject enemyUnit in GameObject.FindGameObjectsWithTag("Enemy Unit"))
        {
            enemyDefense += enemyUnit.GetComponent<Unit>().defense;
        }
        foreach (GameObject enemyBuilding in GameObject.FindGameObjectsWithTag("Enemy Building"))
        {
            enemyDefense += enemyBuilding.GetComponent<Building>().defense;
        }
        return enemyDefense;
    }

    // Function to check if the player is under attack
    public bool IsPlayerUnderAttack()
    {
        // Check if any enemy units are in range of the player's buildings
        foreach (Building building in BuildingController.buildings)
        {
            foreach (Unit enemy in UnitController.enemyUnits)
            {
                if (Vector3.Distance(building.transform.position, enemy.transform.position) <= enemy.attackRange)
                {
                    // The player is under attack
                    return true;
                }
            }
        }

        // The player is not under attack
        return false;
    }

    // Function to check if the enemy is ready to attack
    public bool IsEnemyReadyToAttack()
    {
        // Check if any enemy units are ready to attack
        foreach (Unit enemy in UnitController.enemyUnits)
        {
            if (enemy.isReadyToAttack)
            {
                // The enemy is ready to attack
                return true;
            }
        }

        // The enemy is not ready to attack
        return false;
    }
}

