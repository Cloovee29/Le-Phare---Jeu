using System.ComponentModel;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
[CreateAssetMenu(menuName = "Holes")]
public class HoleSOScript : ScriptableObject
{
    public float posX;
    public float posY;
    public string answer;
}

public enum Holes
{
    Hole_101,
    Hole_102,
}
