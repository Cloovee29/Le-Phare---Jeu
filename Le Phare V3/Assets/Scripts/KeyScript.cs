using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class KeyScript : MonoBehaviour, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{

    Transform key;
    //public GameObject zoomSerrure;
       [Header("Sound")]
    public AudioSource doorAudio;   // AudioSource pour le son de la porte
    public AudioClip doorClip;      // clip à jouer

    Vector3 scaleInitiale;
    float duration = 0.5f;

    RectTransform rectTransform;
    Tween scaleTween;
    Tween flipTween;
    bool flipped = false;

    public MouseAspectScript mouseAspect;
    // pour son de la porte LVL1
    //public AudioSource doorAudio;
    //public AudioClip openingClip;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        scaleInitiale = rectTransform.localScale;
    }

    //void OnEnable()
    //{
    //    rectTransform.localScale = scaleInitiale;
    //}

    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        print("mouse enter");
        //scaleTween?.Kill();
        Vector3 targetScale = rectTransform.localScale * 1.3f;

        scaleTween = rectTransform.DOScale(targetScale, duration)
                                 .SetEase(Ease.OutCubic);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Vector3 targetScale = new Vector3(
            Mathf.Abs(scaleInitiale.x) * (flipped ? -1f : 1f),
            scaleInitiale.y,
            scaleInitiale.z
            );
        scaleTween = rectTransform.DOScale(targetScale, duration)
                                 .SetEase(Ease.OutCubic);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
        Cursor.SetCursor(mouseAspect.grabCursor, mouseAspect.hotSpot, mouseAspect.cursorMode);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Cursor.SetCursor(mouseAspect.defaultCursor, mouseAspect.hotSpot, mouseAspect.cursorMode);
    }

    public void TurnKey()
    
        //Vector3 scale = transform.localScale;
        //scale.x *= -1;
        //transform.localScale = scale;
        {
        // Inverse l'échelle X pour flip horizontal
        rectTransform.DOScaleX(rectTransform.localScale.x * -1, duration)
                     .SetEase(Ease.OutBounce);

        // Inverser l'état flip pour le hover
        flipped = !flipped;
    }
public void OnTriggerEnter2D(Collider2D collision)
    {
        float scaleX = transform.localScale.x;
        if (collision.CompareTag("Serrure") && flipped)
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

            SceneManager.LoadScene("02 - Lighthouse1");

        }
    }
}

