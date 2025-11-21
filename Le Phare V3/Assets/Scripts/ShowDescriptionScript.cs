using UnityEngine;
using TMPro;

public class ShowDescriptionScript : MonoBehaviour
{
    public GameObject uiDescription;
    public TextMeshProUGUI textDescription;
    public string objectDescription;
    public float readingTime;
    public GameObject objectDescribed;
    public float positionAboveObject;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //GameObject newDescription = Instantiate(uiDescription);
        uiDescription.SetActive(false); //désactive la description lorsqu'elle n'est pas active
    }

    // Update is called once per frame
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            //Instantiate(uiDescription);
            uiDescription.SetActive(true);
            textDescriptionPosition();
            Debug.Log("print" + objectDescribed.transform.position);
            textDescription.text = objectDescription;
            Invoke("endDescription", readingTime); //permet de mettre une durée de lecture à la description
        }
    }

    void endDescription()
    {
        uiDescription.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            uiDescription.SetActive(false);
        }
    }
    
    public void textDescriptionPosition()
    {
        Vector3 newUiDescriptionPosition = objectDescribed.transform.position + new Vector3(0, positionAboveObject, 0);
        uiDescription.transform.position = Camera.main.WorldToScreenPoint(newUiDescriptionPosition);
        Debug.Log("Function has been called");
    }
}