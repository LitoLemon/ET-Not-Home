using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float delay;
    public float blastRadius;
    public int rayAmount;
    //private List<GameObject> inRadius = new();

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
        float x = 1;
        float y = -1;
        for (int i = 0; i <= rayAmount; i++)
        {
            /*            float y = 1f - (1f / rayAmount * i);
                        float x = 0f + (1f - y);
                        if(y > x && (y != 1 || y != 0 || y != -1))
                        {
                            y *= 2f - y;
                            x *= 2f - y;
                        }
                        else if(x != 0 )
                        {
                            y *= 2f - x;
                            x *= 2f - x;
                        }*/



            Vector3 direction = new Vector3(x, y);
            Debug.Log(direction);

/* 
 * (1,0) = right
 * (0,1) = up
 * (0.5,0.5) = up right?
 * ^yes, but makes the distance shorter
 * (1,1) = up right?
 */               
            Ray ray = new Ray(transform.position, direction);

            Debug.DrawRay(transform.position, direction * blastRadius, Color.red, 1);
            if(Physics.Raycast(ray, out RaycastHit hit, blastRadius))
            {

            }

            x -= 0.1f;
            y += 0.1f;

            
                    
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
                
    */
    }
}
