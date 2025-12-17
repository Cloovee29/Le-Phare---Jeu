using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PickObjectsScript : MonoBehaviour, IPointerClickHandler    
{
    public InventoryManagerScript InventoryManagerScript;
    public Item itemToPickup;
    public MouseAspectManagerScript mouseAspectManager;

    public void OnPointerClick(PointerEventData eventData)
    {
        PickupItem();
        Destroy(gameObject);
        Cursor.SetCursor(mouseAspectManager.defaultCursor, mouseAspectManager.hotSpot, mouseAspectManager.cursorMode);
    }

    public void PickupItem()
    {
        InventoryManagerScript.AddItem(itemToPickup);
    }

}
