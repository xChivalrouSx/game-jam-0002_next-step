using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeText : MonoBehaviour
{
    [SerializeField] string volumeName;
    [SerializeField] string text;
    private Text txt;

    private void Awake()
    {
        txt = GetComponent<Text>();
    }

    private void Update()
    {
        UpdateVolume();
    }

    private void UpdateVolume()
    {
        float volume = 100 * PlayerPrefs.GetFloat(volumeName);
        txt.text = text + volume;
    }

}
