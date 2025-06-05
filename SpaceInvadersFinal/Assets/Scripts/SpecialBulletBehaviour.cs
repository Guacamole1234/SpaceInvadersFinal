using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpecialBulletBehaviour : MonoBehaviour
{
    [SerializeField] LayerMask layer;

    private float bulletSpeed = 8f;

    void Update()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + (bulletSpeed * Time.deltaTime), gameObject.transform.position.z);
        if (gameObject.transform.position.y > 14f)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag.Contains("Enemy"))
        {
            AreaDamage();
            Destroy(gameObject);
        }
    }

    void AreaDamage()
    {
        Collider[] hitColliders = Physics.OverlapBox(gameObject.transform.position, transform.localScale * 15, Quaternion.identity, layer);
        int i = 0;
        while (i < hitColliders.Length)
        {
            if (hitColliders[i].gameObject.tag.Contains("Enemy"))
            {
                List <GameObject> tempUFOAmount = new List<GameObject>();
                hitColliders[i].gameObject.SetActive(false);
                tempUFOAmount.Add(hitColliders[i].gameObject);
                EnemiesManager.instance.enemiesSpeed += EnemiesManager.instance.speedToAdd * tempUFOAmount.Count;
            }
            i++;
        }
    }
}
