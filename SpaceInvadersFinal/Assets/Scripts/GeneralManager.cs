using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralManager : MonoBehaviour
{
    public static GeneralManager instance;

    public int selectedShip;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        selectedShip = -1;
    }
}
