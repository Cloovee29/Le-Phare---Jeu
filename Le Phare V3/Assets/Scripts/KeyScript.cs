using UnityEngine;

public class KeyScript : MonoBehaviour
{

    public InventoryItemScript InventoryItemScript;
    public string CurrentItemIdName { get; set; }
    Item item;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //isDraging = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (CurrentItemIdName == "cle")
        {
            GameObject.Destroy(gameObject);

        }
    }
}
