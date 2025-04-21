using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleted : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    public void ContinueGame()
    {
        // SceneManager.LoadScene(2);
        int scene = PlayerPrefs.GetInt("LastScene");
        PlayerPrefs.SetInt("LastScene", scene + 1);
        PlayerPrefs.SetInt("coiny", 0);
        LoadNextLevel();
    }
    public void QuitGame()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
}