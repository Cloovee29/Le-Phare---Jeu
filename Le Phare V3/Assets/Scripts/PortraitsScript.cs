using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PortraitsScript : MonoBehaviour
{
    private Vector3 offset;
    public static int countGoodPositionPortrait = 0;
    Vector3 targetPosition;
    //bool isOnTarget = false;
    bool isCorrectlyPlaced = false;
    public bool portraitEnigmaSolved = false;
    Transform currentSlot = null;

    public CameraScript cameraScript;
    public LadderScript ladderScript;

    public GameObject imagesWall;

    private void OnMouseDown()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = transform.position.z;
        offset = transform.position - mouseWorldPos;
    }

    private void OnMouseDrag()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = transform.position.z;
        transform.position = mouseWorldPos + offset;
    }

    private void OnMouseUp()
    {
        if (currentSlot != null)
        {
            transform.position = currentSlot.position;
            currentSlot.GetComponent<Collider2D>().enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Portrait1") ||
            collision.CompareTag("Portrait4") ||
            collision.CompareTag("Portrait5"))
        {
            currentSlot = collision.transform;
        }
        // Le portrait entre dans SA bonne zone

        if (collision.CompareTag(gameObject.tag) && !isCorrectlyPlaced)
        {
            isCorrectlyPlaced = true;
            countGoodPositionPortrait++;
            Debug.Log($"{name} bien placé ({countGoodPositionPortrait})");
        }

        // Détection d'une zone cible pour le snap
        if (collision.CompareTag("Portrait1") ||
            collision.CompareTag("Portrait4") ||
            collision.CompareTag("Portrait5"))
        {
            //isOnTarget = true;
            targetPosition = collision.transform.position;
        }
        CheckSolved();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (currentSlot != null && collision.transform == currentSlot)
        {
            currentSlot = null;
        }
        // Le portrait quitte SA bonne zone
        if (collision.CompareTag(gameObject.tag) && isCorrectlyPlaced)
        {
            isCorrectlyPlaced = false;
            countGoodPositionPortrait--;
            Debug.Log($"{name} retiré ({countGoodPositionPortrait})");
        }

        // Sortie d'une zone cible
        if (collision.CompareTag("Portrait1") ||
            collision.CompareTag("Portrait4") ||
            collision.CompareTag("Portrait5"))
        {
            //isOnTarget = false;
        }
    }

    //private void Update()
    //{
    //    if (countGoodPositionPortrait == 3 && !portraitEnigmaSolved)
    //    {
    //        SolvedEnigma();
    //    }
    //}

    //void SolvedEnigma()
    //{
    //    portraitEnigmaSolved = true;
    //    Debug.Log("Énigme résolue");
    //}
    void CheckSolved()
    {
        if (!portraitEnigmaSolved && countGoodPositionPortrait == 3)
        {
            portraitEnigmaSolved = true;
            Debug.Log("Énigme résolue");
            //cameraScript.ButtonRight();
            ladderScript.PlayLadderTween();
            Destroy(imagesWall);
            
        }
    }
}

