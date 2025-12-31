using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PickObjectsScript : MonoBehaviour, IPointerClickHandler    
{
    public InventoryManagerScript InventoryManagerScript;
    public Item itemToPickup;
    public MouseAspectManagerScript mouseAspectManagerScript;

    [Header("Audio")]
    public AudioClip pickSound;

    private PickupAudioScript audioParent;

    void Awake()
    {
        audioParent = GetComponentInParent<PickupAudioScript>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        PickupItem();

        if (audioParent != null)
            audioParent.PlayPickupSound(pickSound);

        Destroy(gameObject);
        Cursor.SetCursor(mouseAspectManagerScript.defaultCursor, mouseAspectManagerScript.hotSpot, mouseAspectManagerScript.cursorMode);
    }

    public void PickupItem()
    {
        InventoryManagerScript.AddItem(itemToPickup);
    }

}
