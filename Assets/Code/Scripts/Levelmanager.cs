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
}
