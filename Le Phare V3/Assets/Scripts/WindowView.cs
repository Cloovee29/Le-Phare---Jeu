using UnityEngine;
using UnityEngine.TextCore.Text;

public class WindowView : MonoBehaviour
{
    public GameObject windowViewGO;
    public GameObject journal;
    public GameObject buttonEndGame;
    public GameObject character;

    private BoxCollider2D[] decorsBoxCollider2D;
    public GameObject decors;
    public void CloseWindow()
    {
        decorsBoxCollider2D = decors.GetComponentsInChildren<BoxCollider2D>();
        windowViewGO.SetActive(false);
        journal.SetActive(true);
        character.SetActive(true);
        foreach (BoxCollider2D col in decorsBoxCollider2D)
            col.enabled = true;
    }

    public void windowView()
    {
        decorsBoxCollider2D = decors.GetComponentsInChildren<BoxCollider2D>();
        foreach (BoxCollider2D col in decorsBoxCollider2D)
            col.enabled = false;
        windowViewGO.SetActive(true);
        buttonEndGame.SetActive(true);
        journal.SetActive(false);
        character.SetActive(false);
    }

}
