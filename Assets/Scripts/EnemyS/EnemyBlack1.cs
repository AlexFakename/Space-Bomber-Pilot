using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlack1 : MonoBehaviour
{
    float shotCounter;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 0.8f;
    [SerializeField] GameObject laserPrefab;
    [SerializeField] AudioClip laserShotSound;
    float soundVolume = 0.1f;

    private void Update()
    {
        CountDownAndShoot();
        soundVolume = FindObjectOfType<Options>().GetSFXVolume();
    }



    private void Fire()
    {
        Instantiate(laserPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        AudioSource.PlayClipAtPoint(laserShotSound, Camera.main.transform.position, soundVolume);
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
