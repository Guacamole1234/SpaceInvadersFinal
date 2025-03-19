using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    public static EnemiesManager instance;

    [SerializeField] private Vector3 enemiesSpawnPosition;

    [SerializeField] private float columns;
    [SerializeField] private float rows;

    [SerializeField] private float jumpSizeY;
    [SerializeField] private float areaBetweenX;
    [SerializeField] private float areaBetweenY;

    public float enemiesSpeed;
    public float speedToAdd;
    [SerializeField] private float boundaries;

    [SerializeField] private GameObject[] enemiesPrefabs;
    [HideInInspector] public List<List<GameObject>> enemiesGroup = new List<List<GameObject>>();

    [SerializeField] private GameObject enemiesMain;

    private float direction = 1;
    private bool collided = false;
    [HideInInspector] public bool moving = true;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    void Start()
    {
        CreateEnemies();
    }

    void Update()
    {
        EnemiesMovement();
        collided = false;
    }

    private void EnemiesMovement()
    {
        if (moving)
        {
            foreach (var column in enemiesGroup)
            {
                foreach (var enemy in column)
                {
                    if (enemy.activeSelf)
                    {
                        enemy.transform.position += Vector3.right * direction * enemiesSpeed * Time.deltaTime;
                    }
                }
            }
        }
    }

    void CreateEnemies()
    {
        for (int i = 0; i < columns; i++)
        {
            enemiesGroup.Add(new List<GameObject>());
            for (int j = 0; j < rows; j++)
            {
                Vector3 position = new Vector3(enemiesSpawnPosition.x + i * areaBetweenX, enemiesSpawnPosition.y - j * areaBetweenY, enemiesSpawnPosition.z);
                GameObject enemy = Instantiate(enemiesPrefabs[Random.Range(0, enemiesPrefabs.Length)], position, Quaternion.identity);
                enemy.name = $"{"Enemy"}({i},{j})";
                enemy.gameObject.transform.SetParent(enemiesMain.transform);
                enemiesGroup[i].Add(enemy);
            }
        }
    }

    public void ChangeDirection()
    {
        if (!collided)
        {
            collided = true;
            direction *= -1;
            MoveEnemiesDown();
        }
    }

    void MoveEnemiesDown()
    {
        foreach (var column in enemiesGroup)
        {
            foreach (var enemy in column)
            {
                if (enemy.activeSelf)
                {
                    enemy.transform.position += Vector3.down * jumpSizeY;
                }
            }
        }
    }
}
