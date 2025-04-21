using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PlayGame();
        }
    }
    public GameObject pausemenu;
    public GameObject healthbar;
    public GameObject counter;
    public GameObject settings;
    public void PlayGame()
    {
        
        pausemenu.SetActive(false);
        healthbar.SetActive(true);
        counter.SetActive(true);
        Time.timeScale = 1;
    }
    public void Quit()
    {
        settings.SetActive(false);
        pausemenu.SetActive(true);
    }
    public void QuitGame()
    {
       
        Destroy(GameObject.Find("BackgroundMusic"));
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    public void setting()
    {
        settings.SetActive(true);
        pausemenu.SetActive(false);
    }
}
