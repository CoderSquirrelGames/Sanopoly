using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class GameDictionary : MonoBehaviour
{
    /// <summary>
    /// Recieve from the bank, collect from each player
    /// </summary>
    public enum TypeOfAction
    {
        Advance, AdvanceUtility, AdvanceRailRoad, Pay, Collect, Receive, OutOfJail, GoBack, GoDirectly, Repair
    }
    public enum TypeOfProperty
    {
        Brown, LightBlue, Pink, Orange, Red, Yellow, Green, DarkBlue, Stations, Utilities, Chest, Chance, Tax, Jail, Free, Go

    }
    public static Dictionary<int, string> SpaceName;
    private string[] Spaces;

    void Awake()
    {
        SpaceName = new Dictionary<int, string>();
        Spaces = new string[] { "GO", "Mediterranean Avenue", "Community Chest", "Baltic Avenue", "Income Tax", "Reading Railroad", "Oriental Avenue", "Chance", "Vermont Avenue", "Connecticut Avenue", "Jail", "St. Charles Place", "Electric Company", "States Avenue", "Virginia Avenue", "Pennsylvania Railroad", "St. James Place", "Community Chest", "Tennessee Avenue", "New York Avenue", "Free", "Kentucky Avenue", "Chance", "Indiana Avenue", "Illinois Avenue", "B. & O. Railroad", "Atlantic Avenue", "Ventnor Avenue", "Water Works", "Marvin Gardens", "Go To Jail", "Pacific Avenue", "North Carolina Avenue", "Community Chest", "Pennsylvania Avenue", "Short Line", "Chance", "Park Place", "Luxury Tax", "Boardwalk" };
        LoadSpaceName();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    void LoadSpaceName()
    {
        for (int i = 0; i < Spaces.Length; i++)
        {
            SpaceName.Add(i, Spaces[i]);
        }
    }


}
