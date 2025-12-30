using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class WordScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    public TextMeshProUGUI word;
    public Image wordTagBackground;
    private float YBasic;
    public MouseAspectManagerScript mouseAspectManagerScript;

    float XBasic;

    Vector3 mouseWorldPosition;
    [SerializeField] private Camera mainCamera;

    public GameObject page;

    int compteurMots;

    bool isCorrectlyPlaced = false;

    public PageScript pageScript;

    HoleScript currentCorrectHole = null;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    public void CreateWord(string newWord, float newX)
    {
        word.text = newWord;
        XBasic = newX;
        GetComponent<RectTransform>().anchoredPosition = new Vector2(newX, -156);
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        if (isCorrectlyPlaced) return;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Cursor.SetCursor(mouseAspectManagerScript.grabCursor, mouseAspectManagerScript.hotSpot, mouseAspectManagerScript.cursorMode); 
        if (isCorrectlyPlaced) return;
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Cursor.SetCursor(mouseAspectManagerScript.defaultCursor, mouseAspectManagerScript.hotSpot, mouseAspectManagerScript.cursorMode);
        canvasGroup.blocksRaycasts = true;
        if (isCorrectlyPlaced) return;
        if (currentCorrectHole != null && !isCorrectlyPlaced)
        {
            rectTransform.position = currentCorrectHole.transform.position;
            isCorrectlyPlaced = true;
            pageScript.MotCorrect();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isCorrectlyPlaced) return;

        HoleScript hole = collision.GetComponent<HoleScript>();
        if (hole != null && word.text == hole.answer)
        {
            currentCorrectHole = hole;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isCorrectlyPlaced) return;

        HoleScript hole = collision.GetComponent<HoleScript>();
        if (hole != null && hole == currentCorrectHole)
        {
            currentCorrectHole = null;
        }
    }
}
