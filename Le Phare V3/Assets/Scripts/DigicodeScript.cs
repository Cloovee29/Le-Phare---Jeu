using UnityEngine;
using UnityEngine.EventSystems;

public class DigicodeScript : MonoBehaviour
{
    public GameObject zoomDigicode;
    public GameObject character;
    public GameObject arrows;

  
    public void ButtonPressed(string tagNote)
    {
        if (tagNote == "oui")
        {
            print("enigme boite réussie");
            
        }
        else
        {
            Debug.Log("Mauvaise touche");
        }


    }

    public void OnMouseDown()
    {
        zoomDigicode.SetActive(true);
        character.SetActive(false);
        arrows.SetActive(false);
    }
  
}
