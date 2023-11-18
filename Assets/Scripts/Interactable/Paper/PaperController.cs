using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Paper : MonoBehaviour
{
    [SerializeField] private string title;
    [SerializeField] private string Value;
    [SerializeField] private GameObject DetailPanel;
    [SerializeField] private TextMeshProUGUI Title;
    [SerializeField] private TextMeshProUGUI Content;

    void Start()
    {
        
    }

    void Update()
    {
       
    }

    private void showPaper()
    {
        Title.SetText(title);
        Content.SetText(Value);
        DetailPanel.SetActive(true);
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
    public void TakePaper()
    {
        showPaper();
        Debug.Log("Taken paper");
        Inventory.INSTANCE.addPaper(title, Value);     

    }
}
