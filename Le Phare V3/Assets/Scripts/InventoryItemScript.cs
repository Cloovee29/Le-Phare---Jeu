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

    public static targetObjectToUseScript targetObject; //enlever public static si problemes
    GameObject targetGameObject;

    public InventoryManagerScript inventoryManager;
    public DoorLevel1Zoom doorLevel1Zoom;

    public Sprite newDiplome;

    public Sprite portrait1OnWall;
    public Sprite portrait3OnWall;
    public Sprite portrait4OnWall;
    public Sprite portrait5OnWall;

    public PortraitsInstanciateScript portraitsInstanciate;

    public static Vector3 targetObjectPos;

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
            //Debug.Log("Did Hit");
            targetObject = hit.transform.GetComponent<targetObjectToUseScript>();
            targetGameObject = hit.transform.gameObject;

            // SCENE 1

            if (targetObject.targetName == CurrentItemIdName && targetObject.targetName == ItemName.Diplome)
            {
                ChangeDiplome();
            }

            if (targetObject.targetName == CurrentItemIdName && targetObject.targetName == ItemName.Key)
            {
                doorLevel1Zoom.OpenDoor();
                print("clemarche");
            }

            // SCENE 2 - LES PORTRAITS

            if (CurrentItemIdName == ItemName.Portrait1 && targetObject.targetName == ItemName.Portrait)
            {
                inventoryManager.DeleteItem(this);
                portraitsInstanciate.InstanciatePortrait1();
                targetObjectPos = targetObject.transform.position;
            }

            if (CurrentItemIdName == ItemName.Portrait3 && targetObject.targetName == ItemName.Portrait)
            {
                inventoryManager.DeleteItem(this);
                portraitsInstanciate.InstanciatePortrait3();
                targetObjectPos = targetObject.transform.position;
            }

            if (CurrentItemIdName == ItemName.Portrait5 && targetObject.targetName == ItemName.Portrait)
            {
                inventoryManager.DeleteItem(this);
                portraitsInstanciate.InstanciatePortrait5();
                targetObjectPos = targetObject.transform.position;
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

