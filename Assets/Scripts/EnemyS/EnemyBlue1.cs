using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlue1 : MonoBehaviour
{
    float shotCounter;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 0.8f;
    [SerializeField] GameObject laserPrefab;
    [SerializeField] AudioClip laserShotSound;
    float soundVolume = 0.1f;
    Vector3 myTransform;

    private void Start()
    {
    }

    private void Update()
    {
        CountDownAndShoot();
        soundVolume = FindObjectOfType<Options>().GetSFXVolume();
    }



    private void Fire()
    {
        Instantiate(laserPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        GameObject laser1 = Instantiate(laserPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        GameObject laser2 = Instantiate(laserPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        AudioSource.PlayClipAtPoint(laserShotSound, Camera.main.transform.position, soundVolume);
        laser1.transform.Rotate(0f, 0f, 45f, Space.Self);
        laser2.transform.Rotate(0f, 0f, -45f, Space.Self);
    }

    private void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0)
        {
            Fire();
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }
}