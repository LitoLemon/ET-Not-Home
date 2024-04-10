using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Rotate360 : MonoBehaviour
{
    public float speed;

    void Update()
    {
        try
        {
            if ((GetComponent<SpriteRenderer>().flipX && speed < 0) || (!GetComponent<SpriteRenderer>().flipX && speed > 0))
            {
                speed *= -1;
            }
            transform.Rotate(Vector3.forward * speed * Time.deltaTime);
        }
        catch
        {
            transform.Rotate(Vector3.forward * -speed * Time.deltaTime);
        }
    }
}
