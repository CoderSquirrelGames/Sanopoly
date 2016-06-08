using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
public class GameController : MonoBehaviour
{


    public GameObject Spaces, PlayerObjs;
    int NumberOfPlayers = 2;
    public GameObject[] PlayersPrefabs;
    int PlayerTurn = 0;
    public PlayerController CurrentPlayer;
    public List<PlayerController> Players;
    bool PlayerSet;
    public List<CardController> Chances;
    public List<CardController> CommunityChest;
    public CanvasController CanvasCtrl;


    void Awake()
    {

    }
    void Start()
    {
        Players = new List<PlayerController>();
        GeneratePlayers();
        SetCanvasPlayer();
        CurrentPlayer = Players[PlayerTurn];
        PlayerSet = true;
    }

    void Update()
    {
        if (!CurrentPlayer.IsPlayerPlaying && !PlayerSet)
        {
            SetPlayerTurn();
        }
    }
    void GeneratePlayers()
    {

        for (int i = 0; i < NumberOfPlayers; i++)
        {
            GameObject obj = (GameObject)Instantiate(PlayersPrefabs[i]);
            obj.transform.parent = PlayerObjs.transform;
            Players.Add(obj.GetComponent<PlayerController>());
        }
    }


    public void SetPlayerTurn()
    {
        PlayerSet = true;
        ClearCanvas();
        if (PlayerTurn < NumberOfPlayers - 1)
        {
            PlayerTurn++;
            
        }
        else
        {
            PlayerTurn = 0;
        }
        CurrentPlayer = Players[PlayerTurn];
        if (CurrentPlayer.OnJail)
        {
            SetPlayerTurn();
        }
        SetCanvasPlayer();
    }





    public void AfterMove()
    {

        //   int spaceNumber = Players[PlayerTurn].CurrentSpace;
        int spaceNumber = CurrentPlayer.CurrentSpace;
        //Debug.Log(spaceNumber);
        //Debug.Log(CanvasCtrl + " " + CanvasCtrl.ActionText + " " + spaceNumber + " " + GameDictionary.SpaceName[spaceNumber]);
        //CanvasCtrl.ActionText.text = GameDictionary.SpaceName[spaceNumber];




        PlacesController placeCtrl = Spaces.transform.GetChild(spaceNumber).GetComponent<PlacesController>();
        CanvasCtrl.ActionText.text = placeCtrl.GetName();

        if (GameDictionary.SpaceName[spaceNumber].Equals("Community Chest"))
        {
            CanvasCtrl.ActiveButton(3);
        }
        else if (GameDictionary.SpaceName[spaceNumber].Equals("Jail"))
        {
            ChangePlayer();
        }
        else if (GameDictionary.SpaceName[spaceNumber].Equals("Chance"))
        {
            CanvasCtrl.ActiveButton(2);
        }
        else if (GameDictionary.SpaceName[spaceNumber].Equals("Community Chest"))
        {
            CanvasCtrl.ActiveButton(3);
        }
        else if (placeCtrl.Owner == null)
        {
            CanvasCtrl.ValueText.text = placeCtrl.BuyPrice.ToString();
            CanvasCtrl.ActiveButton(0);
        }
        else
        {
            if (placeCtrl.Owner != CurrentPlayer)
            {
                CanvasCtrl.ValueText.text = placeCtrl.GetRent().ToString();
                CanvasCtrl.ActiveButton(1);
            }
            else
            {
                ChangePlayer();
            }
        }



        //  SetPlayerTurn();
        // PlayerSet = false;
    }

    void SetCanvasPlayer()
    {
        CanvasCtrl.PlayerText.text = "Player " + (PlayerTurn + 1);


        //CanvasCtrl.TN1.text = Players[PlayerTurn].Money[0, 1].ToString();
        //CanvasCtrl.TN5.text = Players[PlayerTurn].Money[1, 1].ToString();
        //CanvasCtrl.TN10.text = Players[PlayerTurn].Money[2, 1].ToString();
        //CanvasCtrl.TN20.text = Players[PlayerTurn].Money[3, 1].ToString();
        //CanvasCtrl.TN50.text = Players[PlayerTurn].Money[4, 1].ToString();
        //CanvasCtrl.TN100.text = Players[PlayerTurn].Money[5, 1].ToString();
        //CanvasCtrl.TN500.text = Players[PlayerTurn].Money[6, 1].ToString();
        CanvasCtrl.TTotal.text = Players[PlayerTurn].AllMoney.ToString();

    }

    public void SetPlayerStep(int amount)
    {
        Players[PlayerTurn].SetStep(amount);
    }

    public void PlayerBuy()
    {
        // Players[PlayerTurn].Buy();
        CurrentPlayer.Buy();
        CanvasCtrl.TTotal.text = CurrentPlayer.AllMoney.ToString();
    }


    public void PlayerPay()
    {
        //        Debug.Log("PlayerPay");
        //   Players[PlayerTurn].Pay();
        CurrentPlayer.Pay();
        CanvasCtrl.TTotal.text = CurrentPlayer.AllMoney.ToString();
    }


    public void PlayerChance()
    {
        int chanceNumber = Random.Range(0, Chances.Count);
        CanvasCtrl.Card.gameObject.SetActive(true);
        //active = true;
        CanvasCtrl.Card.sprite = Chances[chanceNumber].GetComponent<SpriteRenderer>().sprite;
        CurrentPlayer.Chance(Chances[chanceNumber]);
    }

    public void PlayerCommunity()
    {
        int chestNumber = Random.Range(0, CommunityChest.Count);
        CanvasCtrl.Card.gameObject.SetActive(true);
        //active = true;
        CanvasCtrl.Card.sprite = CommunityChest[chestNumber].GetComponent<SpriteRenderer>().sprite;
        CurrentPlayer.Community(CommunityChest[chestNumber]);
    }

    void ClearCanvas()
    {
        CanvasCtrl.ClearCanvas();
    }

    public void ChangePlayer()
    {
        StartCoroutine(Change());
    }

    IEnumerator Change()
    {
        yield return new WaitForSeconds(3);
        PlayerSet = false;
    }

}
