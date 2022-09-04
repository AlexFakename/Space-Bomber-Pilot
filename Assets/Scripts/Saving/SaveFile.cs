using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class SaveFile 
{
    public int highScore;
    public int cash;
    public int shotLevel;
    public int speedLevel;
    public int healthLevel;
    public int damageLevel;
    public int attackSpeedLevel;

    public SaveFile (PlayerStats stats)
    {
        highScore = stats.GetHighScore();
        cash = stats.GetCash();
        shotLevel = stats.GetShotLevel();
        speedLevel = stats.GetSpeedLevel();
        healthLevel = stats.GetHealthLevel();
        damageLevel = stats.GetDamageLevel();
        attackSpeedLevel = stats.GetAttackSpeedLevel();
    }
}
