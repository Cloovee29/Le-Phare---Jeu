using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class MotScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

// public string mot; // le mot utilisé pour remplir le journal
    public Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    public TextMeshProUGUI texte;

    Vector3 mouseWorldPosition;
    [SerializeField] private Camera mainCamera;
  //  [SerializeField] private Canvas canvas;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    //Y de 400 à -200
     public void CreerMot(string mot, float nouvelleY)
    {
        texte.text = mot;
    GetComponent<RectTransform>().anchoredPosition = new Vector2(290,nouvelleY);
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

        //code de clo
        mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mouseWorldPosition, transform.TransformDirection(Vector3.forward));
        if (hit)

        {
            Debug.DrawRay(mouseWorldPosition, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
            //hit.transform.targetObject;
            print("camarche");
        }
        else
        {
            Debug.DrawRay(mouseWorldPosition, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            //Debug.Log("Did not Hit");
        }

    }

}
