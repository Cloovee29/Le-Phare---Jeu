using UnityEngine;

public class OpenWindowScript : MonoBehaviour
{
    public GameObject windowGO;
    SpriteRenderer window;
    public Sprite closedWindow;
    public Sprite closedWindowAndSeagull;
    public Sprite openedWindowAndSeagull;  
    public Sprite openWindow;

    public GameObject fieldGlass2;
    void Start()
    {
        window = windowGO.GetComponent<SpriteRenderer>();
        fieldGlass2.SetActive(false);
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
        if(window.sprite == closedWindowAndSeagull)
        {
            window.sprite = openedWindowAndSeagull;
        }
        if (window.sprite == openedWindowAndSeagull)
        {
            window.sprite = openWindow;    
            fieldGlass2.SetActive(true);
        }
    }
}
