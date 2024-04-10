using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public int amount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            if (gameObject.tag != "Hp" || (gameObject.tag == "Hp" && InventoryManager.Inventory["Hp"] < 3))
            {
                InventoryManager.AdjustItemAmount(gameObject.tag, 1);
                try
                {
                    Destroy(transform.parent.gameObject);
                    Debug.Log("Destroyed parent");
                }
                catch
                {
                    Debug.Log("Destroyed object");
                    Destroy(gameObject);
                }
            }
        }
            
    }
}