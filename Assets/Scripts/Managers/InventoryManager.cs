using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InventoryManager : MonoBehaviour
{
    public static bool loadingScene = false;
    public static Dictionary<string, int> Inventory = new()
    {
        {"Hp", 3},
        {"Bomb", 1},
        {"Fireball", 4}
    };

    public static void AdjustItemAmount(string itemName, int amount)
    {
        Inventory[itemName] += amount;
        UpdateUI();
        CheckIfDead();
    }
    
    private static void UpdateUI()
    {
        //Update the UI
    }

    public static void CheckIfDead()
    {
        if (Inventory["Hp"] <= 0)
        {
            //EndSceneManager.died = true;
            loadingScene= true;
            SceneManager.LoadScene("EndScene");
        }
    }
}
