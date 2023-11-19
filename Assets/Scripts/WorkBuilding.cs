using TMPro;
using UnityEngine;

public class WorkBuilding : MonoBehaviour
{
    [SerializeField] private TMP_Text hourInfoText;
    [SerializeField] private Camera camera;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        hourInfoText.text = "18:00";
        camera.backgroundColor = new Color(33f / 255f, 45f / 255f, 65f / 255f, 0);
    }

}
