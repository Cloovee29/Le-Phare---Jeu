using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ThoughtsMarieScript : MonoBehaviour
{
    public GameObject uiMarieThought;
    private GameObject newMarieThought;
    public TextMeshProUGUI textMarieThought;
    //public string marieThought;
    public float readingTime;
    public GameObject marie;
    public float positionAboveMarie;
    public float startThoughts; // permet de régler le temps de lancement de la première pensée de Marie
    public float timeInBetweenThoughts; //temps entre les pensées
    public ClickMove2D clickMove2D;
    public GameObject inventoryMarie;

    //gérer les pensées de Marie : 
    public List<string> marieThoughts;
    private int currentThoughtIndex = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() //Attention à bien utiliser ce script dans le cas d'une pensée au début d'une scène, sinon il y aura une erreur. 
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

        if(currentThoughtIndex < marieThoughts.Count) // empêche le déplacement de Marie tant que les pensées ne sont pas finies pour éviter des bugs d'affichage ou d'animation de Marie
        {
            clickMove2D.enabled = false;
        }
        else
        {
            clickMove2D.enabled = true;
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
            currentThoughtIndex++;
        }

        if (currentThoughtIndex == 1 && marieThoughts.Count > 1 ) // lance la pensée suivante.
        {
            Invoke("launchMarieThought", timeInBetweenThoughts);
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
        }
    }
}