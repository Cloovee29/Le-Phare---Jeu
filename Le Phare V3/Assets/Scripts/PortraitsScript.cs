using UnityEngine;
using UnityEngine.EventSystems;

public class PortraitsScript : MonoBehaviour
{
    //public GameObject PortraitPosTarget;
    private Vector3 offset;
    //bool goodPositionPortrait;
    public static int countGoodPositionPortrait = 0;

    public Sprite portrait1;
    public Sprite portrait3;
    public Sprite portrait5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(countGoodPositionPortrait == 3)
        {
            SolvedEnigma();            
        }
        
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
        if (collision.gameObject.tag == gameObject.tag)
        {
            print("bien placé");
            countGoodPositionPortrait++;
            print(countGoodPositionPortrait);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == gameObject.tag)
        {
            print("bien puis mal placé");
            countGoodPositionPortrait--;
            print(countGoodPositionPortrait);
        }
    }

    void SolvedEnigma()
    {
        print("enigmeresolue");
    }
}

