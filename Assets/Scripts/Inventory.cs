using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{

    private List<InventoryPaper> papers;
    private int ironCount;
    private int coperCount;

    private static Inventory instance;

    private Inventory()
    {
        papers = new List<InventoryPaper>();
        ironCount = 0;
        coperCount = 0;
    }
    public static Inventory INSTANCE
    {
        get
        {
            if (instance == null)
            {
                instance = new Inventory();
            }
            return instance;
        }
    }
    public List<InventoryPaper> getPapers()
    {
        return papers;
    }

    public void addPaper(string _title, string _value)
    {
        papers.Add(new InventoryPaper(_title, _value));
        Debug.Log(papers.Count);
    }

    public int getIronCount()
    {
        return this.ironCount;
    }

    public void addIron()
    {
        this.ironCount += 1;
        Debug.Log(this.ironCount);
    }
    public int getCoperCount()
    {
        return this.coperCount;
    }

    public void addCoper()
    {
        this.coperCount += 1;
        Debug.Log(this.coperCount);
    }

}
