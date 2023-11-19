using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ConrolsCenter : MonoBehaviour
{
    [SerializeField] GameObject listItemPrefab;
    [SerializeField] GameObject ControlList;
    struct Control
    {
        string name;
        string key;
        public Control(string _name, string _key)
        {
            this.name = _name;
            this.key = _key;
        }
        public string getName()
        {
            return this.name;
        }

        public string getKey()
        {
            return this.key;
        }
    }
    // Start is called before the first frame update
    private List<Control> list=new List<Control>();
    void Awake()
    {
        SetListItem();
        for (int i = 0; i < list.Count; i++)
        {
            Control item = list[i];
            GameObject newButton = Instantiate(listItemPrefab, ControlList.transform);
     
             newButton.GetComponent<ControlListItem>().nameTextVal = item.getName();
            newButton.GetComponent<ControlListItem>().keyTextVal = item.getKey();
           
            

        }
    }

    private void SetListItem()
    {
        list.Add(new Control("Men� yukar�", KeyCode.UpArrow.ToString()));
        list.Add(new Control("Men� asa��", KeyCode.DownArrow.ToString()));
        list.Add(new Control("Men� se�", KeyCode.Space.ToString()+" | Enter"));
        list.Add(new Control("Men� geri", KeyCode.Escape.ToString()));
        list.Add(new Control("Durdur/Ba�lat", KeyCode.Escape.ToString()));
        list.Add(new Control("Sola git", KeyCode.A.ToString()));
        list.Add(new Control("Sa�a git", KeyCode.D.ToString()));
        list.Add(new Control("Z�pla", KeyCode.Space.ToString()));
        list.Add(new Control("Z�pla ve t�rman", KeyCode.Space.ToString() +" + ( "+ KeyCode.D.ToString() + " | " +KeyCode.A.ToString() + " )"));
        list.Add(new Control("Konu�ma metnini ilerlet", KeyCode.Z.ToString()));
        list.Add(new Control("Malzeme toplama", KeyCode.Z.ToString()));
        list.Add(new Control("Toplanan ka��t i�eri�ini kapatma", KeyCode.Tab.ToString()));
    }
    // Update is called once per frame

}
