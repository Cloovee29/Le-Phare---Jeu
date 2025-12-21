using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.TextCore.Text;
using static UnityEditor.Experimental.GraphView.GraphView;
using UnityEngine.EventSystems;

public class CameraScript : MonoBehaviour
{
    public Transform background;
    public float screenLeft;
    public float screenRight;
    public float duration;

    public ClickMove2D character;

    public GameObject arrowLeft;
    public GameObject arrowRight;

    public PortraitsScript portraitsScript;
    public LadderScript ladderScript;

    void Start()
    {
        arrowLeft.SetActive(false);
        Cursor.lockState = CursorLockMode.Confined;
        portraitsScript = GetComponent<PortraitsScript>();
    }
    public void ButtonLeft()
    {
        character.HideAndResetCharacter();

        Cursor.lockState = CursorLockMode.Locked;
        background.DOMoveX(screenLeft, duration).SetEase(Ease.OutCubic).OnComplete(() => {
            arrowLeft.SetActive(false);
            arrowRight.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;

            character.ShowCharacter();
        });
    }
    public void ButtonRight()
    {
        character.HideAndResetCharacter();

        Cursor.lockState = CursorLockMode.Locked;
        background.DOMoveX(screenRight, duration).SetEase(Ease.OutCubic).OnComplete(() => {
            arrowRight.SetActive(false);
            arrowLeft.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;

            character.ShowCharacter();
        });
    }
}
