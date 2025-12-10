using UnityEngine;

public class ChangeDiplomeScript : MonoBehaviour
{
    public InventoryItemScript inventoryItem;
    InventoryManagerScript inventoryManager;
    public Sprite newDiplome;
    SpriteRenderer spriteRenderer;

    //public GameObject oldDiplome;
    public Sprite oldDiplomeSurbriSprite;
    public Sprite oldDiplomeSprite;
    //public bool surbriDiplome = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //print(surbriDiplome);
    }

    public void ChangeDiplome()
    {
        print("change diplome trouvé");
        spriteRenderer.sprite = newDiplome;
        //surbriDiplome = true;
        //inventoryManager.DeleteItem(Item);
    }

    public void SurbriDiplome()
    {
        //spriteRenderer.sprite = oldDiplomeSurbriSprite;
        //surbriDiplome = true;

        if (inventoryItem.onDragDiplome == true)
        {
            spriteRenderer.sprite = oldDiplomeSurbriSprite;
        }
        else
        {
            spriteRenderer.sprite = oldDiplomeSprite;
            inventoryItem.onDragDiplome = false;
        }
    }

    //public void StopSurbriDiplome()
    //{
    //    spriteRenderer.sprite = oldDiplomeSprite;
    //    inventoryItem.onDragDiplome = false;
    //}

    //test surbrillance

    //if (CurrentItemIdName == ItemName.Diplome)
    //{
    //    oldDiplome.GetComponent<SpriteRenderer>().sprite = oldDiplomeSurbriSprite;
    //}
}
