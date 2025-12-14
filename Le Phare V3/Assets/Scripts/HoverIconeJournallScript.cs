using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverIconeJounralScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    float durationHover = 0.5f;
    RectTransform rectTransform;
    Vector3 initialScale;

    void Start()
    {
        rectTransform = GetComponentInChildren<RectTransform>();
        initialScale = rectTransform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        print("mouse enter");
        rectTransform.DOScale(initialScale * 1.3f, durationHover).SetEase(Ease.OutCubic);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        rectTransform.DOScale(initialScale, durationHover).SetEase(Ease.OutCubic);
    }
}
