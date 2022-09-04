using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    //resource + score
    private int score = 0;
    private int cash = 0;
    private int highScore = 0;
    //Levels
    private int shotLevel = 0;
    private int speedLevel = 0;
    private int healthLevel = 0;
    private int damageLevel = 0;
    private int attackSpeedLevel = 0;
    //TextFields
    [SerializeField] TMP_Text textScore;
    [SerializeField] TMP_Text textHighScore;
    [SerializeField] TMP_Text textCash;
    private void Awake()
    {
        SingletonPattern();
    }

    private void SingletonPattern()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ResetStats()
    {
        score = 0;
        cash = 0;
        highScore = 0;
        shotLevel = 0;
        speedLevel = 0;
        healthLevel = 0;
        damageLevel = 0;
        attackSpeedLevel = 0;
        UpdateUI();
        SavePlayerStats();
    }
    //Resource + Score
    public void AddToScore(int myScore) { score += myScore; textScore.text = "Score : " + score; }
    public void AddToCash(int myCash) { cash += myCash; textCash.text = cash.ToString(); }
    public void RemoveCash(int removeAmount)
    {
        if(removeAmount <= cash)
        {
            cash -= removeAmount;
            textCash.text = cash.ToString();
        }
    }

    public void ResetScore() { score = 0; textScore.text = "Score : " + score; }
    public void SetHighScore() { if (score > highScore) { highScore = score; textHighScore.text = "HighScore : " + highScore; } }
    void Start()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        textScore.text = "Score : " + score.ToString();
        textHighScore.text = "HighScore : " + highScore.ToString();
        textCash.text = cash.ToString();
    }
    //upgrades bought
    public void AddHealthLevel() { healthLevel += 1; SavePlayerStats(); }
    public void AddDamageLevel() { damageLevel += 1; SavePlayerStats(); }
    public void AddAttackSpeedLevel() { attackSpeedLevel += 1; SavePlayerStats(); }
    public void AddShotLevel() { shotLevel += 1; SavePlayerStats(); }



    //Getters
    public int GetHighScore() { return highScore; }
    public int GetCash() { return cash; }
    public int GetShotLevel() { return shotLevel; }
    public int GetSpeedLevel() { return speedLevel; }
    public int GetHealthLevel() { return healthLevel; }
    public int GetDamageLevel() { return damageLevel; }
    public int GetAttackSpeedLevel() { return attackSpeedLevel; }

    //Save System
    public void SavePlayerStats() { SaveSystem.SaveStats(this); }
    public void LoadPlayerStats()
    {
        SaveFile file = SaveSystem.LoadStats();

        highScore = file.highScore;
        cash = file.cash;
        shotLevel = file.shotLevel;
        speedLevel = file.speedLevel;
        healthLevel = file.healthLevel;
        damageLevel = file.damageLevel;
        attackSpeedLevel = file.attackSpeedLevel;
    }
}
