using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // configuration parameters
    PlayerStats playerstats;
    [Header("Player")]
    [SerializeField] float moveSpeed = 10f;
    int[] healthArray = new int[] { 100, 250, 500, 750, 1000 };
    int health;
    [SerializeField] Transform target;
    float angle;
    [Header("Projectile")]
    [SerializeField] GameObject laserPrefab;
    int[] damageArray = new int[] { 50, 100, 200, 300, 500 };
    int damage;
    float fireTime = 0f;
    float[] fireTimeDelayArray = new float[] { 1f, 0.8f, 0.6f, 0.4f, 0.2f };
    float fireTimeDelay;
    int shotLevel;
    [Header("Audio")]
    [SerializeField] AudioClip laserShot;
    [SerializeField] AudioClip deathSound;
    float soundVolume = 0.1f;

    float xMin;
    float xMax;
    float yMin;
    float yMax;
    
    // Start is called before the first frame update
    void Start()
    {
        playerstats = FindObjectOfType<PlayerStats>();
        SetMyStats();
        SetUpMoveBoundaries();
        FindObjectOfType<HealthDisplay>().GetHealthValue(health);
        soundVolume = FindObjectOfType<Options>().GetSFXVolume();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Fire();
        Rotate();
    }

    private void Fire()
    {
        fireTime -= Time.deltaTime;
        if (fireTime <= fireTimeDelay)
        {
            switch (shotLevel)
            {
                case 0:
                    Instantiate(laserPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
                    AudioSource.PlayClipAtPoint(laserShot, Camera.main.transform.position, soundVolume);
                    fireTime += fireTimeDelay;
                    break;
                case 1:
                    Instantiate(laserPrefab, new Vector3(transform.position.x -0.1f, transform.position.y, transform.position.z), transform.rotation);
                    Instantiate(laserPrefab, new Vector3(transform.position.x + 0.1f, transform.position.y, transform.position.z), transform.rotation);
                    AudioSource.PlayClipAtPoint(laserShot, Camera.main.transform.position, soundVolume);
                    fireTime += fireTimeDelay;
                    break;
                case 2:
                    Instantiate(laserPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
                    GameObject laser21 = Instantiate(laserPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
                    GameObject laser22 = Instantiate(laserPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
                    SetLaserRotation(laser21, laser22);
                    AudioSource.PlayClipAtPoint(laserShot, Camera.main.transform.position, soundVolume);
                    fireTime += fireTimeDelay;
                    break;
                case 3:
                    Instantiate(laserPrefab, new Vector3(transform.position.x - 0.1f, transform.position.y, transform.position.z), transform.rotation);
                    Instantiate(laserPrefab, new Vector3(transform.position.x + 0.1f, transform.position.y, transform.position.z), transform.rotation);
                    GameObject laser31 = Instantiate(laserPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
                    GameObject laser32 = Instantiate(laserPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
                    SetLaserRotation(laser31, laser32);
                    AudioSource.PlayClipAtPoint(laserShot, Camera.main.transform.position, soundVolume);
                    fireTime += fireTimeDelay;
                    break;
                case 4:
                    Instantiate(laserPrefab, new Vector3(transform.position.x - 0.1f, transform.position.y, transform.position.z), transform.rotation);
                    Instantiate(laserPrefab, new Vector3(transform.position.x + 0.1f, transform.position.y, transform.position.z), transform.rotation);
                    Instantiate(laserPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
                    GameObject laser41 = Instantiate(laserPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
                    GameObject laser42 = Instantiate(laserPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
                    SetLaserRotation(laser41, laser42);
                    AudioSource.PlayClipAtPoint(laserShot, Camera.main.transform.position, soundVolume);
                    fireTime += fireTimeDelay;
                    break;
            }
            
        }


    }

    private void Rotate()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = -10f;
        Vector3 objectPos = Camera.main.WorldToScreenPoint(target.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;
        angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle +270f);

    }

    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        var deltaY = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        var newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);
        transform.position = new Vector2(newXPos, newYPos);
    }

    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;

        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0.05f, 0)).y;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 0.9f, 0)).y;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyLaser"))
        {
            string lasertag = collision.GetComponent<LaserTag>().GetMyTag();
            switch (lasertag)
            {
                case "Laser1":
                    int damageTaken = collision.GetComponent<Laser1>().DealDamage();
                    Destroy(collision.gameObject);
                    ProcessHit(damageTaken);
                    break;
            }
                
        }
        if (collision.CompareTag("Enemy"))
        {
            int damageTaken = collision.gameObject.GetComponent<Enemy>().DealDamage();
            ProcessHit(damageTaken);
        }
    }

    private void ProcessHit(int damageTaken)
    {
        health -= damageTaken;
        FindObjectOfType<HealthDisplay>().GetHealthValue(health);
        if (health <= 0)
        {
            PlayerDeath();
        }
    }

    private void PlayerDeath()
    {
        AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, soundVolume);
        FindObjectOfType<SceneLoader>().LoadGameOver(2f);
        Destroy(gameObject);
    }

    public int DealDamage() { return damage; }

    private void SetMyStats()
    {
        health = healthArray[playerstats.GetHealthLevel()];
        damage = damageArray[playerstats.GetDamageLevel()];
        fireTimeDelay = fireTimeDelayArray[playerstats.GetAttackSpeedLevel()];
        shotLevel = playerstats.GetShotLevel();
    }

    public int GetProjectileDamage() { return damage; }

    private void SetLaserRotation(GameObject laser1, GameObject laser2)
    {
        laser1.transform.Rotate(0f, 0f, 45f, Space.Self);
        laser2.transform.Rotate(0f, 0f, -45f, Space.Self);
    }

}