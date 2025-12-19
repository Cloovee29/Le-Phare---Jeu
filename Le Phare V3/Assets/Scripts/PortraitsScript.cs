using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PortraitsScript : MonoBehaviour
{
    private Vector3 offset;
    public static int countGoodPositionPortrait = 0;

    public Sprite portrait1;
    public Sprite portrait4;
    public Sprite portrait5;

    Vector3 targetPosition;
    bool isOnTarget = false;

    public LadderScript ladderScript;

    public bool portraitEnigmaSolved = false;

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
            print("bien placé");
            countGoodPositionPortrait++;
            print(countGoodPositionPortrait);          
        }

        if (collision.gameObject.tag == "Portrait1" ||
            collision.gameObject.tag == "Portrait4" ||
            collision.gameObject.tag == "Portrait5")
        {
            isOnTarget = true;
            targetPosition = collision.transform.position;
            print("cible detectee");
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

        if (collision.gameObject.CompareTag("Portrait1") ||
            collision.gameObject.CompareTag("Portrait4") ||
            collision.gameObject.CompareTag("Portrait5"))
        {
            isOnTarget = false;
            print("Sorti de la cible");
        }
    }
    void SolvedEnigma()
    {
        print("enigmeresolue");
        portraitEnigmaSolved = true;
    }
}

