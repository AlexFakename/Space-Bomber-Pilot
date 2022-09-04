using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    [SerializeField] int cashValue = 0;
    [SerializeField] float xSpeed = 0f;
    [SerializeField] float ySpeed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(xSpeed, -ySpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            PlayerStats playerStats = FindObjectOfType<PlayerStats>();
            playerStats.AddToCash(cashValue);
            Destroy(gameObject);
        }
    }
}
