using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class MarieSurbriScript : MonoBehaviour
{
    public Sprite marieSprite;
    public Sprite marieSurbriSprite;
    SpriteRenderer spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SurbriMarie(bool newState)
    {
        if (newState)
        {
            spriteRenderer.sprite = marieSurbriSprite;
        }
        else
        {
            spriteRenderer.sprite = marieSprite;
        }
    }
}
