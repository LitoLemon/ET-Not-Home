using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class player_movement : MonoBehaviour
{
    public static Vector3 startPos;

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
        startPos= transform.position;
        InventoryManager.Inventory["Hp"] = 3;
        InventoryManager.Inventory["Bomb"] = 1;
        InventoryManager.Inventory["Fireball"] = 4;
    }

    void OnJump()
    {
        if (isGrounded && !anim.GetBool("hurt"))
        {
            rb.AddForce(jumpForce, ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        speedV2.x = 0;
        if (rb.velocity.x < maxSpeed && rb.velocity.x > (maxSpeed * -1) && !anim.GetBool("hurt"))
        {
            speedV2.x = Input.GetAxis("Horizontal");
        }

        rb.AddForce(speedV2 * speed);
    }
    // Update is called once per frame
    private void Update()
    {
        RaycastHit2D rayL = Physics2D.Raycast(new Vector2(transform.position.x - 0.4f, transform.position.y - 0.7f), Vector2.down, 0.05f, ~(LayerMask.GetMask("Enemies") + LayerMask.GetMask("EnemyProjectiles") + LayerMask.GetMask("Ignore Raycast")));
        Debug.DrawRay(new Vector2(transform.position.x - 0.4f, transform.position.y - 0.7f), Vector2.down * 0.05f, Color.red);
        RaycastHit2D rayM = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - 0.7f), Vector2.down, 0.05f, ~(LayerMask.GetMask("Enemies") + LayerMask.GetMask("EnemyProjectiles") + LayerMask.GetMask("Ignore Raycast")));
        Debug.DrawRay(new Vector2(transform.position.x, transform.position.y - 0.7f), Vector2.down * 0.05f, Color.yellow);
        RaycastHit2D rayR = Physics2D.Raycast(new Vector2(transform.position.x + 0.4f, transform.position.y - 0.7f), Vector2.down, 0.05f, ~(LayerMask.GetMask("Enemies") + LayerMask.GetMask("EnemyProjectiles") + LayerMask.GetMask("Ignore Raycast")));
        Debug.DrawRay(new Vector2(transform.position.x + 0.4f, transform.position.y - 0.7f), Vector2.down * 0.05f, Color.blue);
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
        if (rayM.collider != null && !isGrounded)
        {
            if (rayM.collider.gameObject.layer == 3)
            {
                isGrounded = true;
            }
        }
        else if (rayR.collider != null && !isGrounded)
        {
            if (rayR.collider.gameObject.layer == 3)
            {
                isGrounded = true;
            }
        }
        //animation thinger
        
        anim.SetBool("Grounded", isGrounded);

        if (Input.GetAxis("Horizontal") > 0.001f && !anim.GetBool("hurt"))
        {
            GetComponent<SpriteRenderer>().flipX = false;
            anim.SetBool("Walking", true);
        }
        else if (Input.GetAxis("Horizontal") < -0.001f && !anim.GetBool("hurt"))
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
