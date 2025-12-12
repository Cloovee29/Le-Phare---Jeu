using UnityEngine;

public class ClickEndGame : MonoBehaviour
{

   public OpenWindowScript openWindowScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
        }
        
    }
}
