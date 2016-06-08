using UnityEngine;
using System.Collections;

public class PlacesController : MonoBehaviour
{
    string SpaceName;
    public GameObject Owner;
    public int BuyPrice;
    public int PerHouse;
    public int[] Rents = new int[6];
    private int Builds = 0;
    public bool DicePrice, Tax;
    public GameDictionary.TypeOfProperty PropertyColor;
    GameController GameCtrl;
    void Awake()
    {
        GameCtrl = Camera.main.GetComponent<GameController>();
    }

    // Use this for initialization
    void Start()
    {
        SpaceName = GameDictionary.SpaceName[int.Parse(name)];
    }

    // Update is called once per frame
    void Update()
    {

    }
    public int GetRent()
    {
        if (DicePrice)
        {
            Debug.Log("Dice Price ");
            int dices = GameCtrl.CanvasCtrl.RollDiceRent();
            Debug.Log("Price must be " + (4 * dices));
            return (4 * dices);
        }
        else
            return Rents[Builds];
    }

    /// <summary>
    /// 0 means just bought, 1 till 5 is houses, 6 is hotel;
    /// </summary>
    /// <param name="build"></param>
    public void BuildHouse()
    {
        Builds++;
    }

    public void BuildHotel()
    {
        Builds = 6;
    }

    public string GetName()
    {

        return SpaceName;
    }

}
