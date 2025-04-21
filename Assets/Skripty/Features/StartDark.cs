using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDark : MonoBehaviour
{
    public GameObject Sprite;
    public bool LevelCompleted = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Sprite.SetActive(true);
        }
    }
    private void Update()
    {
        if (LevelCompleted)
        {
            gameObject.SetActive(false); 
        }
    }
    public void K()
    {
        gameObject.SetActive(false);

    }
}
