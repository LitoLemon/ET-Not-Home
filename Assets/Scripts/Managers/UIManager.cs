using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject[] UIArray;
    public void UpdateUI()
    {
        foreach(GameObject obj in UIArray)
        {
            switch (obj.tag)
            {
                case "Hp":
                    Debug.Log("Case Hp entered");
                    if(int.Parse(obj.name) <= InventoryManager.Inventory["Hp"])
                    {
                        obj.SetActive(true);
                    }
                    else
                    {
                        obj.SetActive(false);
                    }
                break;

                case "Bomb":
                    obj.GetComponent<TextMeshProUGUI>().text = InventoryManager.Inventory["Bomb"].ToString();
                    break;

                case "Fireball":
                    obj.GetComponent<TextMeshProUGUI>().text = InventoryManager.Inventory["Fireball"].ToString();
                    break;

                case "EndSceneTxt":
                    if (MySceneManager.won)
                    {
                        obj.GetComponent<TextMeshProUGUI>().text = "You won! \n Play again?";
                    }
                    else
                    {
                        obj.GetComponent<TextMeshProUGUI>().text = "You Lost... \n Try again?";
                    }
                    break;
            }
        }


/*        List<GameObject> UIList = new();
        //Creating a list of every UI object
        int myInt = 0;
        foreach (GameObject obj in FindObjectsOfType(typeof(GameObject)))
        {
            Debug.Log(obj.name);
            if (obj.layer == 5)
            {
                Debug.Log("Object has layer 5!");
                UIList.Append(obj as GameObject);
                Debug.Log(UIList.Count*//*UIList[myInt]*//*);
                myInt++;
            }
        }
        Debug.Log("Update called");
        Debug.Log(UIList);
        foreach(GameObject UI in UIList)
        {
            Debug.Log("ForEach entered. UI: " + UI);
            switch (UI.tag)
            {
                case "Hp":
                    Debug.Log("Case Hp entered");
                    RectTransform[] hearts = UI.GetComponentsInChildren<RectTransform>();
                    foreach(RectTransform t in hearts)
                    {
                        for(int i = 0; i < hearts.Length; i++)
                        {
                            if (i < InventoryManager.Inventory["Hp"])
                            {
                                t.gameObject.SetActive(true);
                            }
                            else
                            {
                                t.gameObject.SetActive(false);
                            }
                        }
                    }
                    break;
                //Updateing UI for EndScene :)
                case "EndSceneText":
                    if (MySceneManager.won)
                    {
                        UI.GetComponent<TextMeshProUGUI>().text = "You won! \n Play again?";
                    }
                    else
                    {
                        UI.GetComponent<TextMeshProUGUI>().text = "You Lost... \n Try again?";
                    }
                    break;
            }
        }*/


        


    }

    private void Start()
    {
        UpdateUI();
    }
}
