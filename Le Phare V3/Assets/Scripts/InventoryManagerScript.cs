using UnityEngine;

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
            if (itemInSlot != null)
            {
                print("case pleine");
                SpawnNewItem(item, slot);
                return;
            }
        }
    }

    void SpawnNewItem(Item item, InventorySlotScript slot)
    {
        GameObject newItemGo = Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItemScript inventoryItem = newItemGo.GetComponentInChildren<InventoryItemScript>();
        inventoryItem.InitialiseItem(item);
    }

    private void Update()
    {
      
    }
}
