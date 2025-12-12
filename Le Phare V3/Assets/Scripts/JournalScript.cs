using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.EventSystems;

public class JournalScript : MonoBehaviour
{
    public bool journalOpened;

    public GameObject character;

    public GameObject journal;
    public GameObject page;

    private List<GameObject> listPages; //liste des pages du carnet
    public GameObject bgJournal; //background du journal

    public GameObject inventaire;
    public GameObject arrows;

    public List<PageSOScript> pagesContent;
    public int currentPage;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {

        listPages = new List<GameObject>();
        currentPage = 0;

        //création des pages du carnet
        for (int i = 0; i < pagesContent.Count; i++)
        {
            GameObject newPage = Instantiate(page);
            newPage.transform.SetParent(journal.transform, false);
            newPage.transform.SetAsFirstSibling();
            listPages.Add(newPage);
            listPages[i].GetComponent<PageScript>().CreatePage(i, pagesContent[i]);
        }
        page.transform.SetAsFirstSibling();

    }

    // Update is called once per frame
    void Update()
    {
      
        //changement de page de journal WIP
        if (Input.GetKeyDown(KeyCode.RightArrow) && journalOpened && currentPage+1< pagesContent.Count)
        {
            currentPage = currentPage + 1;
            ChangePage();

            //permet de changer de page du carnet
            //afficher la nouvelle page du carnet et cacher la précédente
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && journalOpened && currentPage - 1 > -1)
        {
            currentPage = currentPage - 1;
            ChangePage();

            //permet de changer de page du carnet
            //afficher la nouvelle page du carnet et cacher la précédente
        }
    } 

    public void ChangePage()
    {

        for (int i = 0; i < listPages.Count; i++)
            listPages[i].SetActive(i == currentPage);

        for (int i = 0; i < listPages[currentPage].transform.childCount; i++)
        {
            listPages[currentPage].transform.GetChild(i).gameObject.SetActive(journalOpened);
        }
    }

    public void ChangePageNext()
    {
        if(currentPage + 1 < pagesContent.Count)
        {
            currentPage = currentPage + 1;
            ChangePage();
        }
       
        //permet de changer de page du carnet
        //afficher la nouvelle page du carnet et cacher la précédente

    }

    public void ChangePagePrevious()
    {
        if (currentPage - 1 > -1)
        {
            currentPage = currentPage - 1;
            ChangePage();
        }

    }

    public void ActiveJournal()
    {
        //Affiche le journal et les mots associés à l'écran
        

        if (!journalOpened)
            character.SetActive(false);

        if (journalOpened)
            character.SetActive(true);


        journalOpened = !journalOpened;
        journal.SetActive(journalOpened);
        bgJournal.SetActive(journalOpened);
        page.transform.GetChild(0).gameObject.SetActive(journalOpened);
        transform.GetChild(0).gameObject.SetActive(journalOpened);

        ChangePage();

        inventaire.SetActive(!journalOpened);
        arrows.SetActive(!journalOpened);
    }
}

