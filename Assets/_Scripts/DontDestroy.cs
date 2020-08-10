using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    
    private void Awake()
    {
        GameObject[] managers = GameObject.FindGameObjectsWithTag("Manager");
        if (managers.Length > 1)
        {
            Destroy(gameObject); 
        }
        DontDestroyOnLoad(gameObject);
    }
}
