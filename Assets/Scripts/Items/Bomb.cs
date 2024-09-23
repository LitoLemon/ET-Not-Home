using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float delay;
    public CircleCollider2D blastRadius;
    public int rayAmount;
    //private List<GameObject> inRadius = new();
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
        for (int i = 0; i < rayAmount; i++)
        {
            float y = 1 / (rayAmount / 2) * (rayAmount / 2 - i);
            if(i > rayAmount / 2)
            {

            }
            float x = 0 - (1 - y);
            Vector3 direction = new Vector3();
            Ray ray = new Ray(transform.position, )
            if
        }
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        
        
        /*
        //make sure to disable collision on the circle collider that you dont want to hit with the bomb.
        if (collision.gameObject.CompareTag("Destroyable") *//*&& !collision.gameObject.CompareTag("Undestroyable")*//*)
        {
            inRadius.Add(collision.gameObject);
            Debug.Log(collision.gameObject + " added");
        }

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
                
    }*/
}
