using UnityEngine;

[System.Serializable]
public class GameData
{
    public int gold; // Player's current gold level
    public int wood; // Player's current wood level
    public GameManager.GameMode gameMode; // Current gameplay mode
    public Unit[] units; // Array of units belonging to the player
    public Building[] buildings; // Array of buildings belonging to the player

    // Constructor to create a new game data object
    public GameData(int gold, int wood, GameManager.GameMode gameMode, Unit[] units, Building[] buildings)
    {
        this.gold = gold;
        this.wood = wood;
        this.gameMode = gameMode;
        this.units = units;
        this.buildings = buildings;
    }
}
