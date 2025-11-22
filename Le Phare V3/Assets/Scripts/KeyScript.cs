using UnityEngine;
using UnityEngine.EventSystems;

public class KeyScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    Transform key;

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
        //throw new System.NotImplementedException();
    }

    public void OnDrag(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
        
    }

    public void TurnKey()
    {
        //Vector3 localScale = GetComponent<Transform>().localScale;

        // if (transform.localScale.x == -1)
        // {
        //     transform.localScale = new Vector3(1, 1, 1);
        //     Vector3 localScale = GetComponent<Transform>().localScale;
        // }

        //else if (transform.localScale.x == 1)
        // {
        //     transform.localScale = new Vector3(-1, 1, 1);
        //    Vector3 localScale = GetComponent<Transform>().localScale;
        // }

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}

