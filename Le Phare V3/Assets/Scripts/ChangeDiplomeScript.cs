using UnityEngine;

public class ChangeDiplomeScript : MonoBehaviour
{
    public Sprite newDiplome;
    SpriteRenderer spriteRenderer;

    public Sprite oldDiplomeSurbriSprite;
    public Sprite oldDiplomeSprite;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ChangeDiplome()
    {
        spriteRenderer.sprite = newDiplome;
    }

    public void SurbriDiplome(bool newState)
    {
        if (newState)
        {
            spriteRenderer.sprite = oldDiplomeSurbriSprite;
        }
        else
        {
            spriteRenderer.sprite = oldDiplomeSprite;
        }
    }
}
