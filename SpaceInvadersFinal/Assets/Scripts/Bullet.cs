using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
    private float bulletSpeed = 8f;

    void Update()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + (bulletSpeed * Time.deltaTime), gameObject.transform.position.z);

        if (transform.position.y >= 14f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Fast"))
        {
            GeneralManager.instance.selectedShip = 0;
            Menu.instance.LoadGame();
        }
        else if (collision.gameObject.name.Contains("Equilibrated"))
        {
            GeneralManager.instance.selectedShip = 1;
            Menu.instance.LoadGame();
        }
        else if (collision.gameObject.name.Contains("Slow"))
        {
            GeneralManager.instance.selectedShip = 2;
            Menu.instance.LoadGame();
        }

        Destroy(gameObject);
    }
}
