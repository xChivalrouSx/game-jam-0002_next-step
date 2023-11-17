using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.RendererUtils;
using UnityEngine.UI;

public class PapersShown : MonoBehaviour
{
    [SerializeField] GameObject papersList;
    [SerializeField] GameObject title;
    [SerializeField] GameObject content;
    [SerializeField] GameObject listItemPrefab;
    private int renderedCount=0;
    List<InventoryPaper> list;
    TextMeshProUGUI titleText;
    TextMeshProUGUI contentText;
    void Awake()
    {
      list = Inventory.INSTANCE.getPapers();
         titleText = title.GetComponent<TextMeshProUGUI>();
        titleText.text = list[0].getTitle();
         contentText = content.GetComponent<TextMeshProUGUI>();
        contentText.text = list[0].getTitle();


      
    }
    private void click(InventoryPaper item)
    {
        Debug.Log(item.getTitle());
        titleText.text = item.getTitle();
        contentText.text = item.getTitle();
    }

    // Update is called once per frame
    void Update()
    {
        if (renderedCount < list.Count)
        {
            for (int i = renderedCount; i < list.Count; i++)
            {
                InventoryPaper item = list[i];

                GameObject newButton = Instantiate(listItemPrefab, papersList.transform);
                newButton.GetComponent<Button>().onClick.AddListener(() =>
                {
                    click(item);
                });
                renderedCount++;

            }
        }
    }
}
