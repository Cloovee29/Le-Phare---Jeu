using UnityEngine;

public class NotesScript : MonoBehaviour
{
    //AudioSource audioSource;
    bool note1 = false;
    bool note2 = false;
    bool note3 = false;
    bool note4 = false;

    string[] notesOrder = { "Note1", "Note2", "Note3", "Note4" };
    int compteurAppuis = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (note1 == true && note2 == true && note3 == true && note4 == true)
        {
            MusicSolve();
        }
    }

    private void OnMouseDown()
    {

    }
    public void NoteClicked(string tagNote)
    {
        if (tagNote == notesOrder[compteurAppuis])
        {
            Debug.Log("Correct : " + tagNote);
            compteurAppuis++;

            if (compteurAppuis == notesOrder.Length)
            {
                Debug.Log("Séquence terminée !");
                compteurAppuis = 0;
            }
        }
        else
        {
            Debug.Log("Mauvaise note, reset !");
            compteurAppuis = 0;
        }
    }


void MusicSolve()
    {
       print("enigme musique réussie");
    }
}
