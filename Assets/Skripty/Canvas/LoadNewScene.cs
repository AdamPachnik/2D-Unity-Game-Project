using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class LoadNewScene : MonoBehaviour
{
    public GameObject Healthbar;
    public GameObject RechargeBar;
    public GameObject Coins;
    public GameObject panel;
    public Rigidbody2D Player;
    public Animator anim;
    public AudioSource player;
    int scene;
    private void OnTriggerEnter2D(Collider2D collider)
    {
       
        if (collider.gameObject.tag == "Player")
        {
            GameObject.Find("Darken").SetActive(false);
            Healthbar.SetActive(false);
            RechargeBar.SetActive(false);
            Coins.SetActive(false);
            panel.SetActive(true);
            Player.bodyType = RigidbodyType2D.Static;
            GameObject.Find("Player").GetComponent<PlayerCombat>().CanHit = false;
            player.enabled = false;

        }
    }
    void LoadScene()
    {
        SceneManager.LoadScene(3);
    }
}
