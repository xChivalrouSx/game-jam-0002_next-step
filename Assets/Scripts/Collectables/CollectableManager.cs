using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableManager : MonoBehaviour
{
    public static CollectableManager Instance;

    private List<Collectable> Collectables = new List<Collectable>();

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }

    }

    public void AddCollectable(Collectable collectable)
    {
        Collectables.Add(collectable);
    }
}
