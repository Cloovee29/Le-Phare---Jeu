using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PortraitsScript : MonoBehaviour
{
    //public GameObject PortraitPosTarget;
    private Vector3 offset;
    //bool goodPositionPortrait;
    public static int countGoodPositionPortrait = 0;

    public Sprite portrait1;
    public Sprite portrait3;
    public Sprite portrait5;

    Vector3 targetPosition;
    bool isOnTarget = false;

    void Start()
    {

    }

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
        if (isOnTarget)
        {
            transform.position = targetPosition;
            //print("rePos");
        }
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
            //print("bien placé");
            countGoodPositionPortrait++;
            print(countGoodPositionPortrait);
            
        }

        if (collision.gameObject.tag == "Portrait1" ||
            collision.gameObject.tag == "Portrait3" ||
            collision.gameObject.tag == "Portrait5")
        {
            isOnTarget = true;
            targetPosition = collision.transform.position;
            //print("cible detectee");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == gameObject.tag)
        {
            //print("bien puis mal placé");
            countGoodPositionPortrait--;
            print(countGoodPositionPortrait);
        }

        if (collision.gameObject.CompareTag("Portrait1") ||
            collision.gameObject.CompareTag("Portrait3") ||
            collision.gameObject.CompareTag("Portrait5"))
        {
            isOnTarget = false;
            //print("Sorti de la cible");
        }
    }
    void SolvedEnigma()
    {
        print("enigmeresolue");
        SceneManager.LoadScene("03 - Lighthouse2");
    }
}

