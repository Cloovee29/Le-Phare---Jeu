using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class JournalScript : MonoBehaviour
{

public Vector3 positionJournalOpened;
public Vector3 positionJournalClosed;
public bool journalOpened;

public GameObject word;
private List<GameObject> listWordsToDrag;
public List<GameObject> listHoles;
public List<string> listWords;
public Sprite newSprite; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        journalOpened = false;
        listWordsToDrag = new List<GameObject>();

        //crée une liste d'objets mots à partir de la liste de scripts dans unity
        for (int i = 0; i < listWords.Count; i++)
        {
            GameObject newWord = Instantiate(word);
            newWord.transform.SetParent(transform.parent, false);
            listWordsToDrag.Add(newWord);
            float newY = 400f - i*200f;
            listWordsToDrag[i].GetComponent<WordScript>().CreateWord(listWords[i], newY);
        }
    }

    // Update is called once per frame
    void Update()
    {

       //changement de page de journal WIP
     if (Input.GetKeyDown(KeyCode.P)&& journalOpened)
        {
         GetComponent<SpriteRenderer>().sprite = newSprite;
        }

     //Affiche le journal et les mots associés à l'écran
     if (Input.GetKeyDown(KeyCode.J) && journalOpened == false){
           transform.position += positionJournalOpened;
            journalOpened = true;

            listWordsToDrag[0].SetActive(true);
            listWordsToDrag[1].SetActive(true);
            listWordsToDrag[2].SetActive(true);


     }else if (Input.GetKeyDown(KeyCode.J) && journalOpened == true){
         transform.position += positionJournalClosed;
            journalOpened = false;

            listWordsToDrag[0].SetActive(false);
            listWordsToDrag[1].SetActive(false);
            listWordsToDrag[2].SetActive(false);
     }
                

    }
}
