using UnityEngine;

public class JournalScript : MonoBehaviour
{

public Vector3 ouvertureJournal;
public Vector3 fermetureJournal;
public bool journalOuvert;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ouvertureJournal  = new Vector3(16f, -14f, 0f);
        fermetureJournal  = new Vector3(-16f, 14f, 0f);
        journalOuvert = false;
    }

    // Update is called once per frame
    void Update()
    {
        
     if (Input.GetKeyDown(KeyCode.J) && journalOuvert==false){
           transform.position += ouvertureJournal;
           journalOuvert = true;
     }else if (Input.GetKeyDown(KeyCode.J) && journalOuvert==true){
         transform.position += fermetureJournal;
           journalOuvert = false;
     }
                

    }
}
