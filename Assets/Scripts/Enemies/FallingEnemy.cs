using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingEnemy : MonoBehaviour
{   
    public GameObject topStandable;
    public float speed;
    public float timeMax;
    private float time;
    public bool groundHit = false;
    private Vector3 startPos;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D rayL = Physics2D.Raycast(transform.position - new Vector3(transform.localScale.x * 0.7f / 2, transform.localScale.y * 0.7f / 2), Vector2.down, float.PositiveInfinity, ~LayerMask.GetMask("Ignore Raycast"));
        Debug.DrawRay(transform.position - new Vector3(transform.localScale.x * 0.7f / 2, transform.localScale.y * 0.7f / 2), Vector2.down, Color.blue);
        RaycastHit2D rayR = Physics2D.Raycast(transform.position + new Vector3(transform.localScale.x * 0.7f / 2, -transform.localScale.y * 0.7f / 2), Vector2.down, float.PositiveInfinity, ~LayerMask.GetMask("Ignore Raycast"));
        Debug.DrawRay(transform.position + new Vector3(transform.localScale.x * 0.7f / 2, -transform.localScale.y * 0.7f / 2), Vector2.down, Color.red);
        if (rayL.collider != null && rayL.collider.gameObject.layer == 9)
        {
            rb.constraints = ~RigidbodyConstraints2D.FreezePositionY;
        }
        else if(rayR.collider != null && rayR.collider.gameObject.layer == 9)
        {
            rb.constraints = ~RigidbodyConstraints2D.FreezePositionY;
        }

        if (groundHit)
        {
            transform.Translate(speed * Time.deltaTime * Vector2.up);
            if(transform.position.y >= startPos.y)
            {
                groundHit = false;
                rb.gravityScale = 1;
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
            }
        }
        if(time <=0)
        {
            topStandable.GetComponent<BoxCollider2D>().enabled = true;
        }
        else
        {
            time -= Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 3 && collision.gameObject != topStandable)
        {
            if (collision.collider.gameObject.layer == 3)
            {
                rb.gravityScale = 0;
                groundHit = true;
            }
            else if (collision.collider.gameObject.layer == 9)
            {
                topStandable.GetComponent<BoxCollider2D>().enabled = false;
                time = timeMax;
            }
        }
        
    }
}
