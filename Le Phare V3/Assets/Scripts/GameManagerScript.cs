using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public JournalScript journalScript;
    public GameObject windowViewGO;

    public GameObject buttonEndGame;
    public GameObject journal;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            journalScript.ActiveJournal();
        }
    }

    public void windowView()
    {
        print("fenetreouverteVue");
        windowViewGO.SetActive(true);
        buttonEndGame.SetActive(true);
        journal.SetActive(false);
    }


}
