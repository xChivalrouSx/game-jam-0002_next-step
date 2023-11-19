using TMPro;
using UnityEngine;

public class HomeBuilding : MonoBehaviour
{
    [SerializeField] private TMP_Text dayInfoText;
    [SerializeField] private TMP_Text hourInfoText;
    [SerializeField] private GameObject paperObject;
    [SerializeField] private Camera camera;

    private int dayCount = 1;

    private void Awake()
    {
        dayInfoText.text = dayCount + ". Gün";
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hourInfoText.text.Equals("09:00")) { return; }

        dayInfoText.text = ++dayCount + ". Gün";
        hourInfoText.text = "09:00";
        camera.backgroundColor = new Color(79f / 255f, 114f / 255f, 168f / 255f, 0);
        if (dayCount == 3)
        {
            paperObject.SetActive(true);
        }
        else if (dayCount >= 5)
        {
            paperObject.transform.localScale += Vector3.one;
        }
    }

}
