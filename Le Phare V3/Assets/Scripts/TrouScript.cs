using UnityEngine;
using UnityEngine.EventSystems;

public class TrouScript : MonoBehaviour
{

 public int slotID; // numéro du trou dans le texte

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void OnDrop(PointerEventData eventData)
    {
        var dragged = eventData.pointerDrag.GetComponent<MotScript>();

        if (dragged != null)
        {
            //JournalTexteScript.Instance.FillSlot(slotID, dragged.mot);
        }
    }
}
