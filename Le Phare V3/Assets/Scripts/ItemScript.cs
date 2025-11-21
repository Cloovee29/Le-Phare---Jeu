using System.ComponentModel;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Scriptable object/Item")]
public class Item : ScriptableObject
{
    [Header("Only gameplay")]
    public TileBase tile;
    public Vector2Int range = new Vector2Int(5, 4);

    [Header("Only UI")]
    [Header("Both")]
    public Sprite image;
    public ItemName idName;

}

public enum ItemName
{
    Key,
    Radio,
    Light, 
    Diplome
}
