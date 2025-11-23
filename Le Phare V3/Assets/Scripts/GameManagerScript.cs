using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public JournalScript journalScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //journalScript = GetComponent<JournalScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            journalScript.ActiveJournal();

        }
    }
}
