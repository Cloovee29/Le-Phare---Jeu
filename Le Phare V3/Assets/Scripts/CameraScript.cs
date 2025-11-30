using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.TextCore.Text;

public class CameraScript : MonoBehaviour
{
    public Transform background;
    public float screenLeft;
    public float screenRight;
    public float duration;

    public ClickMove2D character;

    public GameObject arrowLeft;
    public GameObject arrowRight;

   void Start()
    {
        arrowLeft.SetActive(false);
        Cursor.lockState = CursorLockMode.Confined;
    }

    void Update()
    {

    }

    public void ButtonLeft()
    {
        character.HideAndResetCharacter(); // pour faire depop dora


        //character.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        background.DOMoveX(screenLeft, duration).SetEase(Ease.OutCubic).OnComplete(() => {
            arrowLeft.SetActive(false);
            arrowRight.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            //character.SetActive(true);

            character.ShowCharacter(); // pour remettre dora


        });
    }

    public void ButtonRight()
    {

        character.HideAndResetCharacter();

        //character.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        background.DOMoveX(screenRight, duration).SetEase(Ease.OutCubic).OnComplete(() => {
            arrowRight.SetActive(false);
            arrowLeft.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            //character.SetActive(true);

            character.ShowCharacter();

        });
    }
}
