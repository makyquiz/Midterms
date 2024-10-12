using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab; 
    public Transform bulletSpawn; 
    public float bulletSpeed = 20f; 
    public float shootInterval = 10f;
    private float shootTimer;

    private ColorChangePlayer colorChangePlayer;

    private void Start()
    {
        shootTimer = shootInterval; 
        colorChangePlayer = GetComponent<ColorChangePlayer>(); 
    }

    private void Update()
    {
        shootTimer -= Time.deltaTime;

        if (shootTimer <= 0f)
        {
            Shoot(); 
            shootTimer = shootInterval;
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

        BulletScript bulletScript = bullet.GetComponent<BulletScript>();

        bulletScript.bulletColor = colorChangePlayer.GetCurrentColor();

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = bulletSpawn.forward * bulletSpeed; 

        Debug.Log("Bullet Fired!");
    }
}