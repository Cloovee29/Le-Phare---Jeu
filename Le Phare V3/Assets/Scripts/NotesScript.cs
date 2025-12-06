using UnityEngine;

public class NotesScript : MonoBehaviour
{
    string[] notesOrder = { "Note1", "Note2", "Note3", "Note4" };
    int compteurAppuis = 0;

    OpenWindowScript openWindowScript;
    GameObject window;

    void Start()
    {
        window = GameObject.Find("window");
        openWindowScript = window.GetComponent<OpenWindowScript>();
    }

    //void Update()
    //{

    //}

    //private void OnMouseDown()
    //{

    //}
    public void NoteClicked(string tagNote)
    {
        if (tagNote == notesOrder[compteurAppuis])
        {
            Debug.Log("Correct : " + tagNote);
            compteurAppuis++;

            if (compteurAppuis == notesOrder.Length)
            {
                compteurAppuis = 0;
                print("enigme musique réussie");
                openWindowScript.OpenWindow();
            }
        }
        else
        {
            Debug.Log("Mauvaise note");
            compteurAppuis = 0;
        }
    }

}
