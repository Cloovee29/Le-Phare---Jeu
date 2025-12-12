using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PickObjectsScript : MonoBehaviour, IPointerClickHandler    
{
    public InventoryManagerScript InventoryManagerScript;
    public Item itemToPickup;

    public void OnPointerClick(PointerEventData eventData)
    {
        PickupItem();
        Destroy(gameObject);
    }

    public void PickupItem()
    {
        InventoryManagerScript.AddItem(itemToPickup);
    }

}
