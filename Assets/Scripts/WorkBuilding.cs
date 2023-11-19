using TMPro;
using UnityEngine;

public class WorkBuilding : MonoBehaviour
{
    [SerializeField] private TMP_Text hourInfoText;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        hourInfoText.text = "18:00";
    }

}
