using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class player_movement : MonoBehaviour
{

    public float speed;
    public Vector2 jumpForce;
    public float maxSpeed;
    private bool isGrounded = false;
    private Vector2 speedV2;
    private Rigidbody2D rb;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        speedV2.x = 0;
        if (rb.velocity.x < maxSpeed && rb.velocity.x > (maxSpeed * -1) && isGrounded && !anim.GetBool("hurt"))
        {
            speedV2.x = Input.GetAxis("Horizontal");
        }
        
        rb.AddForce(speedV2 * speed);
        
    }
    // Update is called once per frame
    private void Update()
    {
        RaycastHit2D rayL = Physics2D.Raycast(new Vector2(transform.position.x - 0.5f, transform.position.y - 0.71f), Vector2.down, 0.05f);
        Debug.DrawRay(new Vector2(transform.position.x - 0.5f, transform.position.y - 0.71f), Vector2.down * 0.05f, Color.red);
        RaycastHit2D rayR = Physics2D.Raycast(new Vector2(transform.position.x + 0.5f, transform.position.y - 0.71f), Vector2.down, 0.05f);
        Debug.DrawRay(new Vector2(transform.position.x + 0.5f, transform.position.y - 0.71f), Vector2.down * 0.05f, Color.blue);
        if(rayL.collider != null)
        {
            if(rayL.collider.gameObject.layer == 3)
            {
                isGrounded = true;
            }
            else
            {
                isGrounded = false;
            }
        }
        else
        {
            isGrounded = false;
        }
        if(rayR.collider != null && !isGrounded)//checks if left ray is touching ground, and if so, it wont check if right ray is on ground
        {
            if(rayR.collider.gameObject.layer == 3)
            {
                isGrounded = true;
            }
        }
        anim.SetBool("Grounded", isGrounded);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !anim.GetBool("hurt"))
        {
            rb.AddForce(jumpForce, ForceMode2D.Impulse);
        }

        if (Input.GetAxis("Horizontal") > 0.001f && isGrounded && !anim.GetBool("hurt"))
        {
            GetComponent<SpriteRenderer>().flipX = false;
            anim.SetBool("Walking", true);
        }
        else if (Input.GetAxis("Horizontal") < -0.001f && isGrounded && !anim.GetBool("hurt"))
        {
            GetComponent<SpriteRenderer>().flipX = true;
            anim.SetBool("Walking", true);
        }
        else
        {
            anim.SetBool("Walking", false);
        }
    }
}
