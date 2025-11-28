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

    public GameObject journal;

    public List<GameObject> listPages; //liste des pages du carnet
    public GameObject bgJournal; //background du journal

    public GameObject inventaire;
    public GameObject arrows;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
      
        //changement de page de journal WIP
        if (Input.GetKeyDown(KeyCode.P) && journalOpened)
        {
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

