using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameManager : MonoBehaviour
{
    public enum GameMode { Singleplayer, Multiplayer } // Enum to define the different gameplay modes

    // Reference to the player's resource controller
    private ResourceController resourceController;

    public GameMode gameMode; // Current gameplay mode

    // Start is called before the first frame update
    void Start()
    {
        // Get a reference to the ResourceController script
        resourceController = transform.parent.GetComponentInChildren<ResourceController>();

        // Start a new game in the specified gameplay mode
        //StartNewGame(gameMode);
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player is trying to start a new game
        if (Input.GetKeyDown(KeyCode.N))
        {
            // Start a new game in the current gameplay mode
            StartNewGame(gameMode);
        }

        // Check if the player is trying to load a saved game
        if (Input.GetKeyDown(KeyCode.L))
        {
            // Load the saved game
            LoadSavedGame();
        }
    }

    // Function to start a new game
    void StartNewGame(GameMode mode)
    {
        // Set the gameplay mode
        gameMode = mode;

        // Reset all relevant game data and objects
        ResetGameData();

        // Load the appropriate scene for the gameplay mode
        if (gameMode == GameMode.Singleplayer)
        {
            SceneManager.LoadScene("Singleplayer Scene");
        }
        else if (gameMode == GameMode.Multiplayer)
        {
            SceneManager.LoadScene("Multiplayer Scene");
        }
    }

    // Function to reset all relevant game data and objects
    void ResetGameData()
    {
        // Reset the player's resource levels
        resourceController.ResetResources();

        // Reset the player's units and buildings
        UnitController.ResetUnits();
        BuildingController.ResetBuildings();
    }

    // Function to load a saved game
    void LoadSavedGame()
    {
        // Load the saved game data
        GameData data = SaveLoad.Load();

        // Set the gameplay mode based on the saved data
        gameMode = data.gameMode;

        // Load the appropriate scene for the gameplay mode
        if (gameMode == GameMode.Singleplayer)
        {
            SceneManager.LoadScene("Singleplayer Scene");
        }
        else if (gameMode == GameMode.Multiplayer)
        {
            SceneManager.LoadScene("Multiplayer Scene");
        }

        // Restore the game data from the saved data
        RestoreGameData(data);
    }

    // Function to restore the game data from the saved data
    void RestoreGameData(GameData data)
    {
        // Set the player's resource levels based on the saved data
        resourceController.SetResources(data.gold, data.wood);

        // Set the player's units and buildings based on the saved data
        UnitController.SetUnits(data.units);
        BuildingController.SetBuildings(data.buildings);
    }

    // Static class for saving and loading game data
    public static class SaveLoad
    {
        // Function to save the game data to a file
        public static void Save(GameData data)
        {
            // Create a binary formatter for serializing the data
            BinaryFormatter formatter = new BinaryFormatter();

            // Create a file to save the data to
            string path = Application.persistentDataPath + "/game.sav";
            FileStream stream = new FileStream(path, FileMode.Create);

            // Serialize the data and save it to the file
            formatter.Serialize(stream, data);
            stream.Close();
        }

        // Function to load the game data from a file
        public static GameData Load()
        {
            // Create a binary formatter for deserializing the data
            BinaryFormatter formatter = new BinaryFormatter();

            // Create a file to load the data from
            string path = Application.persistentDataPath + "/game.sav";
            FileStream stream;

            // Check if the file exists
            if (File.Exists(path))
            {
                stream = new FileStream(path, FileMode.Open);

                // Deserialize the data from the file and return it
                return (GameData)formatter.Deserialize(stream);
            }
            else
            {
                // Return null if the file does not exist
                return null;
            }
        }
    }
}
