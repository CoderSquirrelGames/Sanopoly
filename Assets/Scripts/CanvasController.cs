using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
public class CanvasController : MonoBehaviour
{
    public Sprite[] DiceFaces;
    GameController GameCtrl;
    int DiceValue1, DiceValue2;
    public Image Dice1, Dice2, Card;
    public Text PlayerText, ActionText, ValueText;
    public Text TN1, TN5, TN10, TN20, TN50, TN100, TN500, TTotal;
    public Button BuyBt, PayBt;
    public List<Button> Buttons;

    void Awake()
    {
        Card.gameObject.SetActive(false);
        foreach (Button bt in Buttons)
        {
            bt.gameObject.SetActive(false);
        }
        GameCtrl = Camera.main.GetComponent<GameController>();
    }


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TTotal.text = GameCtrl.CurrentPlayer.AllMoney.ToString();
    }




    public void Buy()
    {
        Buttons[0].enabled = false;
        GameCtrl.PlayerBuy();
    }

    public void Pay()
    {
        //        Debug.Log("Pay Rent");
        Buttons[1].enabled = false;
        GameCtrl.PlayerPay();
    }
    public void Chance()
    {
        Buttons[2].enabled = false;
        GameCtrl.PlayerChance();
    }

    public void Community()
    {
        Buttons[3].enabled = false;
        GameCtrl.PlayerCommunity();
    }





    public void RollTheDices()
    {
        if (!GameCtrl.CurrentPlayer.IsPlayerPlaying)
        {
            DiceValue1 = Random.Range(1, 7);
            Dice1.sprite = DiceFaces[DiceValue1 - 1];
            DiceValue2 = Random.Range(1, 7);
            Dice2.sprite = DiceFaces[DiceValue2 - 1];

          //  GameCtrl.SetPlayerStep((DiceValue1 + DiceValue2));
           GameCtrl.SetPlayerStep(2);
        }

    }

    public int RollDiceRent()
    {
        DiceValue1 = Random.Range(1, 7);
        Dice1.sprite = DiceFaces[DiceValue1 - 1];
        DiceValue2 = Random.Range(1, 7);
        Dice2.sprite = DiceFaces[DiceValue2 - 1];

        return (DiceValue1 + DiceValue2);
    }

    public void ActiveButton(int b)
    {
        DeactiveButtons();

        Buttons[b].gameObject.SetActive(true);

    }


    void DeactiveButtons()
    {
        foreach (Button bt in Buttons)
        {
            bt.gameObject.SetActive(false);
            bt.enabled = true;
        }
    }

    public void ClearCanvas()
    {
        Card.gameObject.SetActive(false);
        ActionText.text = "";
        ValueText.text = "";
        DeactiveButtons();
    }
}
