using DG.Tweening;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.InputSystem.UI.VirtualMouseInput;

public class InventoryItemScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    [Header("UI")]

    [HideInInspector] public Image image;
    [HideInInspector] public Item item;

    Transform parentAfterDrag;

    public ItemName? CurrentItemIdName { get; set; }

    Vector3 mouseWorldPosition;

    [SerializeField] private Camera mainCamera;
    [SerializeField] private Canvas canvas;

    public targetObjectToUseScript targetObject;
    public GameObject targetGameObject;

    public InventoryManagerScript inventoryManager;

    public PortraitsInstanciateScript portraitsInstanciate;
    
    public Vector3 targetObjectPos;

    public Sprite fieldGlassComplete;

    public MarieSurbriScript marieSurbriScript;
    public OpenWindowScript openWindowScript;
    public FieldGlassInstanciateScript fieldGlassInstanciate;
    public DoorLevel1Zoom doorLevel1Zoom;

    float duration = 0.5f;
    RectTransform rectTransform;
    Vector3 initialScale;

    public MouseAspectScript mouseAspectScript;
    void Start()
    {
        image = GetComponent<Image>();
    }

    void Awake()
    {        
        image = GetComponent<Image>();
        rectTransform = GetComponent<RectTransform>();
        initialScale = rectTransform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (CurrentItemIdName != null)
        {
            print("mouse enter");
            rectTransform.DOScale(initialScale * 1.3f, duration).SetEase(Ease.OutCubic);
        }

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        rectTransform.DOScale(initialScale, duration).SetEase(Ease.OutCubic);
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

        if (CurrentItemIdName == ItemName.Coquillage)
        {
            marieSurbriScript.SurbriMarie(true);
        }

        if (CurrentItemIdName == ItemName.PieceLongueVue)
        {
            openWindowScript.PieceFieldGlassSurbri(true);
        }

        if (CurrentItemIdName == ItemName.LongueVue)
        {
            fieldGlassInstanciate.FieldGlassSurbri(true);
        }

        if (CurrentItemIdName == ItemName.Key)
        {
            doorLevel1Zoom.DoorSurbri(true);
        }
        Cursor.SetCursor(mouseAspectScript.grabCursor, mouseAspectScript.hotSpot, mouseAspectScript.cursorMode);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Cursor.SetCursor(mouseAspectScript.defaultCursor, mouseAspectScript.hotSpot, mouseAspectScript.cursorMode);

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
            else if (CurrentItemIdName == ItemName.Portrait1 && targetObject.targetName == ItemName.Portrait)
            {
                Vector3 pos = targetObject.transform.position;
                inventoryManager.DeleteItem(this);
                portraitsInstanciate.InstanciatePortrait1(pos);
            }
            else if (CurrentItemIdName == ItemName.Portrait4 && targetObject.targetName == ItemName.Portrait)
            {
                Vector3 pos = targetObject.transform.position;
                inventoryManager.DeleteItem(this);
                portraitsInstanciate.InstanciatePortrait4(pos);
            }
            else if (CurrentItemIdName == ItemName.Portrait5 && targetObject.targetName == ItemName.Portrait)
            {
                Vector3 pos = targetObject.transform.position;
                inventoryManager.DeleteItem(this);
                portraitsInstanciate.InstanciatePortrait5(pos);
            }
            else
            {
                targetObject = null;
                targetGameObject = null;
                transform.SetParent(parentAfterDrag);
            }
        }

        // ACTIVATION SURBRILLANCE

        if (CurrentItemIdName == ItemName.Diplome)
        {
            inventoryManager.changeDiplome.SurbriDiplome(false);
        }

        if (CurrentItemIdName == ItemName.Coquillage)
        {
            marieSurbriScript.SurbriMarie(false);
        }

        if (CurrentItemIdName == ItemName.PieceLongueVue)
        {
            openWindowScript.PieceFieldGlassSurbri(false);
        }

        if (CurrentItemIdName == ItemName.LongueVue)
        {
            fieldGlassInstanciate.FieldGlassSurbri(false);
        }

        if (CurrentItemIdName == ItemName.Key)
        {
            doorLevel1Zoom.DoorSurbri(false);
        }
    }

    public void InitialiseItem(Item newItem)
    {
        item = newItem;
        image.sprite = newItem.image;
    }
}

