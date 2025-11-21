using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class JournalScript : MonoBehaviour
{

public Vector3 ouvertureJournal;
public Vector3 fermetureJournal;
public bool journalOuvert;

public GameObject mot;
private List<GameObject> listeMotADrag;
public List<GameObject> listeTrous;
public List<string> listeMots;

public Transform originalParent;
public Sprite newSprite; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ouvertureJournal  = new Vector3(16f, -14f, 0f);
        fermetureJournal  = new Vector3(-16f, 14f, 0f);
        journalOuvert = false;
        listeMotADrag = new List<GameObject>();

        for (int i = 0; i < listeMots.Count; i++)
        {
            GameObject nouveauMot = Instantiate(mot);
            nouveauMot.transform.SetParent(originalParent.parent, false); 
            listeMotADrag.Add(nouveauMot);
            float nouveauY = 400f - i*200f;
            listeMotADrag[i].GetComponent<MotScript>().CreerMot(listeMots[i], nouveauY);
        }
    }

    // Update is called once per frame
    void Update()
    {

    //vérifier si un mot est dans un trou


       
     if (Input.GetKeyDown(KeyCode.P)&& journalOuvert){
         GetComponent<SpriteRenderer>().sprite = newSprite;
            }


     if (Input.GetKeyDown(KeyCode.J) && journalOuvert==false){
           transform.position += ouvertureJournal;
           journalOuvert = true;
           listeMotADrag[0].SetActive(true);
           listeMotADrag[1].SetActive(true);
           listeMotADrag[2].SetActive(true);

           


     }else if (Input.GetKeyDown(KeyCode.J) && journalOuvert==true){
         transform.position += fermetureJournal;
           journalOuvert = false;
           listeMotADrag[0].SetActive(false);
           listeMotADrag[1].SetActive(false);
           listeMotADrag[2].SetActive(false);
     }
                

    }
}
