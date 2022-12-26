using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    // Reference to the player's attack controller
    private AttackController attackController;

    // Start is called before the first frame update
    void Start()
    {
        // Get a reference to the AttackController script
        attackController = transform.parent.GetComponentInChildren<AttackController>();
    }

    // Update is called once per frame
    //void Update()
    //{
    //    // Check if the player has been attacked
    //    if (attackController.IsPlayerUnderAttack())
    //    {
    //        // Display a notification on the UI
    //        DisplayNotification("Enemy attack incoming!");
    //    }

    //    // Check if an enemy kingdom is ready to be attack
    //    if (attackController.IsEnemyReadyToAttack())
    //    {
    //        // Display a notification on the UI
    //        DisplayNotification("Enemy kingdom is ready to attack!");
    //    }
    //}

    // Function to display a notification on the UI
    void DisplayNotification(string message)
    {
        // Update the text element on the UI to show the notification message
        GameObject.Find("Notification Text").GetComponent<Text>().text = message;
    }
}
