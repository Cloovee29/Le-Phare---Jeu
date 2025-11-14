using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PickObjectsScript : MonoBehaviour, IPointerClickHandler    
{
    public InventoryManagerScript InventoryManagerScript;
    public Item itemToPickup;

    //public Item[] itemsToPickup;

    //public void OnPointerClick(PointerEventData eventData)
    //{
    //    PickupItem(0);
    //}

    //public void PickupItem(int id)
    //{
    //    InventoryManagerScript.AddItem(itemsToPickup[id]);
    //}

    public void OnPointerClick(PointerEventData eventData)
    {
        PickupItem();
    }

    public void PickupItem()
    {
        InventoryManagerScript.AddItem(itemToPickup);
    }

}
