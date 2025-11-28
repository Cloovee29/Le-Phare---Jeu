using UnityEngine;

public class DoorLevel1Zoom : MonoBehaviour
{
    public GameObject zoomSerrure;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        zoomSerrure.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenDoor()
    {
        zoomSerrure.SetActive(true);
    }
}
