using UnityEngine;

public class FieldGlassInstanciateScript : MonoBehaviour
{

    public GameObject completeFieldglass;
    public GameObject decors;
    public GameObject window;

    public GameObject fieldGlassPiece2;

    SpriteRenderer spriteRenderer;

    public Sprite windowSpriteSurbri;
    public Sprite windowSprite;

    public void InstantiateCompleteFieldglass()
    {
        print("instancie longue-vue");
        GameObject newFieldglass = Instantiate(completeFieldglass);
        newFieldglass.SetActive(true);
        newFieldglass.transform.SetParent(decors.transform, true);
        newFieldglass.transform.position = window.transform.position;
        Destroy(fieldGlassPiece2);
    }

    public void FieldGlassSurbri(bool newState)
    {
        //if (newState)
        //{
        //    spriteRenderer.sprite = windowSpriteSurbri;
        //}
        //else
        //{
        //    spriteRenderer.sprite = windowSprite;
        //}
    }
}