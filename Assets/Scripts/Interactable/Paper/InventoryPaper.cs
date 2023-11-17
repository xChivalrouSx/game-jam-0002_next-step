using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPaper
{
    private string title;
    private string Value;
    public InventoryPaper (string _title, string _value)
    {
        this.title = _title;
        this.Value = _value;
    }
       
    public string getTitle()
    {
        return this.title;
    }
    public string getValue()
    {
        return this.Value;
    }
}
