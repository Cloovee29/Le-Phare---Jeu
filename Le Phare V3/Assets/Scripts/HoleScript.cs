using UnityEngine;
using UnityEngine.EventSystems;

public class HoleScript : MonoBehaviour
{

 private float posX;
 private float posY;
 private string answer;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        answer = "test";
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //position du trou
     public void GenerateHole(string correctAnswer, float nouvelleX, float nouvelleY)
    {
        answer = correctAnswer;
    GetComponent<RectTransform>().anchoredPosition = new Vector2(nouvelleX,nouvelleY);
    }


}
