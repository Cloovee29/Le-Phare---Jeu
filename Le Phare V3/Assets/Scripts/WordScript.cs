using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class WordScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    public TextMeshProUGUI word;
    private bool inTheHole;
    private float YBasic;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        inTheHole = false;
    }

    //Y de 400 à -200
     public void CreateWord(string newWord, float newY)
    {
        word.text = newWord;
        YBasic = newY;
        GetComponent<RectTransform>().anchoredPosition = new Vector2(290,newY);
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

        if(!inTheHole){
            GetComponent<RectTransform>().anchoredPosition = new Vector2(290, YBasic);
        }
    }

    private void OnTriggerEnter2D (Collider2D collision){
        inTheHole = true;
         Debug.Log("Le mot est entré dans le trou !");
    }

    private void OnTriggerExit2D (Collider2D collision)
    {
        inTheHole = false;
         Debug.Log("Le mot est sorti du trou !");
        
    }

}
