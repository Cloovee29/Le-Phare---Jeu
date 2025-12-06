using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class InventoryManagerScript : MonoBehaviour
{
    public static InventoryManagerScript instance;

    public InventorySlotScript[] inventorySlots;
    public GameObject inventoryItemPrefab;

    public Item diplomeMarie;

    
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
                print("case pleine");
                SpawnNewItem(item, itemInSlot);
                return;
            }
        }
    }

    void SpawnNewItem(Item item, InventoryItemScript inventoryItemScript)
    {
        //inventoryItemScript.GetComponent<Image>().sprite = item.image;
        inventoryItemScript.CurrentItemIdName = item.idName;
        inventoryItemScript.InitialiseItem(item);
    }

    public void DeleteItem (InventoryItemScript inventoryItemScript)
    {
        inventoryItemScript.GetComponent<Image>().sprite = null;
        inventoryItemScript.CurrentItemIdName = null;
    }
}
