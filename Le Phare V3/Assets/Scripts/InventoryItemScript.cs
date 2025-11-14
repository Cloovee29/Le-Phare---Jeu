using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItemScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [Header("UI")]

    [HideInInspector] public Image image;
    [HideInInspector] public Item item;

    Transform parentAfterDrag;
    bool isDraging = false;

    public string CurrentItemIdName { get; set; }

    //public InventorySlotScript[] inventorySlots;

    void Start()
    {
        image = GetComponent<Image>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {

        print(CurrentItemIdName);
        //image.raycastTarget = false;
        if (CurrentItemIdName != null)
        {
            //isDraging = true;
            parentAfterDrag = transform.parent;
            transform.SetParent(transform.root);
            transform.SetAsLastSibling();

        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (CurrentItemIdName != null)
        {
            transform.position = Input.mousePosition;
            //isDraging = true;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //image.raycastTarget = true;
        if (CurrentItemIdName != null)
        {
            transform.SetParent(parentAfterDrag);
        }

        //isDraging = false;
    }

    void Awake()
    {
        image = GetComponent<Image>();
    }

    public void InitialiseItem(Item newItem)
    {
        item = newItem;
        image.sprite = newItem.image;
    }

    void Update()
    {
        if (CurrentItemIdName == "cle")
        {
            GameObject.Destroy(gameObject);
        }
    }
}
