using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float startHealth = 100;
    [SerializeField] float health = 100;
    [SerializeField] int scoreValue = 50;
    [SerializeField] float speedX = 0f;
    [SerializeField] float speedY = 2f;
    [SerializeField] GameObject crystalPrefab;
    [Header("Projectile")]    
    [SerializeField] int collisionDamage = 150;
    [Header("Particles")]
    [SerializeField] GameObject explosionParticle;
    [SerializeField] float particleDeathDuration = 1f;
    [Header("Audio")]
    [SerializeField] AudioClip deathSound;
    float soundVolume = 0.1f;
    //Spawn Locations
    float minX;
    float maxX;
    float minY;
    float maxY;

    // Start is called before the first frame update
    void Start()
    {
        //Spawn Locations
        minX = FindObjectOfType<EnemySpawner>().GetMinX();
        maxX = FindObjectOfType<EnemySpawner>().GetMaxX();
        minY = FindObjectOfType<EnemySpawner>().GetMinY();
        maxY = FindObjectOfType<EnemySpawner>().GetMaxY();
        GetComponent<Rigidbody2D>().velocity = new Vector2(speedX, -speedY);
        soundVolume = FindObjectOfType<Options>().GetSFXVolume();
    }

    // Update is called once per frame
    void Update()
    {
        
    }





    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerLaser"))
        {
            int damageTaken = collision.gameObject.GetComponent<PlayerLaser>().DealDamage();
            Destroy(collision.gameObject);
            ProcessHit(damageTaken);
        }
        if (collision.CompareTag("Player"))
        {
            int damageTaken = collision.gameObject.GetComponent<Player>().DealDamage();
            ProcessHit(damageTaken);
        }
    }

    private void ProcessHit(int damageTaken)
    {
        health -= damageTaken;
        IDie();
    }

    private void IDie()
    {
        if (health <= 0)
        {
            GameObject particle = Instantiate(explosionParticle, transform.position, transform.rotation) as GameObject;
            Instantiate(crystalPrefab, transform.position, transform.rotation);
            Destroy(particle.gameObject, particleDeathDuration);
            AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, soundVolume);
            FindObjectOfType<PlayerStats>().AddToScore(scoreValue);
            transform.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        }
    }

    public int DealDamage()
    {
        return collisionDamage;
    }

    public void PortMeBack()
    {
        transform.position = new Vector2(Random.Range(minX, maxX),
                                Random.Range(minY, maxY));
        health = startHealth;
    }
}
