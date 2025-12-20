using DG.Tweening;
using UnityEngine;

public class ChangeDiplomeScript : MonoBehaviour
{
    public Sprite newDiplome;
    SpriteRenderer spriteRenderer;

    public Sprite oldDiplomeSurbriSprite;
    public Sprite oldDiplomeSprite;

    public GameObject keys;
    float duration = 1f;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        keys.SetActive(false);

    }

    public void ChangeDiplome()
    {
        spriteRenderer.sprite = newDiplome;
        keys.SetActive(true);
        keys.transform.DOLocalMoveY(-3f, duration).SetEase(Ease.OutBounce);
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
