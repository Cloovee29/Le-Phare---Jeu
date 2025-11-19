using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItemScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("UI")]

    [HideInInspector] public Image image;
    [HideInInspector] public Item item;

    Transform parentAfterDrag;

    public string CurrentItemIdName { get; set; }

    Vector3 mouseWorldPosition;

    private RectTransform rectTransform;

    [SerializeField] private Camera mainCamera;
    [SerializeField] private Canvas canvas;

    LayerMask layerMask;

    void Start()
    {
        image = GetComponent<Image>();
    }

    void Awake()
    {
        //layerMask = LayerMask.GetMask("InteractibleObjects");
        rectTransform = GetComponent<RectTransform>();

        image = GetComponent<Image>();
    }

    void FixedUpdate()
    {
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))

        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            Debug.Log("Did not Hit");
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //print(CurrentItemIdName);

        if (CurrentItemIdName != null)
        {
            parentAfterDrag = transform.parent;
            transform.SetParent(transform.root);
            transform.SetAsLastSibling();
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (CurrentItemIdName != null)
        {
            //mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            //mouseWorldPosition.z = 0f;

            ////print(mouseWorldPosition);
            ////print(Input.mousePosition);
            //mouseWorldPosition.z = 0f;

            ////transform.position = Input.mousePosition;
            //transform.position = mouseWorldPosition;

            //Vector2 pos;
            //RectTransformUtility.ScreenPointToLocalPointInRectangle(
            //    canvas.transform as RectTransform,
            //    Input.mousePosition,
            //    mainCamera,
            //    out pos
            //);

            //rectTransform.anchoredPosition = pos;

            Vector2 uiPosition;

            // Convertit la position de la souris (écran) en position locale UI
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                canvas.transform as RectTransform,
                Input.mousePosition,
                mainCamera,
                out uiPosition
                );

            rectTransform.anchoredPosition = uiPosition;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        if (CurrentItemIdName != null)
        {
            transform.SetParent(parentAfterDrag); 
        }


    }

    public void InitialiseItem(Item newItem)
    {
        item = newItem;
        image.sprite = newItem.image;
    }
}
