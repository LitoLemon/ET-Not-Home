using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBorder : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 9)
        {
            collision.gameObject.transform.position = player_movement.startPos;
            InventoryManager.AdjustItemAmount("Hp", -1);
        }
        else
        {
            try
            {
                Destroy(collision.gameObject.transform.parent.gameObject);
            }
            catch
            {
                Destroy(collision.gameObject);
            }
        }
    }
}
