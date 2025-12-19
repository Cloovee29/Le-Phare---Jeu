using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class WordScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    public TextMeshProUGUI word;
    private float YBasic;

    Vector3 mouseWorldPosition;
    [SerializeField] private Camera mainCamera;

    public bool isLocked;
    public GameObject page;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        isLocked = false;
}

    //Y de 400 à -200
     public void CreateWord(string newWord, float newY)
    {
        word.text = newWord;
        YBasic = newY;
        GetComponent<RectTransform>().anchoredPosition = new Vector2(120,newY);
    }
  
    
     public void OnBeginDrag(PointerEventData eventData)
    {
        if (isLocked) return;
        canvasGroup.alpha = 0.6f; 
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isLocked) return;
        transform.position = Input.mousePosition; // nouveau code = le mot suit bien l'image pendant le drag
    }

    public void OnEndDrag(PointerEventData eventData)
    {
      
        if (isLocked) return;
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        transform.position = Input.mousePosition; // nouveau code = si je mets pas ca il se place bizarrement à la fin du drag
       
    }

    private void OnTriggerEnter2D (Collider2D collision){
        

        HoleScript hole = collision.GetComponent<HoleScript>();
        

        if (hole != null)
        {
            
            if (word.text == hole.answer)
            {
                isLocked = true;
                page.GetComponent<PageScript>().CompletePage();
                canvasGroup.alpha = 1f;
            }
        }

    }

}
