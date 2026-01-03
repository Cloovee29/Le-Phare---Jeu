using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public JournalScript journalScript;
    public GameObject windowViewGO;

    public GameObject buttonEndGame;
    public GameObject journal;

    public void windowView()
    {
        print("fenetreouverteVue");
        windowViewGO.SetActive(true);
        buttonEndGame.SetActive(true);
        journal.SetActive(false);
    }


}
