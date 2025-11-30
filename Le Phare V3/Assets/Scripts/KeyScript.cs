using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class KeyScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    Transform key;
    public GameObject zoomSerrure;

    // pour son de la porte LVL1
    //public AudioSource doorAudio;
    //public AudioClip openingClip;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnBeginDrag(PointerEventData eventData)
    {
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
    }

    public void TurnKey()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
        //float scaleX = transform.localScale.x;
    }
public void OnTriggerEnter2D(Collider2D collision)
    {
        float scaleX = transform.localScale.x;
        if (collision.CompareTag("Serrure") && scaleX == -1f)
        {
            //partie amelie si questions !c'est pour faire jouer le son de la porte; ça a pas fonctionné
            //if (dooraudio != null && openingclip != null)
            //{
            //    audiosource audio = door.getcomponent<audiosource>();
            //    if (audio != null && openingclip != null)
            //    {
            //        dooraudio.clip = openingclip;
            //        dooraudio.play();
            //    }
            //}

            //zoomSerrure.SetActive(false);
            SceneManager.LoadScene("02 - Lighthouse1");

        }
    }
}

