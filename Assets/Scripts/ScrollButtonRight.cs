using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ScrollButtonRight : MonoBehaviour
{
    [SerializeField] private GameObject scroll;
    private ScrollRect scrollRect;
    private float scrollSpeed = 0.50f;
    private void Awake()
    {
        scrollRect = scroll.GetComponent<ScrollRect>();

    }
    public void ScrollRight()
    {
        if (scrollRect != null)
        {
            if (scrollRect.horizontalNormalizedPosition <= 1f)
            {
                scrollRect.horizontalNormalizedPosition += scrollSpeed;
            }
        }
    }
}
