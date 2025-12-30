using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.Audio;
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

    private BoxCollider2D[] decorsBoxCollider2D;
    public GameObject decors;

    //[Header("Audio")]    // ------SON QUI A CASSE LES MOTS ----
    //public AudioClip openSound;
    //public AudioClip closeSound;
    //public AudioClip pageTurn;
    //private AudioSource audioSource;

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
        {
        listPages[i].SetActive(i == currentPage);
        listPages[i].transform.Find("ValidationDrawing").gameObject.SetActive(false);
        }
         

        for (int i = 0; i < listPages[currentPage].transform.childCount; i++)
        {
            listPages[currentPage].transform.GetChild(i).gameObject.SetActive(journalOpened);
            listPages[currentPage].transform.Find("ValidationDrawing").gameObject.SetActive(false);
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

        // ancien code qui affiche juste le journal
        //if (!journalOpened)
        //    character.SetActive(false);

        //if (journalOpened)
        //    character.SetActive(true);

        //audioSource.PlayOneShot(openSound);    // ----SON QUI A CASSE LES MOTS

        // nouveau code qui affiche le journal et désactive le box collider des objets derrière
        decorsBoxCollider2D = decors.GetComponentsInChildren<BoxCollider2D>();
        if (!journalOpened)
        {
            character.SetActive(false);

            foreach (BoxCollider2D col in decorsBoxCollider2D)
                col.enabled = false;
        }

        if (journalOpened)
        {
            character.SetActive(true);
            foreach (BoxCollider2D col in decorsBoxCollider2D)
                col.enabled = true;
        }


        journalOpened = !journalOpened;
        journal.SetActive(journalOpened);
        bgJournal.SetActive(journalOpened);
       

        ChangePage();

        inventaire.SetActive(!journalOpened);
        arrows.SetActive(!journalOpened);
    }
}

