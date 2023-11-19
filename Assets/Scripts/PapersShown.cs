using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PapersShown : MonoBehaviour
{
    [SerializeField] GameObject papersList;
    [SerializeField] GameObject title;
    [SerializeField] GameObject content;
    [SerializeField] GameObject listItemPrefab;
    private int renderedCount=0;
    List<InventoryPaper> list;
    void Awake()
    {
        list = Inventory.INSTANCE.getPapers();
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
                newButton.GetComponent<Image>().color = new Color(255, 255, 255, 1f);
                newButton.GetComponent<Button>().onClick.AddListener(() =>
                {
                    title.GetComponent<TextMeshProUGUI>().text = item.getTitle();
                    content.GetComponent<TextMeshProUGUI>().text = item.getValue();
                    newButton.GetComponent<Image>().color = new Color(255, 255, 255,0.6f);
                });
                renderedCount++;

            }
        }
    }
}
