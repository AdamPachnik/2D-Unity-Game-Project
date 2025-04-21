using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    public Rigidbody2D rb;
    public Animator anim;
    float mx;
    public float jumpForce = 20f;
    public Transform feet;
    public LayerMask groundLayers;
    private PlayerCombat enemyParent;
    public bool jevovoziku;
    public bool respawn;
    public AudioSource walk;
    private void Awake()
    {
        enemyParent = GetComponentInParent<PlayerCombat>();
    }
    private void Start()
    {
        enemyParent.CanHit = true;
        jevovoziku = false;
        respawn = false;
    }
    void Update()
    {
        if (!isGrounded())
        {
            walk.Stop();
        }
        if (enemyParent.CanHit == true)
        {

            mx = Input.GetAxisRaw("Horizontal");
            if (Input.GetButtonDown("Jump") && !jevovoziku && isGrounded() && enemyParent.CanHit == true)
            {
                Jump();
                walk.Stop();
            }
            if (Mathf.Abs(mx) > 0.05f)
            {
                anim.SetBool("isRunning", true);
                if (!walk.isPlaying && isGrounded())
                {
                    walk.Play();
                }
            }
        
            else
            {                
                walk.Stop();               
                anim.SetBool("isRunning", false);
            }
            if (mx > 0f)
            {
                transform.localScale = new Vector3(3.1f, 2.9f, 1f);
            }
            else if (mx < 0f)
            {
                transform.localScale = new Vector3(-3.1f, 2.9f, 1f);

            }
            anim.SetBool("isGrounded", isGrounded());
        }
        else
        {
            anim.SetBool("isRunning", false);

        }
    }
    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(mx * movementSpeed, rb.velocity.y);
        rb.velocity = movement;
    }
    void Jump()
    {
        Vector2 movement = new Vector2(rb.velocity.x, jumpForce);
        rb.velocity = movement; 
    }
    public bool isGrounded()
    {
        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.5f, groundLayers);
        if (groundCheck != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
        }
    }
}
