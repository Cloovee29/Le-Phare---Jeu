using UnityEngine;
using UnityEngine.UI;

public class InventoryManagerScript : MonoBehaviour
{
    public static InventoryManagerScript instance;

    public InventorySlotScript[] inventorySlots;
    public GameObject inventoryItemPrefab;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        
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
        //    GameObject newItemGo = Instantiate(inventoryItemPrefab, slot.transform);
        //InventoryItemScript inventoryItem = newItemGo.GetComponentInChildren<InventoryItemScript>();
        //inventoryItem.InitialiseItem(item);
        inventoryItemScript.GetComponent<Image>().sprite = item.image;
        inventoryItemScript.CurrentItemIdName = item.idName;
    }

    private void Update()
    {
      
    }
}
