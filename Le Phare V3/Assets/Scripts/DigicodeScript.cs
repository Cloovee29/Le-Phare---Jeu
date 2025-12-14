using UnityEngine;
using UnityEngine.EventSystems;

public class DigicodeScript : MonoBehaviour
{
    public GameObject zoomDigicode;
    public GameObject character;
    public GameObject uiArrows;
    public GameObject logoJournal;

    public GameObject chestOpen;
    public GameObject chestClose;

    public int goodAnswers;

    public void ButtonPressed(string tagNote)
    {
        EnigmaEnd();

        if (tagNote == "raven" || tagNote == "wave" || tagNote == "shell")
        {
            
            goodAnswers = goodAnswers + 1;
            print("bouton ok");
            EnigmaEnd();
        }
        else
        {
            Debug.Log("Mauvaise touche");
        }
    }


    public void EnigmaEnd()
    {
        if (goodAnswers == 3)
        {
            zoomDigicode.SetActive(false);
            character.SetActive(true);
            uiArrows.SetActive(true);
            logoJournal.SetActive(true);

            print("énigme finito pipo");
            chestOpen.SetActive(true);
            chestClose.SetActive(false);

        }
       
    }


    public void OnMouseDown()
    {
        zoomDigicode.SetActive(true);
        character.SetActive(false);
        logoJournal.SetActive(false);
        uiArrows.SetActive(false);
        
    }
  
}
