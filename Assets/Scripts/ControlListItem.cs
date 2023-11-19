using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ControlListItem : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI keyText;
    public string nameTextVal="";
    public string keyTextVal = "";
    private bool setup=true;
    void Start()
    {
        nameText.text = nameTextVal;
        keyText.text = keyTextVal;
    }

    // Update is called once per frame
    void Update()
    {
        if (setup)
        {
            nameText.text = nameTextVal;
            keyText.text = keyTextVal;
            setup =false;
        }
    }
}
