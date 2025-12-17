using UnityEngine;

[RequireComponent (typeof(BoxCollider2D))]

public class MouseAspectManagerScript : MonoBehaviour
{
    public Texture2D defaultCursor;
    public Texture2D hoverObjectsCursor;
    public Texture2D grabCursor;
    public Texture2D descriptionCursor;
    public bool containsDescription;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    private void Start()
    {
        Cursor.SetCursor(defaultCursor, hotSpot, cursorMode);
    }
    public void OnMouseEnter()
    {
        if (containsDescription == true)
        {
            Cursor.SetCursor(descriptionCursor, hotSpot, cursorMode);
        }
        else
        {
            Cursor.SetCursor(hoverObjectsCursor, hotSpot, cursorMode);
        }
    }

    public void OnMouseExit()
    {
        Cursor.SetCursor(defaultCursor, Vector2.zero, cursorMode);
    }

}