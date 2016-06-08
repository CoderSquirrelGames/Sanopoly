using UnityEngine;
using System.Collections;

public class ParentController : MonoBehaviour
{
    public enum Operation
    {
        SUM, SUB
    }
    public int AllMoney = 1500;
    protected GameController GameCtrl;
    public bool IsPlayerPlaying;
    public AudioClip Audio;
    public AudioSource Source;
    protected virtual void Awake()
    {
        Source = (AudioSource)gameObject.AddComponent("AudioSource");

        Source.clip = Audio;
    }
    /// <summary>
    /// type 0 sum, 1 sub
    /// </summary>
    /// <param name="type"></param>
    /// <param name="amount"></param>
    public void ChangeMoney(Operation op, int amount)
    {
        switch (op)
        {
            case Operation.SUM:
                AllMoney += amount;
                break;
            case Operation.SUB:
                AllMoney -= amount;
                break;

        }
        Source.Play();
    }
}
