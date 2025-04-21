using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class cart : MonoBehaviour
{

    public GameObject carttplayer;
    public GameObject player;
    public AudioSource walking;
    
    public GameObject secondCart;
     bool yes;   
    private void Start()
    {
        yes = false;
        
    }
    private void Update()
    {
        if (yes && Input.GetKeyDown(KeyCode.F))
        {       
            carttplayer.transform.parent = player.transform;             
            carttplayer.transform.localPosition = new Vector3(-0.02160842f, -0.04909351f, 0.08f);
            transform.localPosition = new Vector3(-0.02160842f, -0.04909351f, 0.08f);
            carttplayer.GetComponentInParent<Renderer>().sortingOrder = 501;
            GameObject.Find("Player").GetComponent<PlayerMovement>().jevovoziku = true;
            GameObject.Find("Player").GetComponent<PlayerCombat>().jevovoziku = true;
            GameObject.Find("Player").GetComponent<PlayerMovement>().movementSpeed = 18;
            GameObject.Find("Player").GetComponent<PlayerMovement>().walk.enabled = false;
        }
        else if (!yes && Input.GetKeyDown(KeyCode.F))
        {
           
            carttplayer.transform.parent = null;
            transform.position = carttplayer.transform.position;
            carttplayer.GetComponentInParent<Renderer>().sortingOrder = 201;
            GameObject.Find("Player").GetComponent<PlayerMovement>().jevovoziku = false;
            GameObject.Find("Player").GetComponent<PlayerCombat>().jevovoziku = false;
            GameObject.Find("Player").GetComponent<PlayerMovement>().movementSpeed = 10;
            GameObject.Find("Player").GetComponent<PlayerMovement>().walk.enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.gameObject.CompareTag("Player"))
        {
            yes = true;
            secondCart.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            secondCart.SetActive(true);
            yes = false;
        }
    }

}
