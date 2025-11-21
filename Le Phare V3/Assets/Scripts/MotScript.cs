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
    private bool dansLeTrou;

    private float YBasique;

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
if(!dansLeTrou){

}

    }

    private void OnTriggerEnter2D (Collider2D collision){
        dansLeTrou = true;
         Debug.Log("Le mot est entré dans le trou !");
        
    }

    private void OnTriggerExit2D (Collider2D collision){
        dansLeTrou = false;
         Debug.Log("Le mot est sorti du trou !");
        
    }

}
