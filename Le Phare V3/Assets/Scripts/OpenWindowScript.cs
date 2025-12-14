using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using static UnityEngine.InputSystem.LowLevel.InputStateHistory;

public class OpenWindowScript : MonoBehaviour
{
    public GameObject windowGO;
    SpriteRenderer window;
    public Sprite closedWindow;
    public Sprite closedWindowAndSeagull;
    public Sprite openedWindowAndSeagull;  
    public Sprite openWindow;

    public GameObject fieldGlass2;

    public GameObject completeFieldglass;

    public GameObject decors;

    public GameObject buttonEndGame;

    SpriteRenderer spriteRenderer;

    public Sprite pieceFGSpriteSurbri;
    public Sprite pieceFGSprite;

    int compteurWindow;
    void Start()
    {
        window = windowGO.GetComponent<SpriteRenderer>();
        fieldGlass2.SetActive(false);
        spriteRenderer = fieldGlass2.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenWindow()
    {
        print("fenetre ouverte");
        window.sprite = closedWindowAndSeagull;
    }

    private void OnMouseDown()
    {
        compteurWindow++;
        if (window.sprite == closedWindowAndSeagull && compteurWindow == 1)
        {
            window.sprite = openedWindowAndSeagull;
        }
        if (window.sprite == openedWindowAndSeagull && compteurWindow == 2)
        {
            window.sprite = openWindow;  
            fieldGlass2.SetActive(true);
        }
    }

    public void PieceFieldGlassSurbri(bool newState)
    {
        if (newState)
        {
            spriteRenderer.sprite = pieceFGSpriteSurbri;
        }
        else
        {
            spriteRenderer.sprite = pieceFGSprite;
        }
    }
}
