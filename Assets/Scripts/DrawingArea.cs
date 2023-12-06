using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DrawingArea : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public DrawMesh drawMesh;

    public void OnPointerEnter(PointerEventData eventData)
    {
        drawMesh.isDrawing = true;
        Debug.Log("IN");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        drawMesh.isDrawing = false;
        Debug.Log("OUT");
    }
}
