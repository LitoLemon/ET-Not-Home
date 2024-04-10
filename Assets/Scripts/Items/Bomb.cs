using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float delay;
    public CircleCollider2D blastRadius;
    private List<GameObject> inRadius = new();
    private int i = 0;

    // Update is called once per frame
    void Update()
    {
        if(delay <= 0)
        {
            Explode();
        }
        else
        {
            delay -= Time.deltaTime;
        }
    }

    private void Explode()
    {
        if(i == 1)
        {
            Destroy(gameObject);
        }
        blastRadius.enabled = true;
        //activates the trigger
        i++;
        delay = 0.1f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //make sure to disable collision on the circle collider that you dont want to hit with the bomb.

        inRadius.Add(collision.gameObject);
        foreach(GameObject obj in inRadius)
        {
            RaycastHit2D ray = Physics2D.Raycast(transform.position, obj.transform.position - transform.position, float.PositiveInfinity, ~LayerMask.GetMask("PlayerProjectiles"));
            Debug.DrawRay(transform.position, obj.transform.position - transform.position, Color.blue, 2);
            if (ray.collider.gameObject == obj)
            {
                if (obj.layer == 9)
                {
                    InventoryManager.AdjustItemAmount("Hp", -1);
                }
                else
                {
                    try
                    {
                        Destroy(obj.transform.parent.gameObject);
                    }
                    catch
                    {
                        Destroy(obj);
                    }
                }
            }
        }
                
    }
}
