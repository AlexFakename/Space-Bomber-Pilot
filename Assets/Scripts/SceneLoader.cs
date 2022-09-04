using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
    private void Awake()
    {
        FindObjectOfType<PlayerStats>().LoadPlayerStats();
    }
    public static void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public static void LoadMainMenu()
    {       
        SceneManager.LoadScene(0);
        FindObjectOfType<PlayerStats>().LoadPlayerStats();
        FindObjectOfType<Options>().LoadOptions();
        FindObjectOfType<PlayerStats>().ResetScore();
    }

    public static void LoadGameOver()
    {
        FindObjectOfType<PlayerStats>().SetHighScore();
        FindObjectOfType<PlayerStats>().SavePlayerStats();
        SceneManager.LoadScene(3);
    }

    public static void LoadGamePlayScene()
    {
        PlayerStats playerstats = FindObjectOfType<PlayerStats>();
        Destroy(playerstats.gameObject);
        SceneManager.LoadScene(2);
    }

    public static void LoadGameHangar()
    {
        SceneManager.LoadScene(1);
    }
    public static void LoadOptionsMenu() { SceneManager.LoadScene(4); }

    public void LoadGameOver(float waitTime)
    {
        StartCoroutine(WaitToLoad(waitTime));
    }

    public static IEnumerator WaitToLoad(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        FindObjectOfType<PlayerStats>().SetHighScore();
        FindObjectOfType<PlayerStats>().SavePlayerStats();
        SceneManager.LoadScene(3);
    }

    public static void QuitGame()
    {
        Application.Quit();
    }
}
