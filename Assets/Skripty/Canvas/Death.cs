using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    public GameObject meainmenudeath;
    public void ReplayGame()
    {
      
        Restart();
        meainmenudeath.SetActive(false);
        // StartCoroutine(LoadLevel());
    }
    public void QuitGame()
    {
        Destroy(GameObject.Find("BackgroundMusic"));
        SceneManager.LoadScene(0);
    }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}