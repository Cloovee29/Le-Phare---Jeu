using UnityEngine;

public class DoorLevel1Zoom : MonoBehaviour
{
    public GameObject zoomSerrure;
    public GameObject character;
    public GameObject arrows;

    SpriteRenderer spriteRenderer;
    public Sprite doorSprite;
    public Sprite doorSpriteSurbri;  
    void Start()
    {
        zoomSerrure.SetActive(false);
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void OpenDoor()
    {
        zoomSerrure.SetActive(true);
        character.SetActive(false);
        arrows.SetActive(false);
    }

    public void DoorSurbri(bool newState)
    {
        if (newState)
        {
            spriteRenderer.sprite = doorSpriteSurbri;
        }
        else
        {
            spriteRenderer.sprite = doorSprite;
        }
    }
}
