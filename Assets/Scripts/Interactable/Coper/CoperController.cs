using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coper : MonoBehaviour
{
    
    void Start()
    {
        
    }

    void Update()
    {
       
    }

    public void TakeCoper()
    {
        Debug.Log("Taken Coper");
        Inventory.INSTANCE.addCoper();
        Destroy(gameObject);

    }
}
