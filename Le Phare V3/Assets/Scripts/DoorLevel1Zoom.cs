using UnityEngine;

public class DoorLevel1Zoom : MonoBehaviour
{
    public GameObject zoomSerrure;
    public GameObject character;
    public GameObject arrows;
    void Start()
    {
        zoomSerrure.SetActive(false);
    }

    public void OpenDoor()
    {
        zoomSerrure.SetActive(true);
        character.SetActive(false);
        arrows.SetActive(false);
    }
}
