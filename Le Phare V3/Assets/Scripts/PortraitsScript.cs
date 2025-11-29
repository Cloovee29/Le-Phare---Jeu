using UnityEngine;
using UnityEngine.EventSystems;

public class PortraitsScript : MonoBehaviour
{
    public GameObject PortraitPosTarget;
    private Vector3 offset;
    bool goodPositionPortrait;
    public static int countGoodPositionPortrait = 0;

    public Sprite portrait1;
    public Sprite portrait3;
    public Sprite portrait5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //print("scriptmarche");
        //goodPositionPortrait = false;
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
        if (gameObject.GetComponent<SpriteRenderer>().sprite == portrait1 || 
            gameObject.GetComponent<SpriteRenderer>().sprite == portrait3 || 
            gameObject.GetComponent<SpriteRenderer>().sprite == portrait5)
        {
            print("spritechange");
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(
            new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(transform.position).z)
);
            transform.position = mouseWorldPos + offset;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("colli");
        if (collision.gameObject.tag == gameObject.tag)
        {
            //goodPositionPortrait = true;
            print("bien placé");
            countGoodPositionPortrait = countGoodPositionPortrait + 1;
            print(countGoodPositionPortrait);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == gameObject.tag)
        {
            //goodPositionPortrait = true;
            print("bien puis mal placé");
            countGoodPositionPortrait = countGoodPositionPortrait - 1;
            print(countGoodPositionPortrait);
        }
    }

    void SolvedEnigma()
    {
        print("enigmeresolue");
    }
}

