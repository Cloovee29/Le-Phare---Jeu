using System.ComponentModel;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Scriptable object/Item")]
public class Item : ScriptableObject
{
    public Sprite image;
    public ItemName idName;
    public AudioClip audioClip;

}

public enum ItemName
{
    Key,
    Diplome,
    Portrait1,
    Portrait4,
    Portrait5,
    Portrait,
    LongueVue,
    PieceLongueVue,
    Coquillage,
}
