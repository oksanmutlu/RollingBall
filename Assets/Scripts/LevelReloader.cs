using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelReloader : MonoBehaviour
{  
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            DataManager.dataManager.ReloadLevel();         
        }
    }
}
