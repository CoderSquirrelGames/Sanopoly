using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : ParentController
{
    public int CurrentSpace = 0, NextSpace;
    public List<int> Owned;
    GameObject Spaces;
    Vector3 MovePosition;
    public bool OnJail = false;
    public bool HaveJailCard = false;

    //public int[,] Money = new int[7, 2];
    protected override void Awake()
    {
        base.Awake();
        Owned = new List<int>();

        //Money[0, 0] = 1;
        //Money[1, 0] = 5;
        //Money[2, 0] = 10;
        //Money[3, 0] = 20;
        //Money[4, 0] = 50;
        //Money[5, 0] = 100;
        //Money[6, 0] = 500;

        //Money[0, 1] = 5; Money[1, 1] = 5; Money[2, 1] = 5;
        //Money[3, 1] = 6;
        //Money[4, 1] = 2; Money[5, 1] = 2; Money[6, 1] = 2;

        GameCtrl = Camera.main.GetComponent<GameController>();
        Spaces = GameCtrl.Spaces;
        MovePosition = transform.position;
    }



    public void SetStep(int amount)
    {
        // PlayerPlaying = true;
        Transform t = null;
        NextSpace = CurrentSpace + amount;

        if (NextSpace > 39)
        {
            if (NextSpace == 30)
            {
                OnJail = true;
            }

            else
            {
                t = Spaces.transform.GetChild((NextSpace - 40));
            }
        }
        else { t = Spaces.transform.GetChild(NextSpace); }


        MovePosition = t.position;
        StartCoroutine(TestRouteFollow());
    }



    IEnumerator TestRouteFollow()
    {
        yield return new WaitForSeconds(2);
        while (transform.position != MovePosition)
        {
            if (CurrentSpace < 39)
                CurrentSpace++;

            else
                CurrentSpace = 0;

            if (CurrentSpace == 0)
            {

                ChangeMoney(0, 200);


            }
            transform.position = Spaces.transform.GetChild(CurrentSpace).position;
            yield return new WaitForSeconds(1);
        }
        GameCtrl.AfterMove();
    }



    public bool HaveEnoughMoney(int value)
    {
        //  int total = GetTotal();

        if (AllMoney > value)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //public int GetTotal()
    //{
    //    int total = 0;
    //    for (int i = 0; i < 2; i++)
    //    {
    //        total += Money[i, 0] * Money[i, 1];
    //    }

    //    return total;
    //}


    public void Buy()
    {
        Owned.Add(CurrentSpace);

        PlacesController pCtrl = Spaces.transform.GetChild(CurrentSpace).GetComponent<PlacesController>();
        pCtrl.Owner = gameObject;

        ChangeMoney(Operation.SUB, pCtrl.BuyPrice);

        //   GameCtrl.SetPlayerTurn();
        Finish();
    }

    public void Pay()
    {
        PlacesController pCtrl = Spaces.transform.GetChild(CurrentSpace).GetComponent<PlacesController>();
        ParentController placeOwner = pCtrl.Owner.GetComponent<ParentController>();
        ChangeMoney(Operation.SUB, pCtrl.GetRent());
        placeOwner.ChangeMoney(0, pCtrl.GetRent());

        Finish();
    }


    public void Chance(CardController chance)
    {
        chance.PerfomAction(this);

        // IsPlayerPlaying = false;
        //   GameCtrl.ChangePlayer();
    }


    public void GoDirecly(int to)
    {
        CurrentSpace = to;
        transform.position = Spaces.transform.GetChild(to).transform.position;
        Finish();
    }


    public void Finish()
    {
        StartCoroutine(AfterPerformChance());
    }
    public void Community(CardController chest)
    {
        chest.PerfomAction(this);

    }



    IEnumerator AfterPerformChance()
    {
        yield return new WaitForSeconds(2);
        IsPlayerPlaying = false;
        GameCtrl.ChangePlayer();
    }


}
