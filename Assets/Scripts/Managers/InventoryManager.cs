using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InventoryManager : MonoBehaviour
{
    public static Dictionary<string, int> Inventory = new()
    {
        {"Hp", 3},
        {"Bomb", 1},
        {"Fireball", 4}
    };

    public static void AdjustItemAmount(string itemName, int amount)
    {
        Inventory[itemName] += amount;
        
        if (CheckIfDead())
        {
            MySceneManager.LoadLastScene();
        }
        else
        {
            UIManager thisUIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
            thisUIManager.UpdateUI();
        }
    }
   

    public static bool CheckIfDead()
    {
        if (Inventory["Hp"] <= 0)
        {
            return true;
        }
        return false;
    }
}
