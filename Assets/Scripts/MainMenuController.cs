using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MainMenuController : MonoBehaviour
{

    public Text Arrows;
    public List<Text> Options;
    private string[] Players = new string[4];
    int Selected;
    int NumberOfPlayers = 0;
    int Level = 0;
    private bool IsPlayerSelected { get { return Selected == 1; } }

    // Use this for initialization
    void Start()
    {
        PlayerPrefs.SetInt("HIGHSCORE", 0);
        Players[0] = "1 PLAYER";
        Players[1] = "2 PLAYERS";
        Players[2] = "3 PLAYERS";
        Players[3] = "4 PLAYERS";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (Selected == 0)
            {

                PlayerPrefs.SetInt("P1SCORE", 0);
                PlayerPrefs.SetInt("P2SCORE", 0);
                PlayerPrefs.SetInt("PLAYERS", NumberOfPlayers);
                PlayerPrefs.SetInt("LEVEL", Level);
                Application.LoadLevel("LevelsScene");
            }
            else if (Selected == 3)
            {
                Application.LoadLevel("ControlsScene");
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {

            if (Selected > 0)
            {
                Selected--;
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {

            if (Selected < Options.Count - 1)
            {
                Selected++;
            }
            
            //Selected = Selected < Options.Count-1 ? Selected++ : Options.Count-1;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

            if (IsPlayerSelected)
            {
                if (NumberOfPlayers - 1 > -1)
                {
                    NumberOfPlayers--;
                    Options[1].text = Players[NumberOfPlayers];
                }
            }

        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {

            if (IsPlayerSelected)
            {
                if (NumberOfPlayers + 1 < Players.Length)
                {
                    NumberOfPlayers++;

                    Options[1].text = Players[NumberOfPlayers];
                }
            }
        }

        Arrows.transform.position = Options[Selected].transform.position;
    }

}
