using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public Transform respawnpoint;
    public bool respawn;


    void Start()
    {
        PlayerPrefs.SetInt("coiny", 0);
        transform.position = respawnpoint.position;
    }

    void Update()
    {
        if (respawn)
        {
            PlayerPrefs.SetInt("coiny", 0);
            transform.position = respawnpoint.position;

            respawn = false;

        }
    }
}
