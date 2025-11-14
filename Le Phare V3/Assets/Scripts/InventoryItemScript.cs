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

    //void Start()
    //{
    //    InitialiseItem(item);
    //}

    void Start()
    {
        image = GetComponent<Image>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //image.raycastTarget = false;
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        print("begindrag");
        isDraging = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
        isDraging = true;
        print("ondrag");

        //trouver un moyen de trouver le nom de l'image de inventoryitem pour faire des conditions selon l'image

        //if (sprite.name = ("PH-obj_8") )
        {

        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //image.raycastTarget = true;
        transform.SetParent(parentAfterDrag);
        print("enddrag");
        isDraging = false;
    }

    void Awake()
    {
        image = GetComponent<Image>(); // récupère le composant Image automatiquement
    }

    public void InitialiseItem(Item newItem)
    {
        item = newItem;
        image.sprite = newItem.image;
    }

    void Update()
    {

    }
}
