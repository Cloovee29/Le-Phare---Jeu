using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InventoryItemScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("UI")]

    [HideInInspector] public Image image;
    [HideInInspector] public Item item;

    Transform parentAfterDrag;

    public ItemName? CurrentItemIdName { get; set; }

    Vector3 mouseWorldPosition;

    [SerializeField] private Camera mainCamera;
    [SerializeField] private Canvas canvas;

    targetObjectToUseScript targetObject;
    GameObject targetGameObject;

    public InventoryManagerScript inventoryManager;
    public DoorLevel1Zoom doorLevel1Zoom;

    public Sprite newDiplome;

    public Sprite portrait1OnWall;
    public Sprite portrait2OnWall;
    public Sprite portrait3OnWall;
    public Sprite portrait4OnWall;
    public Sprite portrait5OnWall;

    //public GameObject zoomSerrure;

    void Start()
    {
        image = GetComponent<Image>();    
    }

    void Awake()
    {        
        image = GetComponent<Image>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
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
            transform.position = Input.mousePosition;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        if (CurrentItemIdName != null)
        {
            transform.SetParent(parentAfterDrag);          
        }

        mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mouseWorldPosition, transform.TransformDirection(Vector3.forward));

        if (hit)
        {
            Debug.DrawRay(mouseWorldPosition, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
            targetObject = hit.transform.GetComponent<targetObjectToUseScript>();
            targetGameObject = hit.transform.gameObject;

            if (targetObject.targetName == CurrentItemIdName && targetObject.targetName == ItemName.Diplome)
            {
                ChangeDiplome();
            }

            if (targetObject.targetName == CurrentItemIdName && targetObject.targetName == ItemName.Key)
            {
                doorLevel1Zoom.OpenDoor();
                print("clemarche");
            }

            if (targetObject.targetName == CurrentItemIdName && targetObject.targetName == ItemName.Portrait1)
            {
                targetGameObject.GetComponent<SpriteRenderer>().sprite = portrait1OnWall;
                inventoryManager.DeleteItem(this);
            }

            if (targetObject.targetName == CurrentItemIdName && targetObject.targetName == ItemName.Portrait2)
            {
                targetGameObject.GetComponent<SpriteRenderer>().sprite = portrait2OnWall;
                inventoryManager.DeleteItem(this);
            }
            if (targetObject.targetName == CurrentItemIdName && targetObject.targetName == ItemName.Portrait3)
            {
                targetGameObject.GetComponent<SpriteRenderer>().sprite = portrait3OnWall;
                inventoryManager.DeleteItem(this);
            }
            if (targetObject.targetName == CurrentItemIdName && targetObject.targetName == ItemName.Portrait4)
            {
                targetGameObject.GetComponent<SpriteRenderer>().sprite = portrait4OnWall;
                inventoryManager.DeleteItem(this);
            }
            if (targetObject.targetName == CurrentItemIdName && targetObject.targetName == ItemName.Portrait5)
            {
                targetGameObject.GetComponent<SpriteRenderer>().sprite = portrait5OnWall;
                inventoryManager.DeleteItem(this);
            }
        }
        else
        {
            Debug.DrawRay(mouseWorldPosition, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
        }
    }

    public void InitialiseItem(Item newItem)
    {
        item = newItem;
        image.sprite = newItem.image;
    }

    public void ChangeDiplome()
    {
        targetGameObject.GetComponent<SpriteRenderer>().sprite = newDiplome;

        inventoryManager.DeleteItem(this);
        print("changerDiplome");
    }
}

