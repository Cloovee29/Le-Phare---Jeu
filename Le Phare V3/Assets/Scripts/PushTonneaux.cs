using DG.Tweening;
using UnityEngine;
using System.Collections;

public class PushTonneaux : MonoBehaviour
{
    float duration = 1f;
    bool isPush;
    BoxCollider2D tonneauxBoxCollider;

    public GameObject door;
    public BoxCollider2D doorBoxCollider;

    public PageScript pageScript;
    public GameObject marie;
    public GameObject marieDialogue;
    public GameObject marieDialogue2;

    public bool canBePushed = false;

    bool timer = false;
    bool timer2 = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isPush = false;
        
        tonneauxBoxCollider = GetComponent<BoxCollider2D>();
        tonneauxBoxCollider.enabled = true;

        doorBoxCollider = door.GetComponent<BoxCollider2D>();
        doorBoxCollider.enabled = false;

        marieDialogue.SetActive(false);
        marieDialogue2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isPush)
        {
            tonneauxBoxCollider.enabled = false;
            doorBoxCollider.enabled = true;
        }
        else
        {
            doorBoxCollider.enabled = false;
        }
    }

    public void CanBePushed()
    {
        canBePushed = true;
        doorBoxCollider.enabled = false;
        print("can be pushed");
    }

    public void OnMouseDown()
    {
        print("appuitonneaux");
        if (canBePushed == true)
        {
            if (!timer)
            {
                StartCoroutine(TimerAvantPush());
                print("corres pushtonneaux");
                marieDialogue.SetActive(true);
            }
            //marieDialogue.transform.position = marie.transform.position;
        }

    }

    IEnumerator TimerAvantPush()
    {
        timer = true;

        yield return new WaitForSeconds(3f);

        CallPushTonneaux();
        marieDialogue.SetActive(false);
        marieDialogue2.SetActive(true);
        StartCoroutine(TimerSecondDialogue());

        timer = false;
    }

    IEnumerator TimerSecondDialogue()
    {
        timer2 = true;

        yield return new WaitForSeconds(3f);

        marieDialogue2.SetActive(false);

        timer2 = false;
    }
    public void CallPushTonneaux()
    {
        transform.DOLocalMoveX(29f, duration).SetEase(Ease.OutCubic);
        isPush = true;
    }
}
