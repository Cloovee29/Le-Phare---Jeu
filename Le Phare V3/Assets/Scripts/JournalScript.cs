using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class JournalScript : MonoBehaviour
{

public Vector3 ouvertureJournal;
public Vector3 fermetureJournal;
public bool journalOuvert;

public GameObject mot;
private List<GameObject> motADrag;
public List<string> listeMots;
public Transform originalParent;

public Sprite newSprite; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ouvertureJournal  = new Vector3(16f, -14f, 0f);
        fermetureJournal  = new Vector3(-16f, 14f, 0f);
        journalOuvert = false;
         motADrag = new List<GameObject>();
        for (int i = 0; i < listeMots.Count; i++)
        {
            GameObject nouveauMot = Instantiate(mot);
            nouveauMot.transform.SetParent(originalParent.parent, false); 
            motADrag.Add(nouveauMot);
            motADrag[i].GetComponent<MotScript>().CreerMot(listeMots[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
       
     if (Input.GetKeyDown(KeyCode.P)&& journalOuvert){
         GetComponent<SpriteRenderer>().sprite = newSprite;
            }


     if (Input.GetKeyDown(KeyCode.J) && journalOuvert==false){
           transform.position += ouvertureJournal;
           journalOuvert = true;
           motADrag[0].SetActive(true);
           motADrag[1].SetActive(true);
           motADrag[2].SetActive(true);

           


     }else if (Input.GetKeyDown(KeyCode.J) && journalOuvert==true){
         transform.position += fermetureJournal;
           journalOuvert = false;
           motADrag[0].SetActive(false);
           motADrag[1].SetActive(false);
           motADrag[2].SetActive(false);
     }
                

    }
}
