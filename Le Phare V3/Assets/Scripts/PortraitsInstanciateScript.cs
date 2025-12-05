using Unity.VisualScripting;
using UnityEngine;

public class PortraitsInstanciateScript : MonoBehaviour
{

    public GameObject portrait1Drag;
    public GameObject portrait3Drag;
    public GameObject portrait5Drag;
    public GameObject portraitParent;

    InventoryItemScript inventoryItemScript; // pas là avant car variable static depuis le script
    Vector3 worldPos;
    Vector3 mousePos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10f;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        worldPos.z = -5f;
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
        //newPortrait.transform.position = inventoryItemScript.targetObjectPos; // avant : InventoryItemScript en static pour récup target object depuis inventoryitemscript donc pas d'assigantion avant et appel direct du script ici
        newPortrait.transform.position = worldPos;
    }

    public void InstanciatePortrait3()
    {
        GameObject newPortrait = Instantiate(portrait3Drag);
        newPortrait.SetActive(true);
        newPortrait.transform.SetParent(portraitParent.transform, true);
        //newPortrait.transform.position = targetObject.transform.position;
        //newPortrait.transform.position = inventoryItemScript.posPlacePortrait3;
        newPortrait.transform.position = worldPos;
    }

    public void InstanciatePortrait5()
    {
        GameObject newPortrait = Instantiate(portrait5Drag);
        newPortrait.SetActive(true);
        newPortrait.transform.SetParent(portraitParent.transform, true);
        //newPortrait.transform.position = inventoryItemScript.posPlacePortrait5;
        newPortrait.transform.position = worldPos;
    }
}
