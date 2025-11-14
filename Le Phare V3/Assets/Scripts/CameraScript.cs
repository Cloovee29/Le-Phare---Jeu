using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CameraScript : MonoBehaviour
{
    public Transform background;
    public float screenLeft;
    public float screenRight;
    public float duration;

    public GameObject arrowLeft;
    public GameObject arrowRight;

   void Start()
    {
        arrowRight.SetActive(false);
        Cursor.lockState = CursorLockMode.Confined;
    }

    void Update()
    {

    }

    public void ButtonLeft()
    {
        Cursor.lockState = CursorLockMode.Locked;
        background.DOMoveX(screenLeft, duration).SetEase(Ease.OutCubic).OnComplete(() => {
            arrowLeft.SetActive(false);
            arrowRight.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
        });
    }

    public void ButtonRight()
    {
        Cursor.lockState = CursorLockMode.Locked;
        background.DOMoveX(screenRight, duration).SetEase(Ease.OutCubic).OnComplete(() => {
            arrowRight.SetActive(false);
            arrowLeft.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
        });
    }
}
