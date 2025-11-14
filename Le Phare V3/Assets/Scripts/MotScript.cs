using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class MotScript : MonoBehaviour
{

 public string word; // le mot utilisé pour remplir le journal
    private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GetComponentInParent<Canvas>();
        GetComponentInChildren<TextMeshProUGUI>().text = word;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


     public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
    }

}
