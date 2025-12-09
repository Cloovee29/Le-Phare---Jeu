using UnityEngine;

public class ChangeDiplomeScript : MonoBehaviour
{
    InventoryItemScript inventoryItem;
    InventoryManagerScript inventoryManager;
    public Sprite newDiplome;
    SpriteRenderer spriteRenderer;

    //public GameObject oldDiplome;
    //public Sprite oldDiplomeSurbriSprite;
    //public Sprite oldDiplomeSprite;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeDiplome()
    {
        print("change diplome trouvé");
        spriteRenderer.sprite = newDiplome;

        //inventoryManager.DeleteItem(Item);
    }

    //test surbrillance

    //if (CurrentItemIdName == ItemName.Key)
    //{
    //    doorGO.GetComponent<SpriteRenderer>().sprite = doorSurbri;
    //}

    //if (CurrentItemIdName == ItemName.Diplome)
    //{
    //    oldDiplome.GetComponent<SpriteRenderer>().sprite = oldDiplomeSurbriSprite;
    //}
}
