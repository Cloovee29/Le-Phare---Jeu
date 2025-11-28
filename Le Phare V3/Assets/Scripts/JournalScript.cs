using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using Microsoft.Unity.VisualStudio.Editor;

public class JournalScript : MonoBehaviour
{
    public bool journalOpened;

    public GameObject journal;
    public GameObject page;

    private List<GameObject> listPages; //liste des pages du carnet
    public GameObject bgJournal; //background du journal

    public GameObject inventaire;
    public GameObject arrows;

    public List<PageSOScript> pagesContent;
    public int currentPage;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        listPages = new List<GameObject>();
      
        //création des pages du carnet
        for (int i = 0; i < pagesContent.Count; i++)
        {
            GameObject newPage = Instantiate(page);
            newPage.transform.SetParent(journal.transform, false);
            listPages.Add(newPage);

            List<string> listWordsTemp = new List<string>();
            
            foreach (string word in pagesContent[i].listWords)
            {
                listWordsTemp.Add(word);
            }

           listPages[i].GetComponent<PageScript>().CreatePage(i, listWordsTemp);
        }

    }

    // Update is called once per frame
    void Update()
    {
      
        //changement de page de journal WIP
        if (Input.GetKeyDown(KeyCode.P) && journalOpened)
        {
            listPages[0].SetActive(false);
    //permet de changer de page du carnet
    //afficher la nouvelle page du carnet et cacher la précédente
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

