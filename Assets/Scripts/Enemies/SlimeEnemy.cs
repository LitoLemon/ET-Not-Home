using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeEnemy : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;

    private void Flip()
    {
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        speed *= -1;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D rayDown = Physics2D.Raycast(transform.position + new Vector3(0.25f * transform.localScale.x , transform.localScale.y * -0.25f), Vector2.down, 0.05f, ~(LayerMask.GetMask("Items") + LayerMask.GetMask("Enemies") + LayerMask.GetMask("Ignore Raycast")));
        Debug.DrawRay(transform.position + new Vector3(0.25f * transform.localScale.x, transform.localScale.y * -0.25f), Vector2.down * 0.05f, Color.blue);
        RaycastHit2D raySide = Physics2D.Raycast(transform.position + new Vector3(0.25f * transform.localScale.x, transform.localScale.y * -0.125f), Vector2.left * (transform.localScale.x / -transform.localScale.x /*<- zorgt dat het getal -1 is. 
        * zorgt dat het getal positief is als hij eerder negatief was en tegenovergestelde->*/ * transform.localScale.x), 0.06f, ~(LayerMask.GetMask("Items") + LayerMask.GetMask("Ignore Raycast")));
        Debug.DrawRay(transform.position + new Vector3(0.25f * transform.localScale.x, transform.localScale.y * -0.125f), Vector2.left * (transform.localScale.x / -transform.localScale.x * transform.localScale.x) * 0.06f, Color.red);
        if (rayDown.collider == null || rayDown.collider.gameObject.layer != 3 || (raySide.collider != null && raySide.collider.gameObject.layer != 9 && raySide.collider.gameObject.layer != 10))
        {
            Flip();
        }

        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

}
