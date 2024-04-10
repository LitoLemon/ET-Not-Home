using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bomb;
    public GameObject fireball;
    public Vector2 fireballSpeed;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && InventoryManager.Inventory["Bomb"] > 0)
        {
            GameObject bombTemp = Instantiate(bomb, transform.position, Quaternion.identity);
            InventoryManager.AdjustItemAmount("Bomb", -1);
        }
        if (Input.GetKeyDown(KeyCode.F) && InventoryManager.Inventory["Fireball"] > 0)
        {
            GameObject fireballTemp = Instantiate(fireball, transform.position, Quaternion.identity);
            if (GetComponent<SpriteRenderer>().flipX && fireballSpeed.x > 0)
            {
                fireballSpeed *= -1;
            }
            fireballTemp.GetComponentInChildren<Rigidbody2D>().AddForce(fireballSpeed + GetComponent<Rigidbody2D>().velocity, ForceMode2D.Impulse);
            InventoryManager.AdjustItemAmount("Fireball", -1);
        }
    }
}
