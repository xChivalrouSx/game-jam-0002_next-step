using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper : MonoBehaviour
{
    [SerializeField] private string title;
    [SerializeField] private string Value;
    
    void Start()
    {
        
    }

    void Update()
    {
       
    }

    public void TakePaper()
    {
        Debug.Log("Taken paper");
        Inventory.INSTANCE.addPaper(title, Value);
        Destroy(gameObject);

    }
}
