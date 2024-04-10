using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerDmg : MonoBehaviour
{
    public string[] excludeLayers;
    public float invTimeMax;
    public float changeSpeed;
    private bool invBool = false;
    private bool colorDown = true;
    private float invTime;
    private Rigidbody2D rb;
    private Animator anim;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == 7 || collision.collider.gameObject.layer == 8)
        {
            rb.excludeLayers = LayerMask.GetMask(excludeLayers);
            invTime = invTimeMax;
            invBool= true;
            anim.SetBool("hurt", true);
        }
    }
    private void Update()
    {
        if (invBool) 
        {
            if (invTime <= 0)
            {
                rb.excludeLayers -= LayerMask.GetMask(excludeLayers);
                invBool = false;

                GetComponent<SpriteRenderer>().color = Color.white;
            }
            else if(invTime <= invTimeMax/4*3)
            {
                anim.SetBool("hurt", false);
            }
            invTime -= Time.deltaTime;

            if(!colorDown)//makes player color go blinking mode
            {
                GetComponent<SpriteRenderer>().color =
                new Color
                (
                    GetComponent<SpriteRenderer>().color.r + (changeSpeed * Time.deltaTime),
                    GetComponent<SpriteRenderer>().color.g + (changeSpeed * Time.deltaTime),
                    GetComponent<SpriteRenderer>().color.b + (changeSpeed * Time.deltaTime)
                );
                if (GetComponent<SpriteRenderer>().color.r >= 1)
                {
                    colorDown = true;
                }
            }
            else
            {
                GetComponent<SpriteRenderer>().color =
                new Color
                (
                    GetComponent<SpriteRenderer>().color.r - (changeSpeed * Time.deltaTime),
                    GetComponent<SpriteRenderer>().color.g - (changeSpeed * Time.deltaTime),
                    GetComponent<SpriteRenderer>().color.b - (changeSpeed * Time.deltaTime)
                );
                if(GetComponent<SpriteRenderer>().color.r <= 0.5f)
                {
                    colorDown = false;
                }
            }

            
        }

        
        
    }
}
