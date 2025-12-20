using UnityEngine;

public class DoorLevel1Zoom : MonoBehaviour
{
    public GameObject zoomSerrure;
    public GameObject character;
    public GameObject arrows;
    public GameObject descriptionText;
    public GameObject decors;

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
        descriptionText.SetActive(false);
        decors.SetActive(false);
    }

    public void ExitDoor()
    {
        zoomSerrure.SetActive(false);
        character.SetActive(true);
        arrows.SetActive(true);
        descriptionText.SetActive(true);
        decors.SetActive(true);
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
