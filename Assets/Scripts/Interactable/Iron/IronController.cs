using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iron : MonoBehaviour
{
    
    void Start()
    {
        
    }

    void Update()
    {
       
    }

    public void TakeIron()
    {
        Debug.Log("Taken Iron");
        Inventory.INSTANCE.addIron();
        Destroy(gameObject);

    }
}
