using UnityEngine;
using UnityEngine.EventSystems;

public class PortraitsScript : MonoBehaviour
{
    public GameObject PortraitPosTarget;
    private Vector3 offset;
    //bool goodPositionPortrait;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //print("scriptmarche");
        //goodPositionPortrait = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        
        
    }

    private void OnMouseUp()
    {
        
        
    }

    private void OnMouseDrag()
    {
        
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(
        new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(transform.position).z)
    );
        transform.position = mouseWorldPos + offset;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("colli");
        //if (collision.gameObject.tag == gameObject.tag)
        //{
        //    goodPositionPortrait = true;
        //}
    }
}
