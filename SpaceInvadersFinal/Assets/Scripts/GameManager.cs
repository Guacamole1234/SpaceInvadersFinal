using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] spaceShips;

    [SerializeField] private Vector3 spawnPosition;
    
    private void Start()
    {
        if (GeneralManager.instance != null)
        {
            Instantiate(spaceShips[GeneralManager.instance.selectedShip], spawnPosition, Quaternion.identity);
        }
        else
        {
            Instantiate(spaceShips[0], spawnPosition, Quaternion.identity);
        }
    }
}
