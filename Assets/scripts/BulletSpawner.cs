using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    public float spawnInterval = 3f;
    private Material currentBulletMaterial;

    void Start()
    {
        InvokeRepeating("SpawnBullet", 0f, spawnInterval);
    }

    void SpawnBullet()
    {
        var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        bullet.GetComponent<Rigidbody>().velocity = -bulletSpawnPoint.forward * bulletSpeed;

        Bullet bulletScript = bullet.GetComponent<Bullet>();
        if (bulletScript != null)
        {
            bulletScript.Initialize(currentBulletMaterial);
        }

        Destroy(bullet, 10f);
    }

    public void UpdateSpawnerMaterial(Material newMaterial)
    {
        currentBulletMaterial = newMaterial;
    }
}

