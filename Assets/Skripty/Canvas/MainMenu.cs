using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    public GameObject LastProgres;
   
    public void PlayGame()
    {
        if (PlayerPrefs.GetInt("LastScene") > 1)
        {
            LastProgres.SetActive(true);
        }
        else
        {
        LoadNextLevel();
        PlayerPrefs.SetInt("coiny", 0);
        PlayerPrefs.SetInt("LastScene", 1);
        }   
    }
    public void QuitGame()
    {

        Application.Quit();
    }
    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }
    public void Yes()
    {
        StartCoroutine(LoadLevel(PlayerPrefs.GetInt("LastScene")));
    }

    public void No()
    {
        LoadNextLevel();
        PlayerPrefs.SetInt("coiny", 0);
        PlayerPrefs.SetInt("LastScene", 1);
    }
    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
}
