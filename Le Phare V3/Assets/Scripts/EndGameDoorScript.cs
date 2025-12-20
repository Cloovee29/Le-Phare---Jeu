using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameDoorScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        print("fin du jeu vers fin");
        SceneManager.LoadScene("04 - EndCinematic");
    }
}
