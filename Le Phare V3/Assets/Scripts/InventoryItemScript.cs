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

    public targetObjectToUseScript targetObject; //enlever public static si problemes
    public GameObject targetGameObject; // enlever public si prob

    public InventoryManagerScript inventoryManager;

    //public Sprite portrait1OnWall;
    //public Sprite portrait3OnWall;
    //public Sprite portrait4OnWall;
    //public Sprite portrait5OnWall;

    public PortraitsInstanciateScript portraitsInstanciate;

    //public fieldGlassInstanciateScript fieldGlassInstanciate;

    //public GameManagerScript gameManager;
    
    public Vector3 targetObjectPos; // remettre public static si prob

    //public Vector3 posPlacePortrait1;
    //public Vector3 posPlacePortrait3;
    //public Vector3 posPlacePortrait5; 

    public GameObject doorGO;
    public Sprite doorSurbri;

    public Sprite fieldGlassComplete;

    public bool onDragDiplome = false;

    public MarieSurbriScript marieSurbriScript;

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

        if (CurrentItemIdName == ItemName.Diplome)
        {
            inventoryManager.changeDiplome.SurbriDiplome(true);
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
            targetObject = hit.transform.GetComponent<targetObjectToUseScript>();
            targetGameObject = hit.transform.gameObject;

            //CODE GLOBAL DE CORRESPONDANCE

            if (targetObject == null)
            {
                transform.SetParent(parentAfterDrag);
            } 
            else if (targetObject.targetName == CurrentItemIdName)
            {
                inventoryManager.InventoryUseCorrespondance(this);
            }
            else
            {
                targetObject = null;
                targetGameObject = null;
                transform.SetParent(parentAfterDrag);
            }

            // SCENE 2 - LES PORTRAITS à garder car rentre pas dans la condition globale
            //print(CurrentItemIdName);
            if (CurrentItemIdName == ItemName.Portrait1 && targetObject.targetName == ItemName.Portrait)
            {
                print("portrait 1 detecté");
                //inventoryManager.DeleteItem(this);
                portraitsInstanciate.InstanciatePortrait1();
                //targetObjectPos = posPlacePortrait1;
            }

            if (CurrentItemIdName == ItemName.Portrait3 && targetObject.targetName == ItemName.Portrait)
            {
                inventoryManager.DeleteItem(this);
                portraitsInstanciate.InstanciatePortrait3();
                //targetObjectPos = posPlacePortrait3;
            }

            if (CurrentItemIdName == ItemName.Portrait5 && targetObject.targetName == ItemName.Portrait)
            {
                inventoryManager.DeleteItem(this);
                portraitsInstanciate.InstanciatePortrait5();
                //targetObjectPos = posPlacePortrait5;
            }
        }
        if (CurrentItemIdName == ItemName.Diplome)
        {
            inventoryManager.changeDiplome.SurbriDiplome(false);
        }

        if (CurrentItemIdName == ItemName.Coquillage)
        {
            marieSurbriScript.SurbriMarie(false);
        }
    }

    public void InitialiseItem(Item newItem)
    {
        item = newItem;
        image.sprite = newItem.image;
    }
}

