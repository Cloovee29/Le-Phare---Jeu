using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PortraitsInstanciateScript : MonoBehaviour
{
    public GameObject portrait1Drag;
    public GameObject portrait4Drag;
    public GameObject portrait5Drag;
    public GameObject portraitParent;

    public InventoryItemScript inventoryItemScript;
    Vector3 worldPos;
    Vector3 mousePos;

    void Start()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10f;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        worldPos.z = -5f;
    }

    public void InstanciatePortrait1(Vector3 position)
    {
        GameObject newPortrait = Instantiate(portrait1Drag);
        newPortrait.SetActive(true);
        newPortrait.transform.SetParent(portraitParent.transform, true);
        //newPortrait.transform.position = inventoryItemScript.targetObjectPos;
        newPortrait.transform.position = position;
    }

    public void InstanciatePortrait4(Vector3 position)
    {
        GameObject newPortrait = Instantiate(portrait4Drag);
        newPortrait.SetActive(true);
        newPortrait.transform.SetParent(portraitParent.transform, true);
        newPortrait.transform.position = position;
    }

    public void InstanciatePortrait5(Vector3 position)
    {
        GameObject newPortrait = Instantiate(portrait5Drag);
        newPortrait.SetActive(true);
        newPortrait.transform.SetParent(portraitParent.transform, true);
        newPortrait.transform.position = position;
    }
}
