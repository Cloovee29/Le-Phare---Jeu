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
    GameObject targetGameObject;

    public InventoryManagerScript inventoryManager;
    public DoorLevel1Zoom doorLevel1Zoom;

    public Sprite newDiplome;

    public Sprite portrait1OnWall;
    public Sprite portrait3OnWall;
    public Sprite portrait4OnWall;
    public Sprite portrait5OnWall;

    public PortraitsInstanciateScript portraitsInstanciate;

    public fieldGlassInstanciateScript fieldGlassInstanciate;

    public GameManagerScript gameManager;
    
    public Vector3 targetObjectPos; // remettre public static si prob

    //public Vector3 posPlacePortrait1;
    //public Vector3 posPlacePortrait3;
    //public Vector3 posPlacePortrait5;

    //bool onDrag = false;

    // assignations surbrillance   

    public GameObject doorGO;
    public Sprite doorSurbri;

    public GameObject oldDiplome;
    public Sprite oldDiplomeSurbriSprite;
    public Sprite oldDiplomeSprite;

    public Sprite fieldGlassComplete;

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

        //if (CurrentItemIdName == ItemName.Key)
        //{
        //    trousseauKeys.GetComponent<SpriteRenderer>().sprite = doorSurbri;
        //}

        if (CurrentItemIdName == ItemName.Diplome)
        {
            oldDiplome.GetComponent<SpriteRenderer>().sprite = oldDiplomeSurbriSprite;
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

            //if (targetObject.targetName != CurrentItemIdName)
            //{
            //    transform.SetParent(parentAfterDrag);
            //}

            if (targetObject.targetName == CurrentItemIdName && targetObject.targetName == ItemName.Diplome)
            {
                ChangeDiplome();
            }

            if (CurrentItemIdName == ItemName.Diplome) {
                oldDiplome.GetComponent<SpriteRenderer>().sprite = oldDiplomeSprite;
            }

            if (targetObject.targetName == CurrentItemIdName && targetObject.targetName == ItemName.Key)
            {
                doorLevel1Zoom.OpenDoor();
                print("clemarche");
            }

            // SCENE 2 - LES PORTRAITS

            //if (targetObject.CompareTag("Portrait1"))
            //{
            //    posPlacePortrait1 = targetObject.transform.position;
            //}

            //if (targetObject.CompareTag("Portrait3"))
            //{
            //    posPlacePortrait3 = targetObject.transform.position;
            //}

            //if (targetObject.CompareTag("Portrait5"))
            //{
            //    posPlacePortrait5 = targetObject.transform.position;
            //}

            if (CurrentItemIdName == ItemName.Portrait1 && targetObject.targetName == ItemName.Portrait)
            {
                inventoryManager.DeleteItem(this);
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
        else
        {
            Debug.DrawRay(mouseWorldPosition, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
        }

        // SCENE 3
        
        if (targetObject.targetName == CurrentItemIdName && targetObject.targetName == ItemName.Coquillage)
        {
            AudioSource audioSourceMusic = targetObject.GetComponent<ClickMove2D>().characterFeedback;

            audioSourceMusic.clip = item.audioClip;
            audioSourceMusic.Play();
            print("coquillage utilisé");
        }
        if (targetObject.targetName == CurrentItemIdName && targetObject.targetName == ItemName.PieceLongueVue)
        {
            print("longue-vue complétée");
            fieldGlassInstanciate.InstantiateCompleteFieldglass();
            inventoryManager.DeleteItem(this);
            Object.Destroy(targetObject);
        }

        if (targetObject.targetName == CurrentItemIdName && targetObject.targetName == ItemName.LongueVue)
        {
            print("vue dehors");
            gameManager.windowView();
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

