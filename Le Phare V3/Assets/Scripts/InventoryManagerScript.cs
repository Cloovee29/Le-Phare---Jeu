using DG.Tweening.Core.Easing;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEditor.Progress;
using static UnityEngine.InputSystem.UI.VirtualMouseInput;

public class InventoryManagerScript : MonoBehaviour
{
    public static InventoryManagerScript instance;

    public InventorySlotScript[] inventorySlots;
    public GameObject inventoryItemPrefab;

    public Item diplomeMarie;

    public ItemName? CurrentItemIdName { get; set; }

    [HideInInspector] public ChangeDiplomeScript changeDiplome;
    public DoorLevel1Zoom doorLevel1Zoom;
    public FieldGlassInstanciateScript fieldGlassInstanciate;
    public GameManagerScript gameManager;
    public OpenWindowScript openWindow;
    public WindowView WindowView;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        if(SceneManager.GetActiveScene().name == "01 - HouseScene")
        {
            AddItem(diplomeMarie);
        }
    }

    public void AddItem(Item item)
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlotScript slot = inventorySlots[i];
            InventoryItemScript itemInSlot = slot.GetComponentInChildren<InventoryItemScript>();
            if (itemInSlot.CurrentItemIdName == null)
            {
                SpawnNewItem(item, itemInSlot);
                return;
            }
        }
    }

    void SpawnNewItem(Item item, InventoryItemScript inventoryItemScript)
    {
        inventoryItemScript.CurrentItemIdName = item.idName;
        inventoryItemScript.InitialiseItem(item);
    }

    public void DeleteItem (InventoryItemScript inventoryItemScript)
    {
        inventoryItemScript.GetComponent<Image>().sprite = null;
        inventoryItemScript.CurrentItemIdName = null;
    }

    public void InventoryUseCorrespondance(InventoryItemScript usedItem)
    {
        if (usedItem.targetObject.targetName == ItemName.Diplome)
        {
            DeleteItem(usedItem);
            changeDiplome.ChangeDiplome();
        }

        if (usedItem.targetObject.targetName == ItemName.Key)
        {
            doorLevel1Zoom.OpenDoor();
        }

        if (usedItem.targetObject.targetName == ItemName.Coquillage)
        {
            AudioSource audioSourceMusic = usedItem.targetObject.GetComponent<ClickMove2D>().characterFeedback;
            audioSourceMusic.clip = usedItem.item.audioClip;
            audioSourceMusic.Play();
        }

        if (usedItem.targetObject.targetName == ItemName.PieceLongueVue)
        {
            fieldGlassInstanciate.InstantiateCompleteFieldglass();
            DeleteItem(usedItem);
        }
        if (usedItem.targetObject.targetName == ItemName.LongueVue)
        {
            WindowView.windowView();
        }

    }
}

