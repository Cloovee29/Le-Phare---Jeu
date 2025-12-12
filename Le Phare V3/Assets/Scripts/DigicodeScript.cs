using UnityEngine;
using UnityEngine.EventSystems;

public class DigicodeScript : MonoBehaviour
{
    public GameObject zoomDigicode;
    public GameObject character;
    public GameObject arrows;
   

    public void OnMouseDown()
    {
        zoomDigicode.SetActive(true);
        character.SetActive(false);
        arrows.SetActive(false);
    }
  
}
