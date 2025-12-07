using UnityEngine;
using UnityEngine.EventSystems;

public class HoleScript : MonoBehaviour
{

 public float posX;
 public float posY;
 public string answer;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //position du trou
     public void GenerateHole(HoleSOScript hole)
    {
        answer = hole.answer;
    GetComponent<RectTransform>().anchoredPosition = new Vector2(hole.posY,hole.posY);
    }


}
