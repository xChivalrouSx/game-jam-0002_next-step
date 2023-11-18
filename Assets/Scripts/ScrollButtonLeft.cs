using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScrollButtonLeft : MonoBehaviour
{

    [SerializeField] private GameObject scroll;
    private ScrollRect scrollRect;
    private float scrollSpeed = 0.50f;
    private void Awake()
    {
        scrollRect= scroll.GetComponent<ScrollRect>();

    }
    public void ScrollLeft()
    {
        if (scrollRect != null)
        {
            if (scrollRect.horizontalNormalizedPosition >= 0f)
            {
                scrollRect.horizontalNormalizedPosition -= scrollSpeed;
            }
        }
    }
}
