using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LastProgres : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    public void Yes()
    {
        LoadLevel(PlayerPrefs.GetInt("LastProgres"));
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
    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

}
