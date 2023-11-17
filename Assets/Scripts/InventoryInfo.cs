using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryInfo : MonoBehaviour
{
    [SerializeField] GameObject PaperInfo;
    [SerializeField] GameObject IronInfo;
    [SerializeField] GameObject CoperInfo;
    [SerializeField] GameObject PapersPanel;
    private TextMeshProUGUI paperCount;
    private TextMeshProUGUI ironCount;
    private TextMeshProUGUI coperCount;
    // Start is called before the first frame update
    void Awake()
    {
        paperCount = PaperInfo.GetComponent<TextMeshProUGUI>();
        ironCount = IronInfo.GetComponent<TextMeshProUGUI>();
        coperCount = CoperInfo.GetComponent<TextMeshProUGUI>();
        
    }

    // Update is called once per frame
    void Update()
    {
        paperCount.text = Inventory.INSTANCE.getPapers().Count.ToString();
        ironCount.text = Inventory.INSTANCE.getIronCount().ToString();
        coperCount.text = Inventory.INSTANCE.getCoperCount().ToString();
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            PapersPanel.SetActive(!(PapersPanel.active));
        }
    }
}
