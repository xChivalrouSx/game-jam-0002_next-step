using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainLevel : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private TMP_Text infoText;
    [SerializeField] private GameObject paper;

    private bool isRefresh = false;
    void Awake()
    {
        isRefresh = true;
        if (MainLevelInfo.INSTANCE == null)
        {
            MainLevelInfo.INSTANCE.Count = 0;
        }
        infoText.text = (MainLevelInfo.INSTANCE.Count + 1) + ". Gün";
    }

    void Update()
    {
        if (MainLevelInfo.INSTANCE.Count == 2)
        {
            paper.SetActive(true);
        }       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (MainLevelInfo.INSTANCE.Count < 2 && isRefresh)
        {
            MainLevelInfo.INSTANCE.Count++;
            isRefresh = false;
            SceneManager.LoadScene("MainLevel");
        }
    }
}
