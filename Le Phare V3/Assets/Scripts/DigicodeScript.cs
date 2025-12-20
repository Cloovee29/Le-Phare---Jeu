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
    public GameObject portrait5;

    public bool ravenOk;
    public bool waveOk;
    public bool shellOk;

    public int goodAnswers;

    private BoxCollider2D[] decorsBoxCollider2D;
    public GameObject decors;
    public BoxCollider2D coffreBoxCollider2D;

    public void Awake()
    {
        coffreBoxCollider2D = chestClose.GetComponent<BoxCollider2D>();
    }

    public void ButtonPressed(string tagNote)
    {
        EnigmaEnd();

        if (tagNote == "shell" && !shellOk)
        {
            shellOk = true;
            goodAnswers = goodAnswers + 1;
            print("bouton ok");
            EnigmaEnd();
        }
        else if (tagNote == "raven" && !ravenOk)
        {
            ravenOk = true;
            goodAnswers = goodAnswers + 1;
            print("bouton ok");
            EnigmaEnd();
        }
        else if ( tagNote == "wave" && !waveOk)
        {
            waveOk = true;
            goodAnswers = goodAnswers + 1;
            print("bouton ok");
            EnigmaEnd();
        }
        else
        {
            Debug.Log("Mauvaise touche");
            goodAnswers = 0;
            shellOk = false;
            waveOk = false;
            ravenOk = false;
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
            portrait5.SetActive(true);
            chestClose.SetActive(false);

        }
       
    }


    public void OnMouseDown()
    {
        zoomDigicode.SetActive(true);
        character.SetActive(false);
        logoJournal.SetActive(false);
        uiArrows.SetActive(false);
        //foreach (BoxCollider2D col in decorsBoxCollider2D)
        //{

        //    if (col.gameObject == coffreBoxCollider2D.gameObject)
        //        continue;
        //    col.enabled = false;

        //}
    }

    public void CloseDigicode()
    {
        zoomDigicode.SetActive(false);
        character.SetActive(true);
        logoJournal.SetActive(true);
        uiArrows.SetActive(true);
        //foreach (BoxCollider2D col in decorsBoxCollider2D)
        //    col.enabled = true;
    }
  
}
