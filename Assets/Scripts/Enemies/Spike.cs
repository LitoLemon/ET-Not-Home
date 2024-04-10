using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public float timerMax;
    public float speed;
    private bool goDown = true;
    private Vector3 startPos;
    private float timer;
    private Vector2 direction = new Vector2(0, -1);
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer <= 0)
        {
            transform.Translate(speed * Time.deltaTime * direction);
            if(transform.position.y >= startPos.y && !goDown)
            {
                direction *= -1;
                timer = timerMax;
                goDown = true;
            }
            else if (transform.position.y <= startPos.y - (GetComponent<BoxCollider2D>().size.y - (GetComponent<BoxCollider2D>().offset.y * 2)) && goDown)
            {
                direction *= -1;
                timer = timerMax;
                goDown = false;
            }
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}
