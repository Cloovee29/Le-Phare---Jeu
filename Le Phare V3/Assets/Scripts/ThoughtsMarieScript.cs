using TMPro;
using UnityEngine;

public class ThoughtsMarieScript : MonoBehaviour
{
    public GameObject uiMarieThought;
    private GameObject newMarieThought;
    public TextMeshProUGUI textMarieThought;
    public string marieThought;
    public float readingTime;
    public GameObject marie;
    public float positionAboveMarie;
    public float startThoughts; // permet de régler le temps de lancement des pensées de marie
    public ClickMove2D clickMove2D;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("launchMarieThought", startThoughts);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void thoughtMariePosition()
    {
        Vector3 newUiThoughtMariePosition = marie.transform.position + new Vector3(0, positionAboveMarie, 0);
        newMarieThought.transform.position = Camera.main.WorldToScreenPoint(newUiThoughtMariePosition); //transpose vers l'UI
        //Debug.Log("Function has been called");
    }

    void endThought()
    {
        if (newMarieThought != null)
        {
            Destroy(newMarieThought);
            clickMove2D.enabled = true;
        }
    }

    void launchMarieThought()
    {
        newMarieThought = Instantiate(uiMarieThought, uiMarieThought.transform.parent);
        thoughtMariePosition();
        //Debug.Log("print" + objectDescribed.transform.position);
        textMarieThought = newMarieThought.GetComponentInChildren<TextMeshProUGUI>();
        textMarieThought.text = marieThought;
        Invoke("endThought", readingTime);
        clickMove2D.enabled = false;
    }
}