using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PageScript : MonoBehaviour
{

    private List<GameObject> listHoles; //liste de trous associés à une page
    public List<GameObject> listWordsToDrag; //liste des mots à placer dans le journal
    private int numbPage; //numéro de la page du carnet
    public GameObject word;
    public GameObject page;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        listWordsToDrag = new List<GameObject>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Y de 400 à -200
    public void CreatePage(int numbNewPage, List<string> listWords)
    {
        numbPage = numbNewPage;

        //crée une liste d'objets mots à partir de la liste de scripts dans unity
        for (int i = 0; i < listWords.Count; i++)
        {
            GameObject newWord = Instantiate(word);
            newWord.transform.SetParent(page.transform, false);
            Debug.Log(newWord);
            listWordsToDrag.Add(newWord);

           float newY = 60f - i * 20f;
            listWordsToDrag[i].GetComponent<WordScript>().CreateWord(listWords[i], newY);
        }

    }


}
