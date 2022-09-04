using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] TMP_Text healthText;
    int playerHealth;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetHealthValue(int myHealth)
    {
        playerHealth = myHealth;
        healthText.text = playerHealth.ToString();
    }
}
