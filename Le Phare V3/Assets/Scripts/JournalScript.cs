using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using Microsoft.Unity.VisualStudio.Editor;

public class JournalScript : MonoBehaviour
{

    //public Vector3 positionJournalOpened;
    //public Vector3 positionJournalClosed;
    public bool journalOpened;

    public GameObject word;
    private List<GameObject> listWordsToDrag;
    public List<GameObject> listHoles;
    public List<string> listWords;
    public Sprite newSprite;

    public GameObject journal;
    public GameObject bgJournal;

    public GameObject inventaire;
    public GameObject arrows;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        journalOpened = false;
        listWordsToDrag = new List<GameObject>();

        //crée une liste d'objets mots à partir de la liste de scripts dans unity
        for (int i = 0; i < listWords.Count; i++)
        {
            GameObject newWord = Instantiate(word);
            newWord.transform.SetParent(journal.transform, false);
            listWordsToDrag.Add(newWord);
            float newY = 400f - i * 200f;
            listWordsToDrag[i].GetComponent<WordScript>().CreateWord(listWords[i], newY);
        }

    }

    // Update is called once per frame
    void Update()
    {
      
        //changement de page de journal WIP
        if (Input.GetKeyDown(KeyCode.P) && journalOpened)
        {
            print("oui");
            GetComponent<SpriteRenderer>().sprite = newSprite;
        }
    }


    public void ActiveJournal()
    {
        //Affiche le journal et les mots associés à l'écran

        journalOpened = !journalOpened;
        journal.SetActive(journalOpened);
        bgJournal.SetActive(journalOpened);
        transform.GetChild(0).gameObject.SetActive(journalOpened);

        inventaire.SetActive(!journalOpened);
        arrows.SetActive(!journalOpened);
    }
}

