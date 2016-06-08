using UnityEngine;
using System.Collections;

public class CardController : MonoBehaviour
{
    public GameDictionary.TypeOfAction Action;
    public int To;
    public int Amount;
    public int PerHouse;
    public int PerHotel;
    GameController GameCtrl;
    //  Vector3 OriginalPosition, NewPosition;
    bool WasChoosed;

    void Awake()
    {
        GameCtrl = Camera.main.GetComponent<GameController>();
    }
    // Quaternion OriginalRotation, NewRotation;
    //public bool MovingPosition
    //{
    //    get
    //    {
    //        return (transform.position != NewPosition);
    //    }
    //}
    //void Awake()
    //{
    //    OriginalRotation = transform.rotation;
    //    NewPosition = OriginalPosition = transform.position;
    //}
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if (MovingPosition)
        //{
        //    transform.position = Vector3.MoveTowards(transform.position, NewPosition, 3 * Time.deltaTime);


        //}
        //else if(WasChoosed)
        //{
        //    if (NewRotation != transform.rotation)
        //    {
        //        transform.rotation = Quaternion.Slerp(transform.rotation, new Quaternion(-45f, 0, 0, 0), 3F * Time.deltaTime);
        //    }
        //    else
        //    {
        //        WasChoosed = false;
        //    }
        //}
    }

    //public void Choosed()
    //{
    //    WasChoosed = true;
    //    NewPosition = new Vector3(Camera.main.transform.position.x + 1f, Camera.main.transform.position.y + 5f, Camera.main.transform.position.z + 4f);
    //    Debug.Log("Called " + NewPosition);
    //    NewRotation = Quaternion.identity;

    //}

    public void PerfomAction(PlayerController player)
    {
        switch (Action)
        {
            case GameDictionary.TypeOfAction.Advance:
                player.SetStep(To);
                break;
            case GameDictionary.TypeOfAction.AdvanceRailRoad:
                int count = GameCtrl.Spaces.transform.childCount;
                //if()
                //for (int i = player.CurrentSpace; i < count ; i++)
                //{

                //}
                    break;
            case GameDictionary.TypeOfAction.AdvanceUtility:
                break;
            case GameDictionary.TypeOfAction.Collect:
                //coll
                foreach (PlayerController pc in GameCtrl.Players)
                {
                    player.ChangeMoney(PlayerController.Operation.SUM, Amount);
                    pc.ChangeMoney(PlayerController.Operation.SUB, Amount);
                }
                player.ChangeMoney(PlayerController.Operation.SUM, Amount);
                player.Finish();
                break;
            case GameDictionary.TypeOfAction.GoBack:
                player.GoDirecly(player.CurrentSpace - Amount);
                player.Finish();
                break;
            case GameDictionary.TypeOfAction.OutOfJail:
                if (player.OnJail)
                {
                    player.OnJail = false;
                }
                else
                {
                    player.HaveJailCard = true;
                }
                player.Finish();
                break;
            case GameDictionary.TypeOfAction.Pay:
                player.ChangeMoney(PlayerController.Operation.SUB, Amount);
                player.Finish();
                break;
            case GameDictionary.TypeOfAction.Receive:
                player.ChangeMoney(PlayerController.Operation.SUM, Amount);
                player.Finish();
                break;

        }
    }
}
