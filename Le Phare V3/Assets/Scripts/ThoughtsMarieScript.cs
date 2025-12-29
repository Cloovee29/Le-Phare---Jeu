using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ThoughtsMarieScript : MonoBehaviour
{
    public GameObject uiMarieThought;
    private GameObject newMarieThought;
    public TextMeshProUGUI textMarieThought;
    //public string marieThought;
    public float readingTime;
    public GameObject marie;
    public float positionAboveMarie;
    public float startThoughts; // permet de régler le temps de lancement des pensées de marie
    public ClickMove2D clickMove2D;
    public GameObject inventoryMarie;

    //gérer les pensées de Marie : 
    public List<string> marieThoughts;
    private int currentThoughtIndex = 0;
    private bool marieThinking;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("launchMarieThought", startThoughts); // lance la première pensée
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && newMarieThought != false)
           {
            Invoke("endThought", 0);
           }
    }

    public void thoughtMariePosition()
    {
        Vector3 newUiThoughtMariePosition = marie.transform.position + new Vector3(0, positionAboveMarie, 0);
        newMarieThought.transform.position = Camera.main.WorldToScreenPoint(newUiThoughtMariePosition); //transpose vers l'UI
    }

    void endThought()
    {
        if (newMarieThought != null)
        {
            Destroy(newMarieThought);
            clickMove2D.enabled = true;
            currentThoughtIndex++;
            //marieThinking = false;
        }

        if (currentThoughtIndex == 1) //&& marieThinking == false) // lance la pensée suivante.
        {
            Invoke("launchMarieThought", 1);
        }
    }

    void launchMarieThought()
    {
        if(currentThoughtIndex <= marieThoughts.Count)
        {
            newMarieThought = Instantiate(uiMarieThought, uiMarieThought.transform.parent);
            thoughtMariePosition();
            textMarieThought = newMarieThought.GetComponentInChildren<TextMeshProUGUI>();
            textMarieThought.text = marieThoughts[currentThoughtIndex];

            Invoke("endThought", readingTime);
            clickMove2D.enabled = false;
        }
    }
}