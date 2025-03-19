using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemiesBullet : MonoBehaviour
{
    private float minimum = -10f;

    void Update()
    {
        if (gameObject.transform.position.y < minimum)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            InGameUI.instance.RestartCanvas();
        }
    }
}
