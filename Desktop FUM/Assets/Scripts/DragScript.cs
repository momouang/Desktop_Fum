using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragScript : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas myCanvas;

    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("Start Drag");
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("On Drag");
        rectTransform.anchoredPosition += eventData.delta / myCanvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("End Drag");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("pointer down");
    }
}
