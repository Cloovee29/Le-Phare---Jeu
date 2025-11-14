using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class MotScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

// public string mot; // le mot utilisé pour remplir le journal
    public Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
      //  GetComponentInChildren<TextMeshPro>().text = mot;
    }

  

     public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.6f; 
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }

}
