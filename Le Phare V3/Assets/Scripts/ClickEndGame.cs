using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickEndGame : MonoBehaviour
{

   public OpenWindowScript openWindowScript;
    public GameObject endGameDoor;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        endGameDoor.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        if (openWindowScript.openWindow == true)
        {
            print("fin du jeu");
            endGameDoor.SetActive(true);
            //SceneManager.LoadScene("04 - End Cinematic");
        }
        
    }
}
