using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetButton : MonoBehaviour
{
    PlayerStats playerstats;
    Player player;    
    int[] shotUpCost = new int[] { 15, 50, 100, 250, 15 };
    [SerializeField] GameObject shotButton;
    [SerializeField] Text shotButtonText;
    int[] attackSpeedUpCost = new int[] { 15, 25, 35, 50, 15 };
    [SerializeField] GameObject attackSpeedButton;
    [SerializeField] Text attackSpeedButtonText;
    int[] damageUpCost = new int[] { 15, 25, 35, 50, 15 };
    [SerializeField] GameObject damageButton;
    [SerializeField] Text damageButtonText;
    int[] healthUpCost = new int[] { 15, 25, 35, 50, 15 };
    [SerializeField] GameObject healthButton;
    [SerializeField] Text healthButtonText;
    private void Start()
    {
        playerstats = FindObjectOfType<PlayerStats>();
        player = FindObjectOfType<Player>();
        UpdateUi();
    }   
    
    public void ResetButt() { playerstats.ResetStats(); SetActive(); UpdateUi(); }
    public void CheatCash() { playerstats.AddToCash(500); }

    public void LevelUpHealth()
    {
        if (playerstats.GetCash() >= healthUpCost[playerstats.GetHealthLevel()])
        {
            playerstats.RemoveCash(healthUpCost[playerstats.GetHealthLevel()]);
            playerstats.AddHealthLevel();
            if (healthButton) { healthButtonText.text = "HealthUP cost : " + healthUpCost[playerstats.GetHealthLevel()]; }
        }
                  
    }

    public void LevelUpDamage()
    {
        if (playerstats.GetCash() >= damageUpCost[playerstats.GetDamageLevel()])
        {
            playerstats.RemoveCash(damageUpCost[playerstats.GetDamageLevel()]);
            playerstats.AddDamageLevel();
            if (damageButton) { damageButtonText.text = "DamageUP cost : " + damageUpCost[playerstats.GetDamageLevel()]; }
        }
    }

    public void LevelUpAttackSpeed()
    {
        if (playerstats.GetCash() >= attackSpeedUpCost[playerstats.GetAttackSpeedLevel()])
        {
            playerstats.RemoveCash(attackSpeedUpCost[playerstats.GetAttackSpeedLevel()]);
            playerstats.AddAttackSpeedLevel();
            if (attackSpeedButton) { attackSpeedButtonText.text = "AtSpeedUP cost : " + attackSpeedUpCost[playerstats.GetAttackSpeedLevel()]; }
        }
    }

    public void LevelUpShot()
    {
        if (playerstats.GetCash() >= shotUpCost[playerstats.GetShotLevel()])
        {
            playerstats.RemoveCash(shotUpCost[playerstats.GetShotLevel()]);
            playerstats.AddShotLevel();
            if (shotButton) { shotButtonText.text = "ShotUP cost : " + shotUpCost[playerstats.GetShotLevel()]; }
        }
    }

    private void Update()
    {
        if (healthUpCost.Length - 1 == playerstats.GetHealthLevel()) { healthButton.SetActive(false); }
        if (damageUpCost.Length - 1 == playerstats.GetDamageLevel()) { damageButton.SetActive(false); }
        if (attackSpeedUpCost.Length - 1 == playerstats.GetAttackSpeedLevel()) { attackSpeedButton.SetActive(false); }
        if (shotUpCost.Length - 1 == playerstats.GetShotLevel()) { shotButton.SetActive(false); }
    }

    private void SetActive()
    {
        healthButton.SetActive(true);
        damageButton.SetActive(true);
        attackSpeedButton.SetActive(true);
        shotButton.SetActive(true);
    }

    private void UpdateUi()
    {
        if (healthButton) { healthButtonText.text = "HealthUP cost : " + healthUpCost[playerstats.GetHealthLevel()]; }
        if (damageButton) { damageButtonText.text = "DamageUP cost : " + damageUpCost[playerstats.GetDamageLevel()]; }
        if (attackSpeedButton) { attackSpeedButtonText.text = "AtSpeedUP cost : " + attackSpeedUpCost[playerstats.GetAttackSpeedLevel()]; }
        if (shotButton) { shotButtonText.text = "ShotUP cost : " + shotUpCost[playerstats.GetShotLevel()]; }
    }
}
