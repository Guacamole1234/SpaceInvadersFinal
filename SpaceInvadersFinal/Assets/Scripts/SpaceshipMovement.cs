using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody playerRb;
    private Vector3 newPlayerPosition;

    [SerializeField] private float spaceSpeed;
    [SerializeField] private float shootCooldown;

    private bool canShoot = true;
    private bool canShootSpecial = true;

    [SerializeField] private Vector3 bulletSpawnPosition;
    [SerializeField] private GameObject bulletPrefab;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Shoot();
    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        if (Input.GetAxis("Horizontal") != 0f)
        {
            newPlayerPosition = transform.position;
            newPlayerPosition.x += Input.GetAxis("Horizontal") * spaceSpeed * Time.deltaTime;
            playerRb.MovePosition(newPlayerPosition);
        }
    }

    private void Shoot()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Instantiate(bulletPrefab, transform.position + bulletSpawnPosition, Quaternion.identity);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position + bulletSpawnPosition, new Vector3 (0.1f, 0.1f, 0.1f));
    }
}
