using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PageScript : MonoBehaviour
{

    private List<GameObject> listHoles; //liste de trous associés à une page
    public GameObject hole; //un seul trou pour tester avant d'étendre à la liste

    private List<GameObject> listWordsToDrag; //liste des mots à placer dans le journal

    private int numbPage; //numéro de la page du carnet
    public GameObject word;
    public GameObject page;

    public GameObject validationDrawing; //image validation page

    public float spaceY; //interligne des mots
    public float spaceX;

    public int compteurMots = 0;
    public int totalMotsScene;

    public bool textHolesSolve = false;

    public bool sceneMaison; // pour éviter une erreur du Pushtonneaux dans les autres scènes. Mais aurait sûrement été mieux dans un script séparé.
    public PushTonneaux pushTonneaux;

    public bool sceneFinPhare;
    public NotesEnigmaScript notesEnigmaScript;

    void Awake()
    {
        listWordsToDrag = new List<GameObject>();
        listHoles = new List<GameObject>();
    }

    public void CreatePage(int numbNewPage, PageSOScript pageContent)
    {
        numbPage = numbNewPage;

        transform.Find("TextPage").GetComponent<TextMeshProUGUI>().text = pageContent.textPage1;
        transform.Find("TextPage2").GetComponent<TextMeshProUGUI>().text = pageContent.textPage2;

        //crée une liste d'objets mots à partir de la liste de scripts dans unity
        for (int i = 0; i < pageContent.listWords.Count; i++)
        {
            GameObject newWord = Instantiate(word);
            word.SetActive(false);
            newWord.transform.SetParent(page.transform, false);
            listWordsToDrag.Add(newWord);

            float newX = -165f - i * spaceX;
            listWordsToDrag[i].GetComponent<WordScript>().CreateWord(pageContent.listWords[i], newX);
        }

        //crée une liste de trous
        for (int i = 0; i < pageContent.listHoles.Count; i++)
        {
            GameObject newHole = Instantiate(hole);
            newHole.transform.SetParent(page.transform, false);
            listHoles.Add(newHole);

            listHoles[i].GetComponent<HoleScript>().GenerateHole(pageContent.listHoles[i]);
        }
    }

    public void MotCorrect()
    {
        compteurMots++;
        Debug.Log("Mots corrects : " + compteurMots);

        if (compteurMots == totalMotsScene)
        {
            Debug.Log("texte à trous terminé");
            CompletePage();
        }
    }

    public void CompletePage()
    {
        print("enigme résolue, dessin apparait");
        textHolesSolve = true;
        print("textHolesSolved");

        validationDrawing.SetActive(true);

        if (sceneMaison == true)
        {
            pushTonneaux.CanBePushed();

        }

        if (sceneFinPhare == true)
        {
            notesEnigmaScript.journalPageSolved = true;
        }
    }

}
