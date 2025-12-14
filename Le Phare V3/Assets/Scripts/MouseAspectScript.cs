using UnityEngine;

[RequireComponent (typeof(BoxCollider2D))]

public class MouseAspectScript : MonoBehaviour
{
    public Texture2D defaultCursor;
    public Texture2D hoverObjectsCursor;
    public Texture2D grabCursor;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    private void Start()
    {
        Cursor.SetCursor(defaultCursor, hotSpot, cursorMode);
    }
    void OnMouseEnter()
    {
        Cursor.SetCursor(hoverObjectsCursor, hotSpot, cursorMode);
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(defaultCursor, Vector2.zero, cursorMode);
    }

}