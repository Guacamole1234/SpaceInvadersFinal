using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemies : MonoBehaviour
{
    [SerializeField] float[] shootInterval;
    [SerializeField] float shootTimer;

    [SerializeField] private float bounds;

    [SerializeField] GameObject bulletGameObject;

    bool checkBounds = true;

    float gameOverBound = -1f;

    private void Update()
    {
        shootTimer += Time.deltaTime;

        if (shootTimer >= Random.Range(shootInterval[0], shootInterval[1]))
        {
            shootTimer = 0f;

            if (LowerEnemy())
            {
                if (Random.Range(1, 7) == 1)
                {
                    Shoot();
                }
            }
        }

        if (gameObject.transform.position.y <= gameOverBound && checkBounds)
        {
            InGameUI.instance.RestartCanvas();
        }

        if (gameObject.transform.position.x >= bounds || gameObject.transform.position.x <= -bounds)
        {
            EnemiesManager.instance.ChangeDirection();
        }
    }

    private bool LowerEnemy()
    {
        Vector3 position = transform.position;

        foreach (var column in EnemiesManager.instance.enemiesGroup)
        {
            if (column.Contains(gameObject))
            {
                foreach (var enemy in column)
                {
                    if (enemy.activeSelf && enemy.transform.position.y < position.y)
                    {
                        return false;
                    }
                }
                break;
            }
        }
        return true;
    }

    private void Shoot()
    {
        if (EnemiesManager.instance.moving == true)
        {
            Instantiate(bulletGameObject, gameObject.transform.position, Quaternion.identity);
        }
    }
}
