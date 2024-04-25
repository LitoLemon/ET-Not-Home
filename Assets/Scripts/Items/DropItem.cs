using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{

    [SerializeField] public GameObject[] items;
    private bool quitting = false;

    private void Start()
    {
        MySceneManager.loadingScene = false;
    }
    private void OnApplicationQuit()
    {
        quitting= true;
    }
    private void OnDestroy()
    {
        if (!quitting && !MySceneManager.loadingScene)
        {
            int randInt = Random.Range(0, items.Length);
            Instantiate(items[randInt], transform.position, Quaternion.identity);
        }

    }
}
