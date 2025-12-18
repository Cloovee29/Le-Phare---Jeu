using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PickObjectsScript : MonoBehaviour, IPointerClickHandler    
{
    public InventoryManagerScript InventoryManagerScript;
    public Item itemToPickup;
    public MouseAspectManagerScript mouseAspectManagerScript;

    public void OnPointerClick(PointerEventData eventData)
    {
        PickupItem();
        Destroy(gameObject);
        Cursor.SetCursor(mouseAspectManagerScript.defaultCursor, mouseAspectManagerScript.hotSpot, mouseAspectManagerScript.cursorMode);
    }

    public void PickupItem()
    {
        InventoryManagerScript.AddItem(itemToPickup);
    }

}
