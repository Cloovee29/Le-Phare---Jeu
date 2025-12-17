using UnityEngine;
using TMPro;

public class ShowDescriptionScript : MonoBehaviour
{
    public GameObject uiDescription;
    private GameObject newDescription;
    public TextMeshProUGUI textDescription;
    public string objectDescription;
    public float readingTime;
    public GameObject objectDescribed;
    public float positionAboveObject;
    public float positionSideObject;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            newDescription = Instantiate(uiDescription, uiDescription.transform.parent);
            textDescriptionPosition();
            Debug.Log("print" + objectDescribed.transform.position);
            textDescription = newDescription.GetComponentInChildren<TextMeshProUGUI>();
            textDescription.text = objectDescription;
            Invoke("endDescription", readingTime); //permet de mettre une durée de lecture à la description
        }
    }

    void endDescription()
    {
        if (newDescription != null)
        {
            Destroy(newDescription);
        }   
    }

    void Update()
    {

    }
    
    public void textDescriptionPosition()
    {
        Vector3 newUiDescriptionPosition = objectDescribed.transform.position + new Vector3(positionSideObject, positionAboveObject, 0);
        newDescription.transform.position = Camera.main.WorldToScreenPoint(newUiDescriptionPosition); //transpose vers l'UI
        Debug.Log("Function has been called");
    }
}