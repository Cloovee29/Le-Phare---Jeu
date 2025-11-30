using Unity.VisualScripting;
using UnityEngine;

public class PortraitsInstanciateScript : MonoBehaviour
{

    public GameObject portrait1Drag;
    public GameObject portrait3Drag;
    public GameObject portrait5Drag;
    public GameObject portraitParent;

    //public InventoryItemScript inventoryItemScript;

    Vector3 worldPos;
    Vector3 mousePos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //worldPos.z = -5f;

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10f;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        worldPos.z = -5f;

        //inventoryItemScript = GetComponent<InventoryItemScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void InstanciatePortrait1()
    {
        GameObject newPortrait = Instantiate(portrait1Drag);
        newPortrait.SetActive(true);      
        newPortrait.transform.SetParent(portraitParent.transform, true);
        newPortrait.transform.position = InventoryItemScript.targetObject.transform.position;
    }

    public void InstanciatePortrait3()
    {
        GameObject newPortrait = Instantiate(portrait3Drag);
        newPortrait.SetActive(true);
        newPortrait.transform.SetParent(portraitParent.transform, true);
        newPortrait.transform.position = InventoryItemScript.targetObject.transform.position;
    }

    public void InstanciatePortrait5()
    {
        GameObject newPortrait = Instantiate(portrait5Drag);
        newPortrait.SetActive(true);
        newPortrait.transform.SetParent(portraitParent.transform, true);
        newPortrait.transform.position = InventoryItemScript.targetObject.transform.position;
    }
}
