using DG.Tweening;
using UnityEngine;

public class PushTonneaux : MonoBehaviour
{
    float duration = 1f;
    bool isPush;
    BoxCollider2D boxCollider;

    public GameObject door;
    public BoxCollider2D doorBoxCollider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isPush = false;
        doorBoxCollider.enabled = false;
        boxCollider = GetComponent<BoxCollider2D>();
        doorBoxCollider = door.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPush)
        {
            boxCollider.enabled = false;
            doorBoxCollider.enabled = true;
        }
    }

    private void OnMouseDown()
    {
        transform.DOLocalMoveX(29f, duration).SetEase(Ease.OutCubic);
        isPush = true;
    }
}
