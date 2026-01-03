using UnityEngine;

public class NotesEnigmaScript : MonoBehaviour
{
    public GameObject note1;
    public GameObject note2;
    public GameObject note3;
    public GameObject note4;
    public bool journalPageSolved;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(journalPageSolved == true)
        {
            note1.SetActive(true);
            note2.SetActive(true);
            note3.SetActive(true);
            note4.SetActive(true);
            print("notes activées");
        }
    }
}
