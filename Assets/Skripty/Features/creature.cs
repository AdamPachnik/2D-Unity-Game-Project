using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creature : MonoBehaviour
{

/* public float speed = 2f;
 public Transform Leftpoint;
 public Transform Rightpoint;
 public bool left;

 private void Start()
 {
      left = true;
}

 void Update()
 {
     walkLeft();
     }

 void walkRight()
 {

     float step = speed * Time.deltaTime;
     transform.position = Vector2.MoveTowards(transform.position, Rightpoint.position, step);


 }
 void walkLeft()
 {

     float step = speed * Time.deltaTime;
     transform.position = Vector2.MoveTowards(transform.position, Leftpoint.position, step);
     if (left)
     {
         Flip();
     transform.position = Vector2.MoveTowards(transform.position, Rightpoint.position, step);

     }
     else if (!left)
     {
         Flip();
        transform.position = Vector2.MoveTowards(transform.position, Leftpoint.position, step);

     }

 }
 void Flip()
     {
         Vector3 rotation = transform.eulerAngles;
         if (left)
         {
             rotation.y = 180;
         }
         else if(!left)
         {
             rotation.y = 0;
         }
         transform.eulerAngles = rotation;
     }
 }
*/
public float speed = 2f;
public Rigidbody2D rb;
public LayerMask groundLayers;
public Transform groundCheck;
bool isFacingRight = true;
RaycastHit2D hit;



private void Update()
{

    hit = Physics2D.Raycast(groundCheck.position, -transform.up, 1f, groundLayers);

}



private void FixedUpdate()
{

    if (hit.collider != false)
    {

        if (!isFacingRight)
        {

            rb.velocity = new Vector2(speed, rb.velocity.y);

        }
        else
        {

            rb.velocity = new Vector2(-speed, rb.velocity.y);

        }

    }
    else
    {

        isFacingRight = !isFacingRight;

        transform.localScale = new Vector3(-transform.localScale.x, 2.701361f, 1f);

    }

}

}
