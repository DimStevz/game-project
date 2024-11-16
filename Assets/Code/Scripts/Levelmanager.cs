using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Levelmanager : MonoBehaviour
{
    private void Awake()
{
    if (main != null && main != this)
    {
        Debug.LogError("Multiple Levelmanager instances detected!");
        return;
    }
    main = this;
}

    public static Levelmanager main;

    public Transform[] startPoint;
    public Transform[] path;

    public int coin;

    private void Start()
    {
        coin = 100;
    }
    public void IncreaseCoin(int amount)
    {
        coin += amount;
    }

    public bool DecreaseCoin(int amount)
    {
        if(amount <= coin)
        {
            //buy item
            coin -= amount;
            return true;
        }
        else
        {
            Debug.Log("Not enough coin");
            return false;
        }
    }
}
