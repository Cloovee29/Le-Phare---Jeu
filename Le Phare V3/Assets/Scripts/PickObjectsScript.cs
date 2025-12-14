using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PickObjectsScript : MonoBehaviour, IPointerClickHandler    
{
    public InventoryManagerScript InventoryManagerScript;
    public Item itemToPickup;
    public MouseAspectScript mouseAspect;

    public void OnPointerClick(PointerEventData eventData)
    {
        PickupItem();
        Destroy(gameObject);
        Cursor.SetCursor(mouseAspect.defaultCursor, mouseAspect.hotSpot, mouseAspect.cursorMode);
    }

    public void PickupItem()
    {
        InventoryManagerScript.AddItem(itemToPickup);
    }

}
