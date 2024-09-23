using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 7 || (collision.gameObject.layer == 3 && collision.gameObject.CompareTag("Destroyable")))
        {
            try
            {
                collision.gameObject.GetComponent<EnemyStats>().hp -= 1;
                if(collision.gameObject.GetComponent<EnemyStats>().hp <= 0)
                {
                    try
                    {
                        Destroy(collision.transform.parent.gameObject);
                    }
                    catch
                    {
                        Destroy(collision.gameObject);
                    }
                }
            }
            catch
            {
                try
                {
                    collision.transform.parent.gameObject.GetComponent<EnemyStats>().hp -= 1;
                    if (collision.transform.parent.gameObject.GetComponent<EnemyStats>().hp <= 0)
                    {
                        Destroy(collision.transform.parent.gameObject);

                    }
                }
                catch { }
                
            }
        }
        Destroy(transform.parent.gameObject);
    }
}
