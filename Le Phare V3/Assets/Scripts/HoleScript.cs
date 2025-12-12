using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;


public class HoleScript : MonoBehaviour
{

 public float posX;
 public float posY;
 public string answer;


    //position du trou
    public void GenerateHole(HoleSOScript hole)
    {
        answer = hole.answer;
    GetComponent<RectTransform>().anchoredPosition = new Vector2(hole.posY,hole.posY);
    }


}
