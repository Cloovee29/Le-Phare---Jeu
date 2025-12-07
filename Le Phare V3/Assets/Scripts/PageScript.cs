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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        listWordsToDrag = new List<GameObject>();
        listHoles = new List<GameObject>();
    }


    //Y de 400 à -200
    public void CreatePage(int numbNewPage, PageSOScript pageContent)
    {
        numbPage = numbNewPage;

        transform.Find("TextPage").GetComponent<TextMeshProUGUI>().text = pageContent.textPage1;
        transform.Find("TextPage2").GetComponent<TextMeshProUGUI>().text = pageContent.textPage2;

        //crée une liste d'objets mots à partir de la liste de scripts dans unity
        for (int i = 0; i < pageContent.listWords.Count; i++)
        {
            GameObject newWord = Instantiate(word);
            newWord.transform.SetParent(page.transform, false);
            listWordsToDrag.Add(newWord);

           float newY = 60f - i * 20f;
            listWordsToDrag[i].GetComponent<WordScript>().CreateWord(pageContent.listWords[i], newY);
        }

        //crée une liste de trous
        for (int i = 0; i < pageContent.listHoles.Count; i++)
        {
            GameObject newHole = Instantiate(hole);
            newHole.transform.SetParent(page.transform, false);
            listHoles.Add(newHole);

            HoleSOScript holeData = pageContent.listHoles[i];

            string answer = holeData.answer;
            float posX = holeData.posX;
            float posY = holeData.posY;

            listHoles[i].GetComponent<HoleScript>().GenerateHole(answer, posX, posY);
        }
    }


}
